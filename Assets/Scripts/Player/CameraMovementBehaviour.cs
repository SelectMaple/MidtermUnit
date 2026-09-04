using UnityEngine;

namespace Midterm
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovementBehaviour : MonoBehaviour
    {
        [SerializeField] PlayerInput _input;

        [Header("Player Turn")]
        [SerializeField] float _turnSpeed;
        [SerializeField] bool _invertedMouse;

        float _camXRotation;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            RotateCamera();
        }

        void RotateCamera()
        {
            _camXRotation += Time.deltaTime * _input.mouseY * _turnSpeed * (_invertedMouse ? 1 : -1);
            _camXRotation = Mathf.Clamp(_camXRotation, -85f, 85f);

            transform.localRotation = Quaternion.Euler(_camXRotation, 0, 0);


        }
    } 
        

}
