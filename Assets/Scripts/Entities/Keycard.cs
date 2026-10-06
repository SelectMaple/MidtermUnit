using UnityEngine;

namespace Midterm
{
    public class Keycard : MonoBehaviour, ISelectable
    {
        [SerializeField] Material _default;
        [SerializeField] Material _hoverColor;
        [SerializeField] MeshRenderer _renderer;


        public void OnHoverEnter()
        {
            _renderer.material = _hoverColor;
        }

        public void OnHoverExit()
        {
            _renderer.material = _default;
        }

        public void OnSelect()
        {
            GameManager.instance.hasKeyCard = true;
            Debug.Log("Keycard collected!");

            Destroy(gameObject);
        }
    }
}
