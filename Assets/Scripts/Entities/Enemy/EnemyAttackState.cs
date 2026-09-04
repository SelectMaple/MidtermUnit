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
            _controller.gameObject.transform.LookAt(_controller.target.transform.position);

            // go back to follow state if player is out of attack range
            if (distance > _controller.attackRange)
            {
                _controller.ChangeState(new EnemyFollowState(_controller));
            }
                
            // - shoot a projectile at the player
            if (_controller.canAttack)
            {
                GameObject bullet = GameObject.Instantiate(_controller.projectilePrefab, _controller.projectileSpawnPoint.transform.position, _controller.transform.rotation);
                    
                _controller.StartCoroutine(_controller.AttackDelay());
            }

            
        }

        
    }
}
