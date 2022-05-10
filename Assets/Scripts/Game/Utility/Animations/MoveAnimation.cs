using DG.Tweening;
using UnityEngine;

namespace Platformer.Game.Info.Animations
{
    public class MoveAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPos;
        [SerializeField] private Vector3 _endPos;
        [SerializeField] private float _moveToEndDuration = 2f;
        [SerializeField] private float _moveToStartDuration = 2f;
        [SerializeField] private float _endPosDelay = 1f;
        [SerializeField] private float _startPosDelay = 1f;

        private Tween _moveTween;

        private void Awake()
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            Sequence sequence = DOTween.Sequence().SetEase(Ease.Flash).SetLoops(-1);
            sequence.Append(transform.DOMove(_endPos, _moveToEndDuration));
            sequence.AppendInterval(_endPosDelay);
            sequence.Append(transform.DOMove(_startPos, _moveToStartDuration));
            sequence.AppendInterval(_startPosDelay);

            _moveTween = sequence;
        }
        public void Kill()
        {
            _moveTween.Kill();
        }
    }
}
