using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const int MAXIMUM_HEALTH = 5;
    private const int MAXIMUM_STAMINA = 5;

    private int m_health = 0;
    private int m_stamina = 0;
    private int m_strength = 0;

    private List<Food> m_foodStored = new List<Food>();

    [SerializeField]
    private MixManager m_mixManager;

    public void AddHealth(int add)
    {
        var sum = m_health + add;
        m_health = sum > MAXIMUM_HEALTH ? MAXIMUM_HEALTH : sum;
    }

    public void AddStamina(int add)
    {
        var sum = m_stamina + add;
        m_stamina = sum > MAXIMUM_STAMINA ? MAXIMUM_STAMINA : sum;
    }

    public void AddStrength(int add)
    {
        var sum = m_strength + add;
        m_strength = sum;
    }

    Food food;
    public void CreateFood()
    {
        var result = m_mixManager.Mix(out food);
        if (result == true) m_foodStored.Add(food);
        else Debug.LogError("Unable to Create Food");
    }

    public void EatFood()
    {
        var eatenFood = m_foodStored.First();
    }
}