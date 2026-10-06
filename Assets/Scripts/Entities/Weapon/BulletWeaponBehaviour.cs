using UnityEngine;

namespace Midterm
{
    public class BulletWeaponBehaviour : IWeaponBehaviour
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;

        public BulletWeaponBehaviour(ShootInteractor _interactor)
        {
            shootInteractor = _interactor;
            shootPoint = _interactor.GetShootPoint();

            shootInteractor.GetWeaponRenderer().material.color = Color.green;

           
        }
        public void FireWeapon()
        {
           
            // - Get a pooled bullet from the object pool
            PooledObject pooledBullet = ObjectPool.Instance.GetPooledObject(ObjectPool.PoolType.Bullet);

            if (pooledBullet != null)
            {
                // - activate the pooled bullet
                pooledBullet.gameObject.SetActive(true);

                // - get pooled objects projectile scrip and initialize it
                ProjectileScript projectileScript = pooledBullet.GetComponent<ProjectileScript>();
                projectileScript.Initialize(shootInteractor.gameObject.tag);

                // get the rigidbody and set the position and rotation of the bullet
                Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;

                // - apply a force to the bullet
                bullet.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                // - recycle the bullet with object pool
                pooledBullet.DestroyWithTime(2f);
            }
            

            
        }

        
    }
}
