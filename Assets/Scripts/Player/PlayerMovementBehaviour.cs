using UnityEngine;

namespace Midterm
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] PlayerInput _input;
        [Header("PlayerMovement")]
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _gravity = -9.81f;
        [SerializeField] float _sprintMultiplier = 1.5f;


        [Header("Ground Check")]
        [SerializeField] Transform _groundCheck;
        [SerializeField] LayerMask _groundMask;
        [SerializeField] float _groundCheckDistance = 0.2f;

        CharacterController _characterController;
        Vector2 _playerVelocity;
        public bool isGrounded { get; private set; }

        private float _moveMultiplier = 1f;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            GroundCheck();
            MovePlayer();
        }

        void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance, _groundMask);
        }

        void MovePlayer()
        {
            //sprint
            _moveMultiplier = _input.sprintHeld ? _sprintMultiplier: 1f;

            //movement
            Vector3 move = transform.forward * _input.verticalInput + transform.right * _input.horizontalInput;

            _characterController.Move(move * _moveSpeed * _moveMultiplier * Time.deltaTime);

            //keep Player grounded
            if(isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }

            //Gravity 
            _playerVelocity.y += _gravity * Time.deltaTime;

            //Vertical movement
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        public void SetYVelocity(float value)
        {
            _playerVelocity.y = value;
        }

        public float GetForwardSpeed()
        {
            return _input.verticalInput * _moveSpeed * _moveMultiplier;
        }
    }
}
