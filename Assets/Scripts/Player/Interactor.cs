using UnityEngine;

namespace Midterm
{
    public abstract class Interactor : MonoBehaviour
    {

        void Update()
        {
            Interact();
        }

        public abstract void Interact();
        

        
    }
}
