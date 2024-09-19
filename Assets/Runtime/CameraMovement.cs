using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private const float SENSITIVITY = 5.0f;
    private const float CLAMP = 60f;

    private Transform m_cameraTransform;
    private Transform m_eyesTransform;

    private Vector2 m_mouseDelta;
    private float m_invertCamera = -1.0f;


    private void Awake()
    {
        m_cameraTransform = FindAnyObjectByType<Camera>().transform;
        m_eyesTransform = transform.Find("Eyes").transform;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        MoveCamera();
        RotateCamera();
        RotatePlayer();
    }

    float rotationX = 0.0f;
    private void RotateCamera()
    {
        rotationX += m_mouseDelta.y * SENSITIVITY * m_invertCamera * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -CLAMP, CLAMP);

        m_cameraTransform.rotation = m_eyesTransform.rotation;
        m_cameraTransform.rotation *= Quaternion.Euler(rotationX, 1f, 1f);
    }

    private void MoveCamera()
    {
        m_cameraTransform.position = m_eyesTransform.position;
    }

    float rotationY = 0.0f;
    private void RotatePlayer()
    {
        rotationY = m_mouseDelta.x * SENSITIVITY * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0f, rotationY, 0f);
    }

    public void OnLook(InputValue value) => m_mouseDelta = value.Get<Vector2>();
}