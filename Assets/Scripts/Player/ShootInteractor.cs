using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class ShootInteractor : Interactor
    {
        [SerializeField] Input _inputType;

        [Header("Shoot")]
        [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootVelocity;
        [SerializeField] Transform _shootPoint;
        [SerializeField] PlayerMovementBehaviour _playerMovementBehaviour;

        // - Strategy pattern
        private IWeaponBehaviour currentWeapon;

        public float damage = 10f;

        // private variable
        float _finalShootVelocity;

        
        public override void Interact()
        {
            if (_inputType == Input.Primary && _input.primaryShootPressed|| _inputType == Input.Secondary && _input.secondaryShootPressed)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            _finalShootVelocity = _playerMovementBehaviour.GetForwardSpeed() + _shootVelocity;

            Rigidbody bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.linearVelocity = _shootPoint.forward * _finalShootVelocity;
            Destroy(bullet.gameObject, 7f); // remove once object pooling is added
        }

        public void SwitchWeapon(IWeaponBehaviour newWeapon)
        {
            currentWeapon = newWeapon;
            Debug.Log("Switched to weapon behaviour to: " + newWeapon.GetType().Name);
        }

       
    }

    public enum Input
    {
        Primary,
        Secondary
    }
}
