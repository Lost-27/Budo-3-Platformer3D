using Platformer.Game.Services.Currency;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class CollectionCoins : MonoBehaviour
    {
        private ICurrencyService _currencyService;


        [Inject]
        public void Construct(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public void AddCoin(int coins)
        {
            _currencyService.Add(Currency.Coins, coins);
        }
    }
}