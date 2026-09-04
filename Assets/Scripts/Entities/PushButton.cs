using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class PushButton : MonoBehaviour, ISelectable
    {
        [SerializeField] Material _default;
        [SerializeField] Material _hoverColor;
        [SerializeField] MeshRenderer _renderer;

        public UnityEvent _onPush;

        public void OnHoverEnter()
        {
            _renderer.material = _hoverColor;
        }
        public void OnSelect()
        {
            _onPush?.Invoke();
        }
        public void OnHoverExit()
        {
            _renderer.material = _default;
        }
    }
}
