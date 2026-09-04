using UnityEngine;

namespace Midterm
{
    public class RaycastWeaponBehaviour : IWeaponBehaviour
    {
        PlayerWeapon weaponScript;

        public RaycastWeaponBehaviour(PlayerWeapon _weaponScript)
        {
            weaponScript = _weaponScript;

            // - change color of gun
            //_interactor.weaponReference.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        public void FireWeapon(Transform _inTransform)
        {
            Debug.Log("Firing raycast weapon");
        }
    }
}
