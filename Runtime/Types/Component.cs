using System;
using System.Collections.Generic;
using UnityEngine;
using UTweener.Visual;

namespace UTweener.Types
{
    public class ComponentTweenType : MonoBehaviour
    {
        [SerializeField] protected UTweenConfig config;
        protected List<TweenType> types = new();

        public virtual void Initialize() =>
            types.ForEach(type => type.SetConfig(config));

        public virtual void SetDefaultTargets() =>
            types.ForEach(type => type.SetTarget());

        public virtual void Show(Action onComplete = null) =>
            Tween(false,onComplete);

        public virtual void Hide(Action onComplete = null) =>
            Tween(true,onComplete);

        public virtual void Tween(bool reverse, Action onComplete = null) =>
            types.ForEach(type => type.Tween(reverse, onComplete));
    }
}