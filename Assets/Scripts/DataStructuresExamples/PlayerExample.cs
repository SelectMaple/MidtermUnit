using UnityEngine;
using System.Collections.Generic;

namespace Midterm
{
    public class PlayerExample : MonoBehaviour
    {
        public Waypoint currentWaypoint;
        public Waypoint targetDestination;

        public Queue<Waypoint> waypoints = new Queue<Waypoint>();

        public float moveSpeed = 3f;
        public bool complete = false;


        void Start()
        {
            List<Waypoint> list = currentWaypoint.GetIdealPath(targetDestination);
            foreach (Waypoint wp in list)
            {
                waypoints.Enqueue(wp);
            }

            currentWaypoint = waypoints.Dequeue();
        }


        void Update()
        {

            if (currentWaypoint == null && targetDestination == null) return;

            // - move toward the destination 
            if (complete == false)
            {
                Debug.Log(targetDestination.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.transform.position, moveSpeed * Time.deltaTime);
            }

            if(Vector3.Distance(transform.position, targetDestination.transform.position) < 0.1f)
            {
                // - check if we reached the destination
                if (waypoints.Count <= 0)
                {
                    complete = true;
                }
                else
                {
                    targetDestination = waypoints.Dequeue();
                }
            }
            
            
        }


    }
}
