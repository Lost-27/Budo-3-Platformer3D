using Cinemachine;
using Platformer.Game.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class CamToggle : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook cam1;
        [SerializeField] private CinemachineVirtualCamera cam2;

        [SerializeField] private GameObject _ellenGeoRef;
        [SerializeField] private PlayerRotator _playerRotator;

        private IInputService _inputService;
        private bool _toggle;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.IsCamToggle)
            {
                _toggle = !_toggle;
                if (_toggle)
                {
                    cam1.Priority = 0;
                    cam2.Priority = 1;

                    _playerRotator.enabled = false;
                    _ellenGeoRef.gameObject.SetActive(false);
                }
                else
                {
                    cam1.Priority = 1;
                    cam2.Priority = 0;

                    _playerRotator.enabled = true;
                    _ellenGeoRef.gameObject.SetActive(true);
                }
            }
        }
    }
}