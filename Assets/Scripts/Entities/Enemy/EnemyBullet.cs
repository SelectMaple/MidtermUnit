using UnityEngine;

namespace Midterm
{
    public class EnemyBullet : MonoBehaviour
    {
        public float speed = 3f;
        public float damage = 10f;

        void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Debug.Log("Player Hit");
            }

            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
               
            
            Destroy(this.gameObject);
            
                
        }
    }
}
