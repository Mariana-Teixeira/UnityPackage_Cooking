using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<string> GrabIngredient;
    [SerializeField]
    private UnityEvent DeliverAndRequest;
    [SerializeField]
    private UnityEvent TrashInventory;

    private FoodDelivery m_foodConsumption;
    private CharacterController m_characterController;
    private Camera m_camera;

    [SerializeField]
    private LayerMask m_rayMask;
    private float m_rayDistance = 2.0f;

    private Vector2 m_inputDirection = Vector2.zero;
    private Vector3 m_moveDirection = Vector2.zero;
    private float m_moveSpeed = 5.0f;

    private void Awake()
    {
        m_foodConsumption = GetComponent<FoodDelivery>();
        m_characterController = GetComponent<CharacterController>();
        m_camera = FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        MovePlayer();
    }



    private void MovePlayer()
    {
        m_moveDirection = transform.forward * m_inputDirection.y + transform.right * m_inputDirection.x;
        m_characterController.Move(m_moveDirection * m_moveSpeed * Time.deltaTime);
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

    public void OnMove(InputValue value) => m_inputDirection = value.Get<Vector2>();
    public void OnInteract() => PlayerInteraction();
}