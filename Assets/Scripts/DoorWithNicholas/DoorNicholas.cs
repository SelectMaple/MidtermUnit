using System;
using UnityEngine;

namespace Midterm
{
    public class DoorNicholas : MonoBehaviour
    {
        [SerializeField] BlockDetectionNicholas[] blockDetectors;
        [SerializeField] Renderer[] unlockLights;

        Animator animator;

        bool[] unlocks;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            foreach (BlockDetectionNicholas blockDetector in blockDetectors)
            {
                blockDetector.door = this;
            }

            foreach (Renderer light in unlockLights)
            {
                light.material.SetColor("_EmissionColor", Color.red * 20f);
            }

            unlocks = new bool[blockDetectors.Length];
            if (blockDetectors.Length == 0)
            {
                Debug.LogWarning("Door has no pressure plates");
            }
        }

        public void Unlock(BlockDetectionNicholas blockDetection)
        {
            unlocks[Array.IndexOf(blockDetectors, blockDetection)] = true;
            unlockLights[Array.IndexOf(blockDetectors, blockDetection)].material.SetColor("_EmissionColor", Color.green * 20f);
            DoorOpenClose();
        }

        public void Lock(BlockDetectionNicholas blockDetection)
        {
            unlocks[Array.IndexOf(blockDetectors, blockDetection)] = false;
            unlockLights[Array.IndexOf(blockDetectors, blockDetection)].material.SetColor("_EmissionColor", Color.red * 20f);
            DoorOpenClose();
        }

        void DoorOpenClose()
        {
            bool openDoor = true;
            foreach (bool unlock in unlocks)
            {
                if (!unlock)
                {
                    openDoor = false;
                }
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
