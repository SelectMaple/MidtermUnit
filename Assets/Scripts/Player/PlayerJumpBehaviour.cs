using UnityEngine;

namespace Midterm
{
    [RequireComponent(typeof(PlayerMovementBehaviour))]
    public class PlayerJumpBehaviour : Interactor
    {
        [SerializeField] float _jumpVelocity = 10f;
        PlayerMovementBehaviour _playerMovementBeahviour;

        void Start()
        {
            _playerMovementBeahviour = GetComponent<PlayerMovementBehaviour>();
        }

        public override void Interact()
        {
            if (PlayerInput.Instance.jumpPressed && _playerMovementBeahviour.isGrounded)
            {
                _playerMovementBeahviour.SetYVelocity(_jumpVelocity);
            }
        }
    }
}
