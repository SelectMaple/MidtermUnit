using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Midterm
{
    public class CommandInteractor : Interactor
    {
        // - First In, First Out (FIFO), will complete commands as we give it
        Queue<Command> commands = new Queue<Command>();

        [SerializeField] NavMeshAgent agent;
        [SerializeField] GameObject pointerPrefab;
        [SerializeField] Camera cam;

        [SerializeField] Transform player;

        Command currentCommand;

        public override void Interact()
        {
            // - checking to see if player is pressing command button
            if (PlayerInput.Instance.commandPressed)
            {
                // - raycast frmo the center of the screen (camera) to the point that we want to send the command to
                Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

                // - if the raycast hits something
                if(Physics.Raycast(ray, out var hitInfo))
                {
                    // - if the raycast hits the ground
                    if (hitInfo.transform.CompareTag("Ground"))
                    {
                        // - create a pointer object
                        GameObject pointer = Instantiate(pointerPrefab);
                        pointer.transform.position = hitInfo.point;

                        // - add a new movement command to the queue of commands for the agent to execute
                        commands.Enqueue(new MoveCommand(agent, hitInfo.point));
                    }
                }
            }

            if (PlayerInput.Instance.recallPressed)
            {
                commands.Enqueue(new RecallCommand(agent, player));

                

            }

            

            ProcessCommands();
        }

        // - responsible for processing the commands in the queue one at a time
        void ProcessCommands()
        {
            // - if I currently have a command and not done it, then don't do anything new until first command is finished
            if (currentCommand != null && !currentCommand.IsComplete)
                return;

            // - if i don't have any commands in my queue, then don't do anything
            if (commands.Count == 0)
                return;

            // - gets rid of command that was just processed 
            currentCommand = commands.Dequeue();

            // - execute the command that was just dequeued from the queue of commands
            currentCommand.Execute();
        }
    }
}
