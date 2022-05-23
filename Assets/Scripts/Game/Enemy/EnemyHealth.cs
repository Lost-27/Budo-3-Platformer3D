using System;
using Platformer.Game.Core;
using Platformer.Game.Logger;
using Platformer.Game.Logic;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _current;
        [SerializeField] private int _max;

        private IGameLogger _gameLogger;

        public event Action OnChanged;

        public int CurrentHp { get => _current; private set => _current = value; }
        public int MaxHp { get => _max; private set => _max = value; }


        [Inject]
        public void Construct(IGameLogger gameLogger)
        {
            _gameLogger = gameLogger;
        }

        public void Setup(int current, int max)
        {
            CurrentHp = current;
            MaxHp = max;

            _gameLogger.Log($"Enemy setup");
            OnChanged?.Invoke();
        }
        
        public void AddLife(int healthPoints)
        {
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHp <= 0)
                return;

            CurrentHp -= damage;
            OnChanged?.Invoke();
        }
    }
}