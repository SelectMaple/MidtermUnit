using UnityEngine;

namespace Midterm
{
    public class ProjectileScript : MonoBehaviour
    {
        string ownershipTag = "";
        float damage = 10f;

        public void Initialize(string _ownershipTag)
        {
            ownershipTag = _ownershipTag;
        }

        private void OnCollisionEnter(Collision collision)
        {
            TargetTrigger target = collision.gameObject.GetComponent<TargetTrigger>();

            if(target != null)
            {
                target.TargetHit();
            }

            // - use Enemy Tag
            if (!collision.gameObject.CompareTag(ownershipTag))
            {
                Health health = collision.gameObject.GetComponent<Health>();
                {
                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }
                }
            
            }

            // - remove the bullet if it hits something
            PooledObject pooledObject = GetComponent<PooledObject>();

            if (pooledObject != null)
            {
                pooledObject.ResetObject();
            }

            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
