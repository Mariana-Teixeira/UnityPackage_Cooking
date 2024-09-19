using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int m_money = 0;
    private int m_reputation = 0;

    public void ApplyFoodEffect(Food food)
    {
        GainIngredientValue(food);
        food.ApplyEffect();
    }

    public void GainReputation(Food food)
    {
        var add = food.FoodEffect.EffectValue;
        m_reputation += add;
    }

    private void GainIngredientValue(Food food)
    {
        var add = Mixing.GetPoints(food);
        m_money += add;
    }
}
