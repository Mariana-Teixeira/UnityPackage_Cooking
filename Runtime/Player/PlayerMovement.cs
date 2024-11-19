using UnityEngine;

public class PlayerMovement
{
    private const float _mouseSensitivity = 8.0f;
    private const float _mouseSpeed = 8.0f;
    private const float _rotationClamp = 60f;
    private const float _invertCamera = -1.0f;

    private readonly CharacterController _characterController;
    private readonly Transform _cameraTransform;
    
    private Vector3 _moveDirection;

    private float _rotationY;
    private float _rotationX;

    public PlayerMovement(CharacterController characterController, Transform cameraTransform)
    {
        _characterController = characterController;
        _cameraTransform = cameraTransform;
    }

    public void Update(Transform playerTransform, float speed, Vector2 inputDirection, Vector2 mouseDelta)
    {
        MovePlayer(playerTransform, speed, inputDirection);
        RotatePlayer(playerTransform, mouseDelta);
        RotateCamera(mouseDelta);
    }

    private void MovePlayer(Transform transform, float moveSpeed, Vector2 inputDirection)
    {
        _moveDirection = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        _characterController.Move(_moveDirection * (moveSpeed * Time.deltaTime));
    }
    
    private void RotatePlayer(Transform transform, Vector2 mouseDelta)
    {
        _rotationY = mouseDelta.x * _mouseSensitivity * Time.deltaTime;
        _rotationY = Mathf.Clamp(_rotationY, -_mouseSpeed, _mouseSpeed);
        transform.Rotate(Vector3.up * _rotationY);
    }

    private void RotateCamera(Vector2 mouseDelta)
    {
        _rotationX += mouseDelta.y * _mouseSensitivity * _invertCamera * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, -_rotationClamp, _rotationClamp);
        _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}