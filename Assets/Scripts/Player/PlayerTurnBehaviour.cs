using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class PlayerTurnBehaviour : MonoBehaviour
    {
        [SerializeField] PlayerInput _input;

        [Header("Player Turn")]
        [SerializeField] float _turnSpeed;

        void Update()
        {
            RotatePlayer();
        }

        void RotatePlayer()
        {
            transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _input.mouseX);
        }
    }
}
