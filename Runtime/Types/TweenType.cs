using UTweener.Visual;
using System;

namespace UTweener.Types
{
    [Serializable]
    public abstract class TweenType 
    { 
        protected UTweenConfig config;
        public void SetConfig(UTweenConfig config) => 
            this.config = config;

        public virtual void Tween(bool reverse, Action onComplete = null) {}      
        public virtual void SetStart() { }
        public virtual void SetTarget() { }
    }

    [Serializable]
    public abstract class TweenType<Comp> : TweenType
    {
        public Comp comp;
    }

    [Serializable]
    public abstract class TweenType<Comp, Value> : TweenType<Comp>
    {
        public Value start, target;
    }
}