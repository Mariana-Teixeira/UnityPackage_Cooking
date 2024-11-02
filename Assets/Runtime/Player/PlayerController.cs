using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement m_playerMovement;
    private PlayerInteraction m_playerInteraction;

    private Vector2 m_mouseDelta;
    private Vector2 m_inputDirection;

    [SerializeField] private float m_rayDistance;
    [SerializeField] private float m_moveSpeed;
    
    private void Awake()
    {
        var layerMask = LayerMask.GetMask("Interactable");
        var playerCamera = FindAnyObjectByType<Camera>();
        m_playerInteraction = new PlayerInteraction(playerCamera, layerMask, m_rayDistance);
        
        var characterController = GetComponent<CharacterController>();
        var cameraTransform = FindAnyObjectByType<Camera>().transform;
        m_playerMovement = new PlayerMovement(characterController, cameraTransform);
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        m_playerInteraction.Update();
        m_playerMovement.Update(this.transform, m_moveSpeed, m_inputDirection, m_mouseDelta);
    }
    
    public void OnMove(InputValue value) => m_inputDirection = value.Get<Vector2>();
    public void OnLook(InputValue value) => m_mouseDelta = value.Get<Vector2>();
    public void OnInteract() => m_playerInteraction.Interact();
}