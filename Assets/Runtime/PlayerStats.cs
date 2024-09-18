using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const int MAXIMUM_HEALTH = 5;
    private const int MAXIMUM_STAMINA = 5;

    private int m_health;
    private int m_stamina;

    private List<Food> m_foodStored = new List<Food>();

    [SerializeField]
    private MixManager m_mixManager;

    public static Action<int> AddHealth;
    public static Action<int> AddStamina;

    private void OnEnable()
    {
        AddHealth += OnAddHealth;
        AddStamina += OnAddStamina;
    }

    private void OnDisable()
    {
        AddHealth -= OnAddHealth;
        AddStamina -= OnAddStamina;
    }

    public void OnAddHealth(int add)
    {
        var sum = m_health + add;
        m_health = sum > MAXIMUM_HEALTH ? MAXIMUM_HEALTH : sum;
    }

    public void OnAddStamina(int add)
    {
        var sum = m_stamina + add;
        m_stamina = sum > MAXIMUM_STAMINA ? MAXIMUM_STAMINA : sum;
    }

    Food food;
    public void CreateFood()
    {
        var result = m_mixManager.Mix(out food);
        if (result == true) m_foodStored.Add(food);
        else Debug.LogError("Unable to Create Food");
    }
}