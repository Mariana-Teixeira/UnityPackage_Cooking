using UnityEngine;

public class PlayerMovement
{
    private const float m_mouseSensitivity = 8.0f;
    private const float m_mouseSpeed = 8.0f;
    private const float m_rotationClamp = 60f;
    private const float m_invertCamera = -1.0f;

    private readonly CharacterController m_characterController;
    private readonly Transform m_cameraTransform;
    
    private Vector3 m_moveDirection;

    private float m_rotationY;
    private float m_rotationX;

    public PlayerMovement(CharacterController characterController, Transform cameraTransform)
    {
        m_characterController = characterController;
        m_cameraTransform = cameraTransform;
    }

    public void Update(Transform playerTransform, float speed, Vector2 inputDirection, Vector2 mouseDelta)
    {
        MovePlayer(playerTransform, speed, inputDirection);
        RotatePlayer(playerTransform, mouseDelta);
        RotateCamera(mouseDelta);
    }

    private void MovePlayer(Transform transform, float moveSpeed, Vector2 inputDirection)
    {
        m_moveDirection = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        m_characterController.Move(m_moveDirection * (moveSpeed * Time.deltaTime));
    }
    
    private void RotatePlayer(Transform transform, Vector2 mouseDelta)
    {
        m_rotationY = mouseDelta.x * m_mouseSensitivity * Time.deltaTime;
        m_rotationY = Mathf.Clamp(m_rotationY, -m_mouseSpeed, m_mouseSpeed);
        transform.Rotate(Vector3.up * m_rotationY);
    }

    private void RotateCamera(Vector2 mouseDelta)
    {
        m_rotationX += mouseDelta.y * m_mouseSensitivity * m_invertCamera * Time.deltaTime;
        m_rotationX = Mathf.Clamp(m_rotationX, -m_rotationClamp, m_rotationClamp);
        m_cameraTransform.localRotation = Quaternion.Euler(m_rotationX, 0f, 0f);
    }
}