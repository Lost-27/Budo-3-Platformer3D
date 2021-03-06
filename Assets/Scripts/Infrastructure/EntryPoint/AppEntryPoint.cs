using Platformer.Infrastructure.StateMachine;
using Platformer.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.EntryPoint
{
    public class AppEntryPoint : MonoBehaviour
    {
        private IAppStateMachine _stateMachine;

        [Inject]
        public void Construct(IAppStateMachine appStateMachine)
        {
            _stateMachine = appStateMachine;
        }

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }
}