using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class PushButton : MonoBehaviour, ISelectable
    {
        [SerializeField] Material _default;
        [SerializeField] Material _hoverColor;
        [SerializeField] Material _uninteractableColor;
        [SerializeField] MeshRenderer _renderer;

        Door door;

        public UnityEvent _onPush;

        public void OnHoverEnter()
        {
            if (GameManager.instance.hasKeyCard != false)
            {
                _renderer.material = _hoverColor;
            }
            else
            {
                _renderer.material = _uninteractableColor;
            }
                
        }
        public void OnSelect()
        {
            if (GameManager.instance.hasKeyCard)
            {
                GameManager.instance.hasKeyCard = false;

                Debug.Log("Keycard was used");

                _onPush?.Invoke();
            }
            else
            {
                Debug.Log("You need a keycard!");
            }

            
        }
        public void OnHoverExit()
        {
            _renderer.material = _default;
        }
    }
}
