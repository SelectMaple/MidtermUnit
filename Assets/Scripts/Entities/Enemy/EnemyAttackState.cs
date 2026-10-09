using UnityEngine;
using System.Collections;

namespace Midterm
{
    public class EnemyAttackState : EnemyState
    {
        

        public EnemyAttackState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {
            Debug.Log("Enemy has entered Attack State");
        }
        
        public override void OnStateExit()
        {
            Debug.Log("Attack exited");
        }

        public override void OnStateUpdate()
        {
            Debug.Log(" Attack updating....");

            //read distance between player
            float distance = Vector3.Distance(_controller.transform.position, _controller.target.transform.position);
            
            // go back to follow state if player is out of attack range
            if (distance > _controller.attackRange)
            {
                _controller.ChangeState(new EnemyFollowState(_controller));

            }

            // - shoot a projectile at the player
            if (_controller.canAttack)
            {
                // - get a pooled bulleted from the object pool
                PooledObject pooledBullet = ObjectPool.Instance.GetPooledObject(ObjectPool.PoolType.Bullet);

                if (pooledBullet != null)
                {
                    pooledBullet.gameObject.SetActive(true);

                    // - get pooled objects projectile script and initialize it
                    ProjectileScript projectileScript = pooledBullet.GetComponent<ProjectileScript>();
                    projectileScript.Initialize(_controller.gameObject.tag);

                    // get the rigidbody and set the position and rotation of the bullet
                    Rigidbody projectile = pooledBullet.GetComponent<Rigidbody>();
                    projectile.transform.position = _controller.projectileSpawnPoint.transform.position;

                    Vector3 shootPoint = (_controller.target.transform.position - _controller.projectileSpawnPoint.transform.position).normalized;

                    projectile.transform.rotation = Quaternion.LookRotation(shootPoint);
                    projectile.linearVelocity = shootPoint * 10f;

                    pooledBullet.DestroyWithTime(2f);

                }

                _controller.StartCoroutine(_controller.AttackDelay());
            }

            
        }

        
    }
}
