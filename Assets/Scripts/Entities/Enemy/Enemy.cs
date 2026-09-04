using UnityEngine;
using UnityEngine.AI;

namespace Midterm
{
    public class Enemy : MonoBehaviour
    {
        Health health;
        [SerializeField] Transform _targetPosition;
        NavMeshAgent _agent;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            
        }

        void Update()
        {
            _agent.destination = _targetPosition.position;
        }

        public void GetDamage(float damage)
        {
            health.TakeDamage(damage);
            if (health.currentHealth <= 0f)
                Die();
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
