using Platformer.Game.Player;
using Platformer.Game.Utility.Animations;
using Platformer.Game.Utility.Constants;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _pointValue;
        [SerializeField] private MoveAnimation _moveAnimation;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player)) 
                return;
            
            CollectionCoins collectionCoins= other.GetComponent<CollectionCoins>();
            collectionCoins.AddCoin(_pointValue);
            _moveAnimation.Kill();
            Destroy(gameObject);
        }
    }
}