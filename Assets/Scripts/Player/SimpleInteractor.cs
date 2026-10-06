using UnityEngine;


namespace Midterm
{
    public class SimpleInteractor : Interactor
    {
        [Header("Interact")]
        [SerializeField] Camera _cam;
        [SerializeField] LayerMask _interactionLayer;
        [SerializeField] float _interactionDistance;

        RaycastHit _rayCastHit;
        ISelectable _selectable;
        

        public override void Interact()
        {
            // cast a ray
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,0));
            if (Physics.Raycast(ray, out _rayCastHit, _interactionDistance, _interactionLayer))
            {
                _selectable = _rayCastHit.transform.GetComponent<ISelectable>();

                if (_selectable != null)
                {
                    _selectable.OnHoverEnter();

                    if (PlayerInput.Instance.activatePressed)
                    {
                        Debug.Log("Interacting with object");
                        _selectable.OnSelect();

                        _selectable = null;
                    }
                }
            }

            if (_rayCastHit.transform == null && _selectable != null)
            {
                _selectable.OnHoverExit();
                _selectable = null;
            }

            Debug.DrawRay(_cam.transform.position, _cam.transform.forward * _interactionDistance, Color.green);
            
        }


    }
}
