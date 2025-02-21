using System;

namespace UTweener
{
    public partial class UTween<T> : UTween
    {
        public delegate T LerpFunction(T start, T target, float t);

        protected T start, target;
        protected T startCurrent, valueCurrent, targetCurrent;
        protected Action<T> onUpdate;
        protected LerpFunction lerpFunc;

        public UTween(T start, T target, float duration, LerpFunction lerpFunc, Action<T> onUpdate = null) : base(duration)
        {
            valueCurrent = this.start = start;
            this.target = target;
            this.lerpFunc = lerpFunc;
            this.onUpdate = onUpdate;
            UTweener.Add(this);
        }

        protected override void UpdateValues(float t)
        {
            if (!IsPlaying) return;
            valueCurrent = lerpFunc(startCurrent, targetCurrent, easeFunc(0, 1, t));
            onUpdate?.Invoke(valueCurrent);
        }

        public override void Play()
        {
            base.Play();
            SetValue(start);
        }
        public override void ReversePlay() 
        {
            base.ResetReverse();
            SetValue(target);
        }

        public override void Reset()
        {
            startCurrent = start;
            targetCurrent = target;
        }
        public override void ResetReverse()
        {
            startCurrent = target;
            targetCurrent = start;
        }   
        public UTween<T> SetValue(T value)
        {
            valueCurrent = value;
            onUpdate?.Invoke(valueCurrent);
            return this;
        }   
    }
}