using System;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private MouseLook _mouseLook;
        [SerializeField] private PlayerHealth _playerHealth;

        public event Action OnDeath;

        public bool IsPlayerDeath { get; private set; }


        private void OnEnable()
        {
            _playerHealth.OnChanged += HealthChanged;
        }

        private void OnDisable()
        {
            _playerHealth.OnChanged -= HealthChanged;
        }

        private void Start()
        {
            IsPlayerDeath = false;
        }


        private void HealthChanged()
        {
            if (!IsPlayerDeath && _playerHealth.CurrentHp < 1)
                Death();
        }

        private void Death()
        {
            IsPlayerDeath = true;

            _playerMovement.enabled = false;
            _mouseLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            //_playerMovement.ResetMove();
            //_playerAttack.enabled = false;
            //_collider.enabled = false;

            OnDeath?.Invoke();
        }
    }
}