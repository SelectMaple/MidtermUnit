using System;
using UnityEngine;

namespace Midterm
{
    public class Door : MonoBehaviour
    {
        [SerializeField] BlockDetection[] blockDetectors;
        [SerializeField] TargetTrigger[] targets;
        [SerializeField] Renderer[] unlockLights;

        Animator animator;

        bool[] blockUnlocks;
        bool[] targetUnlocks;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            foreach (BlockDetection blockDetector in blockDetectors)
            {
                blockDetector.door = this;
            }

            foreach (TargetTrigger targets in targets)
            {
                targets.door = this;
            }

            foreach (Renderer light in unlockLights)
            {
                light.material.SetColor("_EmissionColor", Color.red * 20f);
            }

            blockUnlocks = new bool[blockDetectors.Length];
            if (blockDetectors.Length == 0)
            {
                Debug.LogWarning("Door has no pressure plates");
            }

            targetUnlocks = new bool[targets.Length];
            if(targets.Length == 0)
            {
                Debug.Log("Targets are ready to be hit to open the door");
            }
        }

        public void UnlockBlocks(BlockDetection blockDetection)
        {
            blockUnlocks[Array.IndexOf(blockDetectors, blockDetection)] = true;
            unlockLights[Array.IndexOf(blockDetectors, blockDetection)].material.SetColor("_EmissionColor", Color.green * 20f);
            DoorOpenClose();
        }

        public void LockBlocks(BlockDetection blockDetection)
        {
            blockUnlocks[Array.IndexOf(blockDetectors, blockDetection)] = false;
            unlockLights[Array.IndexOf(blockDetectors, blockDetection)].material.SetColor("_EmissionColor", Color.red * 20f);
            DoorOpenClose();
        }

        public void UnlockTarget(TargetTrigger targetTrigger)
        {
            targetUnlocks[Array.IndexOf(targets, targetTrigger)] = true;
            unlockLights[Array.IndexOf(targets, targetTrigger)].material.SetColor("_EmissionColor", Color.green * 20f);
            DoorOpenClose();
        }

        public void LockTarget(TargetTrigger targetTrigger)
        {
            targetUnlocks[Array.IndexOf(targets, targetTrigger)] = false;
            unlockLights[Array.IndexOf(targets, targetTrigger)].material.SetColor("_EmissionColor", Color.red * 20f);
            DoorOpenClose();
        }


        public void DoorOpenClose()
        {
            bool openDoor = true;
            foreach (bool unlock in blockUnlocks)
            {
                if (!unlock)
                {
                    openDoor = false;
                }
            }

            foreach (bool unlock in targetUnlocks)
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
