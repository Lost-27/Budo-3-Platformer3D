using UnityEngine;

namespace Platformer.Game.Input
{
    public class StandaloneInputService : IInputService
    {
        private bool _isLocked;

        public Vector2 MoveAxis
        {
            get
            {
                if (_isLocked)
                    return Vector2.zero;

                return new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
            }
        }

        public Vector2 MouseAxis
        {
            get
            {
                if (_isLocked)
                    return Vector2.zero;

                return new Vector2(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));
            }
        }

        public bool IsJump => !_isLocked && UnityEngine.Input.GetButtonDown("Jump");
        public bool IsAttackUp => !_isLocked && UnityEngine.Input.GetButtonUp("Fire1");
        public bool IsCamToggle => !_isLocked && UnityEngine.Input.GetButtonDown("CamToggle");

        public void SetLocked(bool isLocked) =>
            _isLocked = isLocked;
    }
}