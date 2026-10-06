using UnityEngine;

namespace Midterm
{
    public class TargetTrigger : MonoBehaviour
    {
        public Door door; // Door with assign

        public bool isHit = false;

        public void TargetHit()
        {
            if (isHit)
            {
                return;
            }

            Debug.Log("Target is hit");
            isHit = true;
            door.UnlockTarget(this);

        }
    }
}
