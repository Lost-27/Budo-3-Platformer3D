using Platformer.Game.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Platformer.Game.UI
{
    public class CoinsUI : MonoBehaviour
    {
        #region Variables

        [SerializeField] 
        private TextMeshProUGUI _dynamicCoinsLabel;

        private CollectionCoins _collectionCoins;

        #endregion

        [Inject]
        public void Construct(CollectionCoins collectionCoins)
        {
            _collectionCoins = collectionCoins;

            _collectionCoins.OnCoinsChanged += UpdateCoinsLabel;
            UpdateCoinsLabel();
        }

        #region Unity lifecycle

        private void OnDestroy()
        {
            if (_collectionCoins != null)
                _collectionCoins.OnCoinsChanged -= UpdateCoinsLabel;
        }

        #endregion
        

        #region Private methods

        private void UpdateCoinsLabel() =>
            _dynamicCoinsLabel.text = _collectionCoins.CurrentCoins.ToString();

        #endregion
    }
}