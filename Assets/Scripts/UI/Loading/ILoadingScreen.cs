using System;

namespace Platformer.UI.Loading
{
    public interface ILoadingScreen
    {
        //Todo: Make it Async
        void Show();
        void Hide();
    }
}