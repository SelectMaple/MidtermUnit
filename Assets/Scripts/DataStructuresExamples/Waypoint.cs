using UnityEngine;
using System.Collections.Generic;

namespace Midterm
{
    [System.Serializable]
    public class Waypoint : MonoBehaviour
    {
        // - locations directly connecting to this waypoint (node)
        public List<Waypoint> connections = new List<Waypoint>();

        // - ADDED LIST OF WAYPOINTS VISITED TO PARAMETERS
        public List<Waypoint> GetIdealPath(Waypoint targetPoint, List <Waypoint> visited = null)
        {
            List<Waypoint> result = new List<Waypoint>();

            // - if visited list is null, then we create a new list
            if (visited == null)
                visited = new List<Waypoint>();

            // - we have reached our destination
            if (this == targetPoint)
            {
                result.Add(targetPoint);
                return result;
            }

            // - mark this waypoint as visited
            visited.Add(this);

            // - references to our algorithm
            float shortestDistance = Mathf.Infinity;
            Waypoint shortestPath = null;

            // - loop through all children and find the shortest path
            foreach (Waypoint wp in connections)
            {
                // - if we have already navigated to a node, we don't want to travel there again. Don't check it. 
                if (visited.Contains(wp))
                    continue;

                float distanceToWp = Vector3.Distance(targetPoint.transform.position, wp.transform.position);
                if (distanceToWp < shortestDistance)
                {
                    shortestDistance = distanceToWp;
                    shortestPath = wp;
                }
                
            }

            if (shortestPath == null)
                return result;

            // add our chosen waypoint node
            result.Add(shortestPath);

            // - continue searching from that waypoint
            if (shortestPath != targetPoint)
            {
                result.AddRange(shortestPath.GetIdealPath(targetPoint, visited));
            }

            // - return the final best path determined
            return result;
        }

        

        void OnDrawGizmos()
        {
            // - draw the node
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.3f);

            // - Draw the edges
            Gizmos.color = Color.yellow;

            foreach (Waypoint waypoint in connections)
            {
                if (waypoint != null)
                {
                    Gizmos.DrawLine(transform.position, waypoint.transform.position);
                }
            }
        }
    }
}
