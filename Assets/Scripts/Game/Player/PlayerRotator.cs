using Cinemachine;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook _freeLook;

        void Update()
        {
            transform.localRotation = Quaternion.Euler(0f, _freeLook.m_XAxis.Value, 0f);
        }
    }
}