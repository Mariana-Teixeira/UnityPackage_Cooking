using UnityEngine;

namespace CookingSystem
{
        public readonly struct IdleState : IState
    {
        private readonly PlayerController _playerController;

        public IdleState(PlayerController controller)
        {
            _playerController = controller;
        }

        public void OnEnter()
        {
            Debug.Log("Idle State");
        }

        public void Update()
        { }

        public void OnExit()
        { }
    }

    public readonly struct GrabState : IState
    {
        private readonly PlayerController _playerController;

        public GrabState(PlayerController controller)
        {
            _playerController = controller;
        }

        public void OnEnter()
        {
            Debug.Log("Grab State");
            _playerController.Grab();
        }

        public void Update()
        { }

        public void OnExit()
        { }
    }

    public readonly struct UseState : IState
    {
        private readonly PlayerController _playerController;
        
        public UseState(PlayerController controller)
        {
            _playerController = controller;
        }

        // TODO: OnClearInteraction is causing some minor issues.
        public void OnEnter()
        {
            Debug.Log("Use State");
            _playerController.Use();
        }

        public void Update()
        { }

        public void OnExit()
        { }
    }

    public readonly struct StoreState : IState
    {
        private readonly PlayerController _playerController;
        
        public StoreState(PlayerController controller)
        {
            _playerController = controller;
        }

        // TODO: OnClearInteraction is causing some minor issues.
        public void OnEnter()
        {
            Debug.Log("Store State");
            _playerController.Store();
        }

        public void Update()
        { }

        public void OnExit()
        { }
    }

    public readonly struct DropState : IState
    {
        private readonly PlayerController _playerController;

        public DropState(PlayerController controller)
        {
            _playerController = controller;
        }
        
        public void OnEnter()
        {
            Debug.Log("Drop State");
            _playerController.Drop();
        }

        public void Update()
        { }

        public void OnExit()
        { }
    }   
}