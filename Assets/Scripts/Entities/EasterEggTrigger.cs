using UnityEngine;

namespace Midterm
{
    public class EasterEggTrigger : MonoBehaviour
    {
        [SerializeField] Collider collider;

        bool isHit = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (isHit)
            {
                return;
            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                isHit = true;

                if (collider != null)
                {
                    Debug.Log("SECRET ROOM HAS BEEN OPENED SOMEWHERE");
                    collider.enabled = false;
                }
            }
        }
    }
}
