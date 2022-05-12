using Platformer.Game.UI.Pause;
using System;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Services.Pause
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private IPauseScreen _pauseScreen;

        private bool _isUIAnimating;

        public bool IsPaused { get; private set; }

        [Inject]
        public void Construct(IPauseScreen pauseScreen)
        {
            _pauseScreen = pauseScreen;
        }

        private void Start()
        {
            _pauseScreen.OnContinueButtonClicked += TogglePause;
        }

        private void OnDestroy()
        {
            _pauseScreen.OnContinueButtonClicked -= TogglePause;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !_isUIAnimating)
            {
                TogglePause();
            }
        }

        private async void TogglePause()
        {
            _isUIAnimating = true;

            IsPaused = !IsPaused;

            Time.timeScale = IsPaused ? 0 : 1f;

            if (IsPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                await _pauseScreen.Show();
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                await _pauseScreen.Hide();
            }                

            _isUIAnimating = false;
        }
    }
}