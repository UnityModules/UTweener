using System;
using UnityEngine;

namespace UTweener.Types
{
    [Serializable]
    public class CanvasGroupTweenType : TweenType<CanvasGroup,float>
    {
        public override void SetStart()
        {
            base.SetStart();
            start = comp.alpha;
        }

        public override void SetTarget()
        {
            base.SetTarget();
            target = comp.alpha;
        }

        public override void Tween(bool reverse, Action onComplete = null)
        {
            if (reverse)
                Tweener(target, start);
            else
                Tweener(start, target);

            void Tweener(float start, float target)
            {
                comp.alpha = start;
                comp.TweenAlpha(target, config.Duration).SetConfig(config).OnComplete(onComplete).Play();
            }
        }
    }
}