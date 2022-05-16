using DG.Tweening;
//using NaughtyAttributes;
using UnityEngine;

namespace Platformer.Game.Utility.Animations
{
    public class SequenceAnimatable : BaseAnimatable
    {
        [SerializeField] private BaseAnimatable[] _animatables;

        private Tween _tween;

        // [Button()]
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
        
        // [Button()]
        public override void Kill()
        {
            _tween?.Kill();
        }
    }
}