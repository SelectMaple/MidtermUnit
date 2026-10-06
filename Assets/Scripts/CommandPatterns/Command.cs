using UnityEngine;

namespace Midterm
{
    public abstract class Command
    {
       // - Extraction method
       public abstract void Execute();

        // - checks if the current command has been executed or not
       public abstract bool IsComplete { get; }
    }
}
