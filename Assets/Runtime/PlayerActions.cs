using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// TODO: Comment my code.
public class PlayerActions : MonoBehaviour
{
    private FoodDelivery m_foodDelivery;
    private Camera m_camera;

    [SerializeField]
    private LayerMask m_rayMask;
    private float m_rayDistance = 1.0f;

    private UnityEvent<string> GrabIngredient = new UnityEvent<string>();
    private UnityEvent DeliverAndRequest = new UnityEvent();
    private UnityEvent TrashInventory = new UnityEvent();

    private void Awake()
    {
        m_foodDelivery = GetComponent<FoodDelivery>();
        m_camera = FindAnyObjectByType<Camera>();
    }

    private void OnEnable()
    {
        GrabIngredient.AddListener(m_foodDelivery.GrabIngredient);
        DeliverAndRequest.AddListener(m_foodDelivery.DeliverAndRequestFood);
        TrashInventory.AddListener(m_foodDelivery.Trash);
    }

    private void OnDisable()
    {
        GrabIngredient.RemoveListener(m_foodDelivery.GrabIngredient);
        DeliverAndRequest.RemoveListener(m_foodDelivery.DeliverAndRequestFood);
        TrashInventory.RemoveListener(m_foodDelivery.Trash);
    }

    private void PlayerInteraction()
    {
        var centerViewport = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        var _lookingAtRay = m_camera.ScreenPointToRay(centerViewport);

        if (Physics.Raycast(_lookingAtRay, out RaycastHit hit, m_rayDistance, m_rayMask))
        {
            if (hit.collider.CompareTag("FoodStorage"))
            {
                var objectName = hit.collider.name;
                GrabIngredient.Invoke(objectName);
            }
            else if (hit.collider.CompareTag("Requester"))
            {
                DeliverAndRequest.Invoke();
            }
            else if (hit.collider.CompareTag("Trash"))
            {
                TrashInventory.Invoke();
            }
        }
    }
    public void OnInteract() => PlayerInteraction();
}