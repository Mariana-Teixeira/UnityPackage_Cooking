using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const float SENSITIVITY = 5.0f;
    private const float CLAMP = 60f;

    private CharacterController m_characterController;
    private Transform m_cameraTransform;

    private Vector2 m_inputDirection = Vector2.zero;
    private Vector3 m_moveDirection = Vector2.zero;
    private float m_moveSpeed = 5.0f;

    private Vector2 m_mouseDelta;
    private float m_invertCamera = -1.0f;


    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
        m_cameraTransform = FindAnyObjectByType<Camera>().transform;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
        RotateCamera();
    }

    private void MovePlayer()
    {
        m_moveDirection = transform.forward * m_inputDirection.y + transform.right * m_inputDirection.x;
        m_characterController.Move(m_moveDirection * m_moveSpeed * Time.deltaTime);
    }

    private float m_rotationX = 0.0f;
    private void RotateCamera()
    {
        m_rotationX += m_mouseDelta.y * SENSITIVITY * m_invertCamera * Time.deltaTime;
        m_rotationX = Mathf.Clamp(m_rotationX, -CLAMP, CLAMP);
        m_cameraTransform.localRotation = Quaternion.Euler(m_rotationX, 0f, 0f);
    }

    float rotationY = 0.0f;
    private void RotatePlayer()
    {
        rotationY = m_mouseDelta.x * SENSITIVITY * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationY);
    }

    public void OnMove(InputValue value) => m_inputDirection = value.Get<Vector2>();
    public void OnLook(InputValue value) => m_mouseDelta = value.Get<Vector2>();
}