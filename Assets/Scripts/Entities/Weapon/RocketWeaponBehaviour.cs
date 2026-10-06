using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class RocketWeaponBehaviour : IWeaponBehaviour
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;

        public RocketWeaponBehaviour(ShootInteractor _interactor)
        {
            shootInteractor = _interactor;
            shootPoint = _interactor.GetShootPoint();

            shootInteractor.GetWeaponRenderer().material.color = Color.pink;


        }
        public void FireWeapon()
        {

            // - grab the first available bullet from our object pool
            PooledObject pooledRocket = ObjectPool.Instance.GetPooledObject(ObjectPool.PoolType.Rocket);
            
            if(pooledRocket != null)
            {
                // - activate the pooled rocket
               // pooledRocket.gameObject.SetActive(true);

                // - get pooled objects projectile script and intialize it
                ProjectileScript projectileScript = pooledRocket.GetComponent<ProjectileScript>();
                projectileScript.Initialize(shootInteractor.gameObject.tag);

                // get the rigidbody and set the position and rotation of the bullet
                Rigidbody bullet = pooledRocket.GetComponent<Rigidbody>();
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;

                // - apply a force to the bullet
                bullet.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                // - recycle the bullet with object pool
                pooledRocket.DestroyWithTime(2f);
            }
            
            
            
        }
    }
}
