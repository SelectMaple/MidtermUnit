using UnityEngine;
using UnityEngine.InputSystem;

namespace Midterm
{
    [DefaultExecutionOrder(-100)]
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput Instance { get; private set; }

        public float horizontalInput { get; private set; }
        public float verticalInput { get; private set; }
        public float mouseX { get; private set; }
        public float mouseY { get; private set; }

        public bool sprintHeld { get; private set; }
        public bool jumpPressed { get; private set; }
        public bool activatePressed { get; private set; }

        public bool primaryShootPressed { get; private set; }
        public bool secondaryShootPressed { get; private set; }

        public bool alpha1Pressed { get; private set; }
        public bool alpha2Pressed { get; private set; }

        public bool commandPressed { get; private set;  }
        public bool recallPressed { get; private set;  }

        // - Pause Game Button
        public bool escPressed {  get; private set; }

        [Header("InputActions")]
        [SerializeField] InputActionReference moveAction;
        [SerializeField] InputActionReference lookAction;
        [SerializeField] InputActionReference sprintAction;
        [SerializeField] InputActionReference jumpAction;
        [SerializeField] InputActionReference activateAction;
        [SerializeField] InputActionReference primaryShootAction;
        [SerializeField] InputActionReference secondaryShootAction;
        [SerializeField] InputActionReference alpha1Action;
        [SerializeField] InputActionReference alpha2Action;
        [SerializeField] InputActionReference commandAction;
        [SerializeField] InputActionReference recallAction;
        [SerializeField] InputActionReference escAction;



        bool clear;
        

        void Awake()
        {
            // - SINGLETON PATTERN - set the singleton static reference if it has not been set yet
            if (Instance == null)
            {
                Instance = this;
            }
            
            // - SINGLETON PATTERN - destroy any other copies of our singleton class reference
            else if (Instance != null)
            {
                Destroy(this.gameObject);
            }
        }

        void OnEnable()
        {
            moveAction.action.Enable();
            lookAction.action.Enable();
            sprintAction.action.Enable();
            jumpAction.action.Enable();
            activateAction.action.Enable();
            primaryShootAction.action.Enable();
            secondaryShootAction.action.Enable();

            alpha1Action.action.Enable();
            alpha2Action.action.Enable();
            commandAction.action.Enable();
            recallAction.action.Enable();
            escAction.action.Enable();
        }

        void OnDisable()
        {
            moveAction.action.Disable();
            lookAction.action.Disable();
            sprintAction.action.Disable();
            jumpAction.action.Disable();
            activateAction.action.Disable();
            primaryShootAction.action.Disable();
            secondaryShootAction.action.Disable();

            alpha1Action.action.Disable();
            alpha2Action.action.Disable();
            commandAction.action.Disable();
            recallAction.action.Disable();
            escAction.action.Disable();
        }

        void Update()
        {
            ClearInputs();
            ProcessInputs();
        }

        void LateUpdate()
        {
            clear = true;
        }

        void ProcessInputs()
        {
            // - Order of operations: escPressed is above the GameState to avoid esc button not being returned
            // - Pausing game button
            escPressed |= escAction.action.WasPressedThisFrame();

            if (GameManager.instance.currentGameState != GameManager.GameState.GamePlaying) return;

            Vector2 move = moveAction.action.ReadValue<Vector2>();
            Vector2 look = lookAction.action.ReadValue<Vector2>();

            horizontalInput = move.x;
            verticalInput = move.y;

            mouseX = look.x;
            mouseY = look.y;

            sprintHeld = sprintAction.action.IsPressed();

            jumpPressed = jumpAction.action.WasPressedThisFrame();

            activatePressed = activateAction.action.WasPressedThisFrame();

            primaryShootPressed |= primaryShootAction.action.WasPressedThisFrame();
            secondaryShootPressed |= secondaryShootAction.action.WasPressedThisFrame();

            alpha1Pressed |= alpha1Action.action.WasPressedThisFrame();
            alpha2Pressed |= alpha2Action.action.WasPressedThisFrame();

            commandPressed |= commandAction.action.WasPressedThisFrame();
            recallPressed |= recallAction.action.WasPressedThisFrame();
            
        }

        

        void ClearInputs()
        {
            if (!clear)
                return;

            horizontalInput = 0;
            verticalInput = 0;
            mouseX = 0;
            mouseY = 0;

            sprintHeld = false;
            jumpPressed = false;
            activatePressed = false;

            primaryShootPressed = false;
            secondaryShootPressed = false;

            alpha1Pressed = false;
            alpha2Pressed = false;

            commandPressed = false;
            recallPressed = false;

            escPressed = false;

            clear = false;
        }
    }
}
