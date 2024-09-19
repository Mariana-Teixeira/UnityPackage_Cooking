using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    private PlayerStats m_playerStats;
    private List<SO_Ingredient> m_ingredientsToCook = new List<SO_Ingredient>();
    private Food m_cookedFood;

    private void Awake()
    {
        m_playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        RequestManager.PoolRequest.Invoke();
        CookerDisplay.SendDisplayText("Empty");
        DeliverDisplay.SendDisplayText("Nothing");
    }

    private void OnEnable()
    {
        PlayerInteraction.TransportIngredient += OnTransportIngredient;
        PlayerInteraction.Cook += OnCook;
        PlayerInteraction.DeliverRequest += OnDeliverRequest;
        PlayerInteraction.TrashIngredients += OnTrashIngredients;
    }

    private void OnDisable()
    {
        PlayerInteraction.TransportIngredient -= OnTransportIngredient;
        PlayerInteraction.Cook -= OnCook;
        PlayerInteraction.DeliverRequest -= OnDeliverRequest;
        PlayerInteraction.TrashIngredients -= OnTrashIngredients;
    }

    private void OnTransportIngredient(string ingredientName)
    {
        SoundManager.PlaySound(0);
        var ingredient = Loader.Ingredients[ingredientName];
        m_ingredientsToCook.Add(ingredient);
        CookerDisplay.DisplayFromIngredients.Invoke(m_ingredientsToCook);
    }

    private void OnCook()
    {
        if (m_ingredientsToCook.Count <= 0) { InformationDisplay.SendDisplayText.Invoke("The cooker is empty.", Color.yellow); return; }

        SoundManager.PlaySound(1);
        m_cookedFood = CreateFood();
        DeliverDisplay.SendFood(m_cookedFood);
        ResetIngredients();
    }

    private void OnDeliverRequest()
    {
        if (m_cookedFood == null) { InformationDisplay.SendDisplayText("There is nothing to deliver.", Color.yellow); return; }

        Deliver(m_cookedFood);
    }

    private void OnTrashIngredients()
    {
        SoundManager.PlaySound(4);
        ResetIngredients();
    }

    private void ResetIngredients()
    {
        m_ingredientsToCook.Clear();
        CookerDisplay.SendDisplayText("Empty");
    }

    private void Deliver(Food food)
    {
        var success = RequestManager.CompareFoodAndRecipe(food);
        if (success) DeliverRightFood(food);
        else DeliverWrongFood();
        ResetDelivery();
    }

    private void ResetDelivery()
    {
        DeliverDisplay.SendDisplayText("Nothing");
        m_cookedFood = null;
    }

    private void DeliverRightFood(Food food)
    {
        SoundManager.PlaySound.Invoke(2);
        m_playerStats.ApplyFoodEffect(food);
        Request();
    }

    private void DeliverWrongFood()
    {
        SoundManager.PlaySound.Invoke(3);
        InformationDisplay.SendDisplayText.Invoke("The client didn't ask for this.", Color.yellow);
    }

    private void Request() => RequestManager.PoolRequest.Invoke();

    private Food CreateFood()
    {
        var result = Mixing.Mix(m_ingredientsToCook, out Food food);
        if (result == false) { Debug.LogError("Couldn't create food."); return null; }
        return food;
    }
}