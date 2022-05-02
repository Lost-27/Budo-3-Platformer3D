using System;

namespace Platformer.Game.Player
{
    public interface ICollectionCoins
    {
        int CurrentCoins { get; }

        event Action OnCoinsChanged;

        void AddCoin(int coin);

    }
}