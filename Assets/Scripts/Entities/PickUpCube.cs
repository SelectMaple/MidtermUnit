using UnityEngine;

namespace Midterm
{
    public class PickUpCube : MonoBehaviour, IPickable
    {
        FixedJoint _joint;
        Rigidbody _cubeRB;

        void Start()
        {
            _cubeRB = GetComponent<Rigidbody>();
        }

        public void OnPicked(Transform attachPoint)
        {
            transform.position = attachPoint.position;
            transform.rotation = attachPoint.rotation;
            transform.SetParent(attachPoint);

            _cubeRB.isKinematic = true;
            _cubeRB.useGravity = false;
        }

        public void OnDropped()
        {
            Destroy(_joint);
            _cubeRB.isKinematic = false;
            _cubeRB.useGravity = true;
            transform.SetParent(null);

        }
    }
}
