using System.Collections;
using UnityEngine;

namespace Midterm
{
    public class EnemyController : MonoBehaviour
    {
        // - Enemy Properties
        public float moveSpeed = 3f;
        public float attackRange = 3f;
        public float detectionRange = 10f;
        public bool canAttack = true;

        // - Player
        public GameObject target = null;

        // - Combat 
        public GameObject projectilePrefab = null;
        public GameObject projectileSpawnPoint = null;


        // - Enemy states
        EnemyState currentState = null;

        void Start()
        {
            ChangeState(new EnemyIdleState(this));
          
        }

        void Update()
        {
            if(currentState != null)
                currentState.OnStateUpdate();
        }

        public void ChangeState(EnemyState newState)
        {
            // - Call the current state's OnStateExit method before changing state
            if(currentState != null)
                currentState.OnStateExit();

            // - Set new state
            currentState = newState;

            // - Call the new state's OnStateEntered method
            currentState.OnStateEntered();


        }

        public IEnumerator AttackDelay()
        {
            canAttack = false;

            yield return new WaitForSeconds(2f);

            canAttack = true;
        }

}
}
