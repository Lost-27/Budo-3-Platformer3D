using System;

namespace Platformer.Game.Core
{
    public interface IHealth : IDamageable
    {
        event Action OnChanged;

        int CurrentHp { get; }
        int MaxHp { get; }
        
        void AddLife(int healthPoints);
    }
}