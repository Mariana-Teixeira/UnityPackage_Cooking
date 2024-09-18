using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private FoodConsumption m_foodConsumption;

    private void Awake()
    {
        m_foodConsumption = GetComponent<FoodConsumption>();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_foodConsumption.EatFood();
        }
    }
}
