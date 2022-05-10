using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Game.UI.Pause
{
    public class PauseScreen : MonoBehaviour, IPauseScreen
    {
        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 1f;

        [SerializeField] private Button _continueButton;

        private Tween _tween;

        public event Action OnContinueButtonClicked;


        private void Awake()
        {
            _continueButton.onClick.AddListener(() => OnContinueButtonClicked?.Invoke());
            _canvasGroup.alpha = 0f;
        }

        public Task Show()
        {
            _tween?.Kill();
            _tween = _canvasGroup.DOFade(1f, _fadeDuration).SetUpdate(UpdateType.Normal, true);
            return _tween.AsyncWaitForCompletion();
        }

        public Task Hide()
        {
            _tween?.Kill();
            _tween = _canvasGroup.DOFade(0f, _fadeDuration);
            return _tween.AsyncWaitForCompletion();
        }
    }
}
