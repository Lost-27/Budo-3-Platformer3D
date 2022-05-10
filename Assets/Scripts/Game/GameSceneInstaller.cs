using Platformer.Game.Logger;
using Platformer.Game.Services.Currency;
using Platformer.Game.Services.Pause;
using Zenject;

namespace Platformer.Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameLoggerInstaller.Install(Container);
            CurrencyServiceInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
        }
    }
}