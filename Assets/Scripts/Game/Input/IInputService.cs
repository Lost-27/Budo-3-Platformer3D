using UnityEngine;

namespace Platformer.Game.Input
{
    public interface IInputService
    {
        Vector2 MoveAxis { get; }
        Vector2 MouseAxis { get; }
        bool IsAttackUp { get; }
        bool IsJump { get; }

        bool IsCamToggle { get; }

        void SetLocked(bool isLocked);
    }
}