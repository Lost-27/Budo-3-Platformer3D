using Platformer.Game.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private CharacterController _controller;

        [Header("Movement Settings")] 
        [SerializeField] private float _speed = 12f;

        [Header("Gravity Settings")] 
        [SerializeField] private float _gravityMultiplier = 1f;

        [Header("GroundCheck Settings")]
        [SerializeField] private Transform _groundCheckTransform;

        [SerializeField] private float _groundDistance = 0.4f;
        [SerializeField] private LayerMask _groundMask;

        [Header("Jump Settings")] 
        [SerializeField] private float _jumpHeight = 3f;

        private IInputService _inputService;

        private Vector3 _velocity;
        private Transform _cachedTransf;
        private bool _isGrounded;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Awake()
        {
            _cachedTransf = transform;
        }

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(_groundCheckTransform.position, _groundDistance, _groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            Vector2 moveAxis = _inputService.MoveAxis;

            Vector3 move = _cachedTransf.right * moveAxis.x + _cachedTransf.forward * moveAxis.y;
            _controller.Move(move * _speed * Time.deltaTime);

            if (_inputService.IsJump && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
            }

            _velocity += Physics.gravity * _gravityMultiplier * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}