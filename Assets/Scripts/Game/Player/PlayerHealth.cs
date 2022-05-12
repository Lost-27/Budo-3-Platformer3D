using System;
using Platformer.Game.Core;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _maxHp;

        public event Action OnChanged;

        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;


        #region Unity lifecycle

        private void Awake()
        {
            CurrentHp = _maxHp;
        }

        #endregion


        #region Public methods
        //TODO: DUbliCK ispravit properti!!!!!!!!!!!!!!!!!11:11 sm dz!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public void TakeDamage(int damage)
        {
            if (CurrentHp < 1)
                return;

            CurrentHp -= damage;
            CurrentHp = Mathf.Max(0, CurrentHp);

            OnChanged?.Invoke();
        }

        public void AddLife(int healthPoints)
        {
            if (CurrentHp >= _maxHp)
                return;

            CurrentHp += healthPoints;
            CurrentHp = Mathf.Min(CurrentHp, _maxHp);

            OnChanged?.Invoke();
        }

        #endregion
    }
}