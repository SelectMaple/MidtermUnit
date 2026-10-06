using UnityEngine;
using System.Collections.Generic;

namespace Midterm
{
    public class BlockDetection : MonoBehaviour
    {
        public Door door; // Door with assign

        List<Collider> blocks = new List<Collider>();

        private void OnTriggerEnter(Collider other)
        {
            if (!door)
            {
                return;
            }
            
            blocks.Add(other);
            door.UnlockBlocks(this);
        }

        private void OnTriggerExit(Collider other)
        {
            blocks.Remove(other);
            if( blocks.Count == 0)
            {
                door.LockBlocks(this);
            }
        }
    }
}
