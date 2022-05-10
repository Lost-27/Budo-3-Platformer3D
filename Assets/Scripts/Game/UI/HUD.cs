using Platformer.Game.Core;
using Platformer.Game.Services.Currency;
using TMPro;
using UnityEngine;
using Zenject;

namespace Platformer.Game.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dynamicHealthLabel;
        [SerializeField] private TextMeshProUGUI _dynamicCoinsLabel;

        private IHealth _health;
        private ICurrencyService _currencyService;

        [Inject]
        public void Construct(IHealth health, ICurrencyService currencyService)
        {
            _health = health;
            _currencyService = currencyService;
        }

        private void Start()
        {
            _health.OnChanged += HealthChanged;
            _currencyService.OnCurrencyChanged += UpdateLabel;

            HealthChanged();
            UpdateLabel(Currency.Coins, _currencyService.Count(Currency.Coins));
        }

        private void OnDestroy()
        {
            _health.OnChanged -= HealthChanged;
            _currencyService.OnCurrencyChanged -= UpdateLabel;
        }

        private void HealthChanged() =>
            _dynamicHealthLabel.text = _health.CurrentHp.ToString();

        private void UpdateLabel(Currency currency, int count) =>
                _dynamicCoinsLabel.text = count.ToString();
    }
}