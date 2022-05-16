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
        [SerializeField] private float _groundDistance = 0.1f;
        [SerializeField] private LayerMask _groundMask;

        [Header("Jump Settings")]
        [SerializeField] private float _jumpHeight = 3f;

        private IInputService _inputService;
        private Vector3 _fallVelocity;
        private Transform _cachedTransf;

        public Vector3 Move { get; private set; }
        public bool IsGrounded { get; private set; }
        public float VerticalVelocity { get; private set; }

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _cachedTransf = transform;
            IsGrounded = true;
        }

        private void Update()
        {
            IsGrounded = Physics.CheckSphere(_groundCheckTransform.position, _groundDistance, _groundMask);

            if (IsGrounded && _fallVelocity.y < 0)
            {
                _fallVelocity.y = -2f;
            }

            Vector2 moveAxis = _inputService.MoveAxis;

            Move = (_cachedTransf.right * moveAxis.x + _cachedTransf.forward * moveAxis.y) * _speed;
            _controller.Move(Move * Time.deltaTime);

            if (_inputService.IsJump && IsGrounded)
            {
                _fallVelocity.y = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
            }

            _fallVelocity += Physics.gravity * _gravityMultiplier * Time.deltaTime;
            _controller.Move(_fallVelocity * Time.deltaTime);
            VerticalVelocity = _fallVelocity.y;
        }
    }
}