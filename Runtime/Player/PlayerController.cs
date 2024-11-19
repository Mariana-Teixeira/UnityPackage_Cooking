using UnityEngine;
using UnityEngine.InputSystem;
using CookingSystem;

namespace CookingSystem
{
    public class PlayerController : MonoBehaviour
{
    private StateMachine _stateMachine;
    
    private PlayerMovement _playerMovement;
    private PlayerInteraction _playerInteraction;

    private Vector2 _mouseDelta;
    private Vector2 _inputDirection;
    
    [SerializeField] private float _rayDistance;
    [SerializeField] private float _moveSpeed;

    private Collider _interacted;
    private IGrab _holdingObject;

    private IGrab _interactedGrab => _interacted ? _interacted.GetComponent<IGrab>() : null;
    private IContainer _interactContainer => _interacted ? _interacted.GetComponent<IContainer>() : null;
    private IStatic _interactedStatic => _interacted ? _interacted.GetComponent<IStatic>() : null;
    private bool IsInteractingWithHoldingObject => _interactedGrab.GetHashCode() == _holdingObject.GetHashCode();
    
    private void Awake()
    {
        #region State Machine
        _stateMachine = new StateMachine();
        var idle = new IdleState(this);
        var grab = new GrabState(this);
        var use = new UseState(this);
        var store = new StoreState(this);
        var drop = new DropState(this);
        _stateMachine.AddTransition(idle, grab, new Predicate(() => _interactedGrab != null));
        _stateMachine.AddTransition(idle, use, new Predicate(() => _interactedStatic != null));
        _stateMachine.AddTransition(grab, store, new Predicate(() => _interactContainer != null && (_interactedGrab == null || !IsInteractingWithHoldingObject)));
        _stateMachine.AddTransition(store, drop, new Predicate(() => true));
        _stateMachine.AddTransition(drop, idle, new Predicate(() => true));
        _stateMachine.AddTransition(use, idle, new Predicate(() => true));
        _stateMachine.SetState(idle);
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
        _playerMovement.Update(transform, _moveSpeed, _inputDirection, _mouseDelta);
        _stateMachine.Evaluate();
    }
    
    public void Grab()
    {
        _holdingObject = _interactedGrab;
        _holdingObject.Grab();
    }

    public void Use()
    {
        _interactedStatic.Use();
        _interacted = null;
    }

    public void Store()
    {
        _interactContainer.Store(_holdingObject);
        _interacted = null;
    }
    
    public void Drop()
    {
        _holdingObject.Drop();
        _holdingObject = null;
        _interacted = null;
    }

    public void OnMove(InputValue value) => _inputDirection = value.Get<Vector2>();
    public void OnLook(InputValue value) => _mouseDelta = value.Get<Vector2>();
    public void OnInteract() => _interacted = _playerInteraction.GetInteracted;
}
}