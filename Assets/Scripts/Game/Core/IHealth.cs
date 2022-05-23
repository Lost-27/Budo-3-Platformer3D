using System;

namespace Platformer.Game.Core
{
    public interface IHealth : IDamageable
    {
        event Action OnChanged;

        int CurrentHp { get; }
        int MaxHp { get; }
        
        void Setup(int current, int max);
        void AddLife(int healthPoints);
    }
}