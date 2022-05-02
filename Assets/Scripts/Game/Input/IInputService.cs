using UnityEngine;

namespace Platformer.Game.Input
{
    public interface IInputService
    {
        Vector2 MoveAxis { get; }
        Vector2 MouseAxis { get; }
        bool IsJump { get; }

        void SetLocked(bool isLocked);
    }
}