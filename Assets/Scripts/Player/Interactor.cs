using UnityEngine;

namespace Midterm
{
    public abstract class Interactor : MonoBehaviour
    {
        [SerializeField] protected PlayerInput _input;

        void Update()
        {
            Interact();
        }

        public abstract void Interact();
        

        
    }
}
