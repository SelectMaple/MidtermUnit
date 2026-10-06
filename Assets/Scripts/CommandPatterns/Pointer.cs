using UnityEngine;

namespace Midterm
{
    public class Pointer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Buddy")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
