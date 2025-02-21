using UnityEngine;
using System;

namespace UTweener.Types
{
    public enum RectTransformType {AnchoredPosition, SizeDelta}

    [Serializable]
    public class RectTransformTweenType : TweenType<RectTransform, Vector2> 
    {
        public RectTransformType type;

        public override void SetStart()
        {
            base.SetStart();
            start = comp.anchoredPosition;
        }

        public override void SetTarget()
        {
            base.SetTarget();
            target = comp.anchoredPosition;
        }

        public override void Tween(bool reverse, Action onComplete = null)
        {
            if (reverse)
                    Tweener(target, start);
                else
                    Tweener(start, target);

            void Tweener(Vector2 start, Vector2 target)
            {
                switch (type)
                {
                    case RectTransformType.AnchoredPosition:
                        TweenAnchoredPosition();
                        break;
                    case RectTransformType.SizeDelta:
                        TweenSizedDelta();
                        break;
                }

                void TweenAnchoredPosition() 
                {
                    comp.anchoredPosition = start;
                    comp.TweenAnchoredPosition(target, config.Duration).SetConfig(config).OnComplete(onComplete).Play();
                }

                void TweenSizedDelta() 
                {
                    comp.sizeDelta = start;
                    comp.TweenRectSize(target, config.Duration).SetConfig(config).OnComplete(onComplete).Play();
                }
            }
        }
    }
}