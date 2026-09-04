using UnityEngine;
using UnityEngine.InputSystem;

namespace Midterm
{
    public class PlayerWeapon : MonoBehaviour
    {
        IWeaponBehaviour currentWeapon;
        public GameObject shotPoint;

        public GameObject weaponReference;

        [SerializeField] InputActionReference switchProjectile;
        [SerializeField] InputActionReference switchRaycast;

        void Start()
        {
            SwitchWeapon(new ProjectileWeaponBehaviour(this));
        }

        void Update()
        {
            // new input system to fire weapon when mouse button is pressed


            // press key 1, switch to projectile behaviour
            if(switchProjectile.action.triggered)
            {
                SwitchWeapon(new ProjectileWeaponBehaviour(this));
            }


            // press key 2, switch to raycast behaviour
            if (switchRaycast.action.triggered)
            {
                SwitchWeapon(new RaycastWeaponBehaviour(this));
            }
         

        }

        public void SwitchWeapon(IWeaponBehaviour newWeapon)
        {
            currentWeapon = newWeapon;
            Debug.Log("Switched to weapon behaviour to: " + newWeapon.GetType().Name);
        }
    }
}
