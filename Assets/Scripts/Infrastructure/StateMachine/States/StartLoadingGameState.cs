using System.Collections;
using Platformer.Infrastructure.Coroutines;
using Platformer.Infrastructure.SceneLoading;
using Platformer.UI.Loading;
using UnityEngine;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class StartLoadingGameState : IAppState
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IAppStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public StartLoadingGameState(ILoadingScreen loadingScreen, IAppStateMachine stateMachine,
            ISceneLoader sceneLoader)
        {
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            _loadingScreen.Show();

            await _sceneLoader.LoadSceneAsync(SceneName.Game);
            
            _stateMachine.Enter<EndLoadingGameState>();

        }

        public void Exit()
        {
        }

    }
}