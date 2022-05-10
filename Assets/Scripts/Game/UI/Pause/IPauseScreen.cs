using System;
using System.Threading.Tasks;

namespace Platformer.Game.UI.Pause
{
    public interface IPauseScreen
    {
        event Action OnContinueButtonClicked;

        Task Hide();
        Task Show();
    }
}