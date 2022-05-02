using Platformer.Game.Player;
using Platformer.Utility.Constants;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _pointValue;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player)) 
                return;
            
            CollectionCoins collectionCoins= other.GetComponent<CollectionCoins>();
            collectionCoins.AddCoin(_pointValue);
            Destroy(gameObject);
        }
    }
}