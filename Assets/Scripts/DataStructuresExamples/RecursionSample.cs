using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem.Android;

namespace Midterm
{
    public class RecursionSample : MonoBehaviour
    {
        int counter = 0;
        public GameObject nodeObject;

        void Start()
        {
            SolveHanoiProblem(3, "A", "B", "C");

            FractalTree(10);
            Debug.Log("FractalTree: " + counter);
        }

        

        void FractalTree(int depth, GameObject parent = null, bool reverse = false)
        {
            if (depth == 0) return;

            float distance = 10;
            float angle = 30;

            if (reverse) angle *= -1;

            // - determine where it should spawn
            Vector3 spawnPoint;

            if (parent != null)
            {
                spawnPoint = parent.transform.position + (parent.transform.forward * distance);
            }
            else spawnPoint = transform.position + (transform.forward * distance);

            // - calculate the rotation of child object
            Quaternion rotation = (parent != null) ? Quaternion.Euler(0, parent.transform.rotation.y + angle, 0) : Quaternion.Euler(transform.forward);

            // - spawn object at the position ahead of parent
            GameObject go =  Instantiate(nodeObject, spawnPoint, rotation);

            // - repeat the recursion
            FractalTree(depth - 1, go);
            FractalTree(depth - 1, go, true);

           
        }

        void SolveHanoiProblem(int rings, string start, string auxillary, string destination)
        {
            // - Base Case
            if (rings == 1)
            {
                Debug.Log($"Move {rings} from {start} to {destination}");
                return;
            }

            
            // - Move everything from above out of the way recursively
            SolveHanoiProblem(rings - 1, start, destination, auxillary);

            // - Movement of the disks after all disks have been moved off it
            Debug.Log($"Move {rings} from {start} to {destination}");

            // - Move all disks back on top of each other to repeat cycle
            SolveHanoiProblem(rings - 1, auxillary, start, destination);
        }

        
        //void For(int depth)
        //{
        //    int currentdepth = depth - 1;

        //    // - Add functionality to method here

        //    if (currentdepth > 0)
        //    {
        //        For(currentdepth);
        //    }

        //    counter++;

        //}
    }
}
