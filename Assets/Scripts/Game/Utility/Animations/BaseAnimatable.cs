using DG.Tweening;
using UnityEngine;

namespace Platformer.Game.Utility.Animations
{
    public abstract class BaseAnimatable : MonoBehaviour
    {
        public abstract Tween Begin();
        public abstract void Kill();
    }

    public class IntervalAnimatable : BaseAnimatable
    {
        [SerializeField] private float _delay;

        public override Tween Begin() =>
            DOVirtual.DelayedCall(_delay, null);

        public override void Kill()
        {
        }
    }

    public class V3LocalPositionAnimatable : BaseAnimatable
    {
        [SerializeField] private V3AnimationInfo _info;
        
        public override Tween Begin() => 
            transform.DOLocalMove(_info.Value, _info.Duration).SetEase(_info.Ease);

        public override void Kill()
        {
        }
    }

    public class SequenceAnimatable : BaseAnimatable
    {
        [SerializeField] private BaseAnimatable[] _animatables;

        private Tween _tween;

        public override Tween Begin()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (BaseAnimatable animatable in _animatables)
            {
                sequence.Append(animatable.Begin());
            }

            _tween = sequence;
            return _tween;
        }

        public override void Kill()
        {
            _tween?.Kill();
        }
    }
}