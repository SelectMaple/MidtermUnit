using UnityEngine;

namespace Midterm
{
    public class EnemyBullet : MonoBehaviour
    {
        public float speed = 3f;
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

            Destroy(this.gameObject);
        }
    }
}
