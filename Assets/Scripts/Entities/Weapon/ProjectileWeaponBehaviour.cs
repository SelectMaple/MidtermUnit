using UnityEngine;

namespace Midterm
{
    public class ProjectileWeaponBehaviour : IWeaponBehaviour
    {
        PlayerWeapon weaponScript;

        public ProjectileWeaponBehaviour(PlayerWeapon _weaponScript)
        {
            weaponScript = _weaponScript;
            // - change color of gun
           // _interactor.weaponReference.GetComponent<MeshRenderer>().material.color = Color.purple;
        }
        public void FireWeapon(Transform _inTransform)
        {
            Debug.Log("Firing projectile weapon");

        }
    }
}
