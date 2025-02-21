using System;
using UTweener.Visual;

namespace UTweener
{
    public partial class UTween<T> : UTween
    {
        public UTween<T> StopChain() { Stop();  return this; }
        public UTween<T> PlayChain() { Resume(); return this; }
        public UTween<T> PauseChain() { Pause(); return this; }
        public UTween<T> ResetChain() { Reset(); return this; }
        public UTween<T> ReverseChain() { ResetReverse(); return this; }
        public UTween<T> SetStart(T value) { start = value; return this; }
        public UTween<T> SetTarget(T value) { target = value; return this; }
        public UTween<T> SetDuration(float value) { duration = value; return this; }
        public UTween<T> OnPlay(Action onPlay) { this.onPlay = onPlay; return this; }
        public UTween<T> OnComplete(Action onComplete) { onCompleteAction = onComplete; return this; }
        public UTween<T> AddEvents(UTweenEvents events) { Events = events; return this; }
        public UTween<T> SetTimeScaleMutliplier(float value) { TimeScaleMultiply = value; return this; }
        public UTween<T> SetTimeScale(bool value) { TimeScale = value; return this; }
        public UTween<T> SetEase(EasingFunction.Ease value) { easeFunc = EasingFunction.GetEasingFunction(value); return this; }
        public UTween<T> SetPingPong(UTweenPingPong pingPong) { PingPong = pingPong; return this; }
    }
}