using Platformer.Infrastructure.SceneLoading;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class BootstrapState : IAppState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAppStateMachine _stateMachine;

        public BootstrapState(ISceneLoader sceneLoader, IAppStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public async void Enter()
        {
             await _sceneLoader.LoadSceneAsync( SceneName.Menu);
            _stateMachine.Enter<MenuState>();
        }

        public void Exit()
        {
            
        }
    }
}