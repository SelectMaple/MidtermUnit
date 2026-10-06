using UnityEngine;
using System.Collections;

namespace Midterm
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] string openTag = "Player";
        [SerializeField] Animator animator;

        [SerializeField] Door door;
        float delayTime = 3f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(openTag))
            {
                animator.SetBool("OpenClose", true);
                door.DoorOpenClose();
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(openTag))
            {
                StartCoroutine(TimeDelay());
            }
        }

        IEnumerator TimeDelay()
        {

            yield return new WaitForSeconds(delayTime);
            animator.SetBool("OpenClose", false);
        }
    }
}
