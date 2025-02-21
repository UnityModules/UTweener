using UnityEngine;
using System;

namespace UTweener.Types
{
    public enum TransformType {Position,EulerAngles,Scale}

    [Serializable]
    public class TransformTweenType : TweenType<Transform, Vector3> 
    {
        public TransformType type;
        public Space space;

        public override void SetStart()
        {
            base.SetStart();

            switch (type)
            {
                case TransformType.Position:
                    start = space == Space.Self ? comp.localPosition : comp.position;
                    break;
                case TransformType.EulerAngles:
                    start = space == Space.Self ? comp.localEulerAngles : comp.position;
                    break;
                case TransformType.Scale:
                    start = comp.localScale;
                    break;
            }
        }

        public override void SetTarget()
        {
            base.SetTarget();

            switch (type)
            {
                case TransformType.Position:
                    target = space == Space.Self ? comp.localPosition : comp.position;
                    break;
                case TransformType.EulerAngles:
                    target = space == Space.Self ? comp.localEulerAngles : comp.position;
                    break;
                case TransformType.Scale:
                    target = comp.localScale;
                    break;
            }
        }

        public void SetValue(Vector3 value)
        {
            switch(type)
            {
                case TransformType.Position:
                    switch(space)
                    {
                        case Space.Self:
                            comp.position = value;
                            break;
                        case Space.World:
                            comp.localPosition = value;
                            break;
                    }
                    break;
                case TransformType.EulerAngles:
                    switch(space)
                    {
                        case Space.Self:
                            comp.eulerAngles = value;
                            break;
                        case Space.World:
                            comp.localEulerAngles = value;
                            break;
                    }
                    break;
                case TransformType.Scale:
                    comp.localScale = value;
                    break;
            }
        }

        public override void Tween(bool reverse, Action onComplete = null)
        {
            switch(type)
            {
                case TransformType.Position:
                    TweenPosition(reverse, onComplete);
                    break;
                case TransformType.EulerAngles:
                    TweenEulerAngles(reverse, onComplete);
                    break;
                case TransformType.Scale:
                    TweenLocalScale(reverse, onComplete);
                    break;
            }

            void TweenPosition(bool reverse, Action onComplete)
            {
                if (reverse)
                    Tweener(target, start);
                else
                    Tweener(start, target);

                void Tweener(Vector3 start, Vector3 target)
                {
                    SetValue(start);
                    comp.TweenPosition(target, space, config.Duration).Play();
                }
            }
            void TweenEulerAngles(bool reverse, Action onComplete)
            {
                if (reverse)
                    Tweener(target, start);
                else
                    Tweener(start, target);

                void Tweener(Vector3 start, Vector3 target)
                {
                    SetValue(start);
                    comp.TweenEulerAngles(target, space, config.Duration).Play();
                }
            }
            void TweenLocalScale(bool reverse, Action onComplete)
            {
                if (reverse)
                    Tweener(target, start);
                else
                    Tweener(start, target);

                void Tweener(Vector3 start, Vector3 target)
                {
                    SetValue(start);
                    comp.TweenScale(target, config.Duration).Play();
                }
            }
        }
    }
}