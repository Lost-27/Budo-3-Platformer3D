using Platformer.Game.Player;
using Platformer.Utility.Constants;
using UnityEngine;

namespace Platformer.Game.DangerZones
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(_damage);
            }
        }
    }
}