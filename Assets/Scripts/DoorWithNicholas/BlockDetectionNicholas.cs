using UnityEngine;
using System.Collections.Generic;

namespace Midterm
{
    public class BlockDetectionNicholas : MonoBehaviour
    {
        public DoorNicholas door; // Door with assign

        List<Collider> blocks = new List<Collider>();

        private void OnTriggerEnter(Collider other)
        {
            if (!door)
            {
                Debug.LogWarning(transform.parent.name + " does not have a door"); 
                return;
            }
            
            blocks.Add(other);
            door.Unlock(this);
        }

        private void OnTriggerExit(Collider other)
        {
            blocks.Remove(other);
            if( blocks.Count == 0)
            {
                door.Lock(this);
            }
        }
    }
}
