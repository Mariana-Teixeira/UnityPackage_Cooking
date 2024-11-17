using UnityEngine;
using UnityEngine.InputSystem;

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
    private IUse _interactedUse => _interacted ? _interacted.GetComponent<IUse>() : null;
    
    private void Awake()
    {
        #region State Machine
        _stateMachine = new StateMachine();
        var empty = new EmptyState(this);
        var grab = new GrabState(this);
        var use = new UseState(this);
        _stateMachine.AddTransition(empty, grab, new Predicate(() => _interactedGrab != null));
        _stateMachine.AddTransition(grab, empty, new Predicate(() => _interactedGrab != null && _holdingObject != null && _interactedGrab.GetType() == _holdingObject.GetType()));
        _stateMachine.AddTransition(grab, use, new Predicate(() => _interactedUse != null));
        _stateMachine.AddTransition(use, empty, new Predicate(() => _interactedGrab == null && _interactedUse == null));
        _stateMachine.SetState(empty);
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

    public void Drop()
    {
        _holdingObject.Drop();
        _holdingObject = null;
    }

    public void Use()
    {
        _interactedUse.Use(_holdingObject);
    }

    public void OnMove(InputValue value) => _inputDirection = value.Get<Vector2>();
    public void OnLook(InputValue value) => _mouseDelta = value.Get<Vector2>();
    public void OnInteract() => _interacted = _playerInteraction.GetInteracted;
    public void OnClearInteract() => _interacted = null;
}