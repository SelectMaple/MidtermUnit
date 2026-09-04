using UnityEngine;

namespace Midterm
{
    public class PickUpInteractor : Interactor
    {
        [SerializeField] Camera _cam;
        [SerializeField] LayerMask _pickUpLayer;
        [SerializeField] float _pickUpDistance;
        [SerializeField] Transform _attachTransform;

        bool isPicked = false;
        RaycastHit _rayCastHit;
        IPickable _pickable;

        public override void Interact()
        {
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out _rayCastHit, _pickUpDistance, _pickUpLayer))
            {
                if(_input.activatePressed && !isPicked)
                {
                    _pickable = _rayCastHit.transform.GetComponent<IPickable>();
                    if (_pickable == null)
                        return;

                    _pickable.OnPicked(_attachTransform);
                    isPicked = true;
                    return;
                }
            }

            if (_input.activatePressed && isPicked && _pickable != null)
            {
                _pickable.OnDropped();
                isPicked = false;
            }
        }
    }
}
