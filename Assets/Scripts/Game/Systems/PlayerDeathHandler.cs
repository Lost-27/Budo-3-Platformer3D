using Platformer.Game.Player;
using Platformer.Game.UI.DeathScreen;
using UnityEngine;

namespace Platformer.Game.Systems
{
    public class PlayerDeathHandler : MonoBehaviour
    {
        #region Variables

        [SerializeField] private DeathScreen _deathScreen;
        [SerializeField] private PlayerDeath _playerDeath;

        #endregion


        #region Unity lifecycle

        private void OnEnable()
        {
            _playerDeath.OnDeath += PlayerDead;
        }
        private void OnDisable()
        {
            _playerDeath.OnDeath -= PlayerDead;
        }

        #endregion


        #region Private methods

        private void PlayerDead()
        {
            _deathScreen.SetActive(true);
        }

        #endregion
    }
}
