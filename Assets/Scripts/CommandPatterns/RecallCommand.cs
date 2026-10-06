using UnityEngine;
using UnityEngine.AI;

namespace Midterm
{
    public class RecallCommand : Command
    {
        NavMeshAgent agent;
        Transform player;

        public RecallCommand(NavMeshAgent _agent, Transform _player)
        {
            agent = _agent;
            player = _player;

        }

        public override void Execute()
        {
            agent.SetDestination(player.position);
        }

        public override bool IsComplete => ReachedDestination();

        bool ReachedDestination()
        {
            if (agent.pathPending)
                return false;
            if (agent.remainingDistance > agent.stoppingDistance)
                return false;
            return true;
        }

    }
}
