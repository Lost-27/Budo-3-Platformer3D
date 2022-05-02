using System;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class CollectionCoins : MonoBehaviour
    {
        private int _currenCoins;
        
        public int CurrentCoins => _currenCoins;

        public event Action OnCoinsChanged;

        public void AddCoin(int coin)
        {
            _currenCoins += coin;
            OnCoinsChanged?.Invoke();
        }
    }
}