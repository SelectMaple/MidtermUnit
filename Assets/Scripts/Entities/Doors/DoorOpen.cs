using UnityEngine;

namespace Midterm
{
    public class DoorOpen : MonoBehaviour
    {
        Animator animator;
        bool unlocks;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            DoorOpenClose();
        }

        void DoorOpenClose()
        {
            bool openDoor = true;
            if (!unlocks)
            {
                openDoor = false;
            }
            

            if (openDoor)
            {
                animator.Play("OpenClose", 0, Mathf.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 0f, 1f));
                animator.SetFloat("Speed", 1f);
            }
            else
            {
                animator.Play("OpenClose", 0, Mathf.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 0f, 1f));
                animator.SetFloat("Speed", -1f);
            }
        }
    }
}
