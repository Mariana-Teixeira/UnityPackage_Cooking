using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodConsumption : MonoBehaviour
{
    private const int MAXIMUM_HEALTH = 5;
    private const int MAXIMUM_STAMINA = 5;

    private int m_health = 0;
    private int m_stamina = 0;
    private int m_strength = 0;

    private MixManager m_mixManager;
    private List<Food> m_foodStored = new List<Food>();

    private void Awake()
    {
        m_mixManager = FindAnyObjectByType<MixManager>();
    }

    private void RecoverHealth(Food food)
    {
        var add = SumHealthPoints(food);

        Debug.Log("Recover Health: " + add);

        var sum = m_health + add;
        m_health = sum > MAXIMUM_HEALTH ? MAXIMUM_HEALTH : sum;
    }

    public void RecoverStamina(Food food)
    {
        var add = food.FoodEffect.Value;

        Debug.Log("Recover Stamina: " + add);

        var sum = m_stamina + add;
        m_stamina = sum > MAXIMUM_STAMINA ? MAXIMUM_STAMINA : sum;
    }

    public void RecoverStrength(Food food)
    {
        var add = food.FoodEffect.Value;

        Debug.Log("Recover Strength: " + add);

        var sum = m_strength + add;
        m_strength = sum;
    }

    public void CreateFood()
    {
        var result = m_mixManager.Mix(out Food food);
        if (result == true) m_foodStored.Add(food);
        else Debug.LogError("Unable to Create Food");
    }

    public void EatFood()
    {
        var eatenFood = m_foodStored.First();        
        RecoverHealth(eatenFood);
        eatenFood.ApplyEffect();
        m_foodStored.Remove(eatenFood);
    }

    public int SumHealthPoints(Food food)
    {
        var addToHealth = 0;
        foreach (var ingredient in food.IngredientsUsed) addToHealth += ingredient.HealthRecovery;
        return addToHealth;
    }
}