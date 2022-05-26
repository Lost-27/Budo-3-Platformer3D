using Platformer.Game.UI.DeathScreen;
using Platformer.Infrastructure.SceneLoading;
using System;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class GameState : IAppState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAppStateMachine _stateMachine;

        public GameState(ISceneLoader sceneLoader, IAppStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            DeathScreen.OnRestartButtonClicked += RestartButtonClicked;
            DeathScreen.OnMenuButtonClicked += MenuButtonClicked;
        }

        public void Exit()
        {
            DeathScreen.OnRestartButtonClicked -= RestartButtonClicked;
            DeathScreen.OnMenuButtonClicked -= MenuButtonClicked;
        }

        private void RestartButtonClicked()
        {
            // _sceneLoader.LoadScene(SceneName.Game);
            _stateMachine.Enter<StartLoadingGameState>();
        }

        private async void MenuButtonClicked()
        {
            await _sceneLoader.LoadSceneAsync(SceneName.Menu);
            _stateMachine.Enter<MenuState>();
        }
    }
}