using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public IInteractable Interactable;
    
    private StateMachine _stateMachine;
    
    private PlayerMovement _playerMovement;
    private PlayerInteraction _playerInteraction;

    private Vector2 _mouseDelta;
    private Vector2 _inputDirection;
    
    [SerializeField] private float _rayDistance;
    [SerializeField] private float _moveSpeed;
    
    private void Awake()
    {
        #region State Machine
        _stateMachine = new StateMachine();
        var emptyHanded = new EmptyHanded();
        var grabIngredient = new GrabState<Storage>(this);
        var grabTray = new GrabState<Tray>(this);
        var ingredientOnTray = new DropOnState<Ingredient, Tray>(this);
        var trayOnAppliance = new DropOnState<Tray, Appliance>(this);
        _stateMachine.AddTransition(emptyHanded, grabIngredient, new CompareCondition<Type>(typeof(Storage)));
        _stateMachine.AddTransition(grabIngredient, ingredientOnTray, new CompareCondition<Type>(typeof(Tray)));
        _stateMachine.AddTransition(ingredientOnTray, emptyHanded, new InvokeCondition(() => true));
        _stateMachine.SetState(emptyHanded);
        #endregion
        
        var layerMask = LayerMask.GetMask("Interactable");
        var playerCamera = FindAnyObjectByType<Camera>();
        _playerInteraction = new PlayerInteraction(playerCamera, layerMask, _rayDistance);
        
        var characterController = GetComponent<CharacterController>();
        var cameraTransform = FindAnyObjectByType<Camera>().transform;
        _playerMovement = new PlayerMovement(characterController, cameraTransform);
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _playerInteraction.Update();
        _playerMovement.Update(this.transform, _moveSpeed, _inputDirection, _mouseDelta);
    }
    
    public void CheckConditions()
    {
        if (Interactable == null) return;
        _stateMachine.Compare(Interactable.GetType());
    }
    
    public void OnMove(InputValue value) => _inputDirection = value.Get<Vector2>();
    public void OnLook(InputValue value) => _mouseDelta = value.Get<Vector2>();

    public void OnInteract()
    {
        Interactable = _playerInteraction.GetInteracted();
        CheckConditions();
    }
}