using UnityEngine;
using UnityEngine.AI;

namespace Midterm
{
    public class MoveCommand : Command
    {
        NavMeshAgent agent;
        Vector3 destination;

        // - Constrcutor for creating the command with values
        public MoveCommand(NavMeshAgent _agent, Vector3 _destination)
        {
            agent = _agent;
            destination = _destination;

        }
        public override void Execute()
        {
            agent.SetDestination(destination);
        }

        // - use a lambda expression to check if the NavMeshAgent has reached the destination
        public override bool IsComplete => ReachedDestination();

        // - check if the NavMeshAgent has reached the destination
        bool ReachedDestination()
        {
            if (agent.remainingDistance > 0.1f)
                return false;
            return true;
        }

        
    }
}
