using Platformer.Game.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity = 200f;
        [SerializeField] private Transform _playerBody;

        private float _xRotation;
        
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Update()
        {
            Vector2 mouseAxis = _inputService.MouseAxis;
            float mouseX = mouseAxis.x * _mouseSensitivity * Time.deltaTime;
            float mouseY = mouseAxis.y * _mouseSensitivity * Time.deltaTime;
            

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 80);

            _playerBody.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }
    }
}