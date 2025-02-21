using System;
using UnityEngine;

namespace UTweener
{
    [Serializable]
    public record UTweenPingPong 
    {
        [field: SerializeField] public int Count;
        [field: SerializeField] public float Delay;
    }

    public abstract class UTween
    {
        public bool IsPlaying { protected set; get; }
        public bool IsReverse { protected set; get; }
        protected float timeElapsed, duration;
        protected EasingFunction.Function easeFunc;
        protected UTweenEvents Events;
        protected float TimeScaleMultiply;
        protected bool TimeScale;
        protected UTweenPingPong PingPong;
        protected Action onPlay;
        protected int pingPongCount;
        protected Action onCompleteAction;

        public UTween(float duration) =>
            (this.duration, easeFunc) = (duration, EasingFunction.GetEasingFunction(EasingFunction.Ease.EaseInQuad));

        public virtual void Update()
        {
            if (!IsPlaying) return;
            timeElapsed += TimeScaleMultiply * (TimeScale ? Time.deltaTime : Time.unscaledDeltaTime);
            float t = timeElapsed / duration;
            UpdateValues(t);
            if (t >= 1)
                DoComplete();

            if (Events != null) Events.Update(t);
        }

        protected abstract void UpdateValues(float time);

        public virtual void Play()
        {
            onPlay?.Invoke();
            Reset();
            Resume();
        }
        public virtual void ReversePlay()
        {
            onPlay?.Invoke();
            ResetReverse();
            Resume();
        }
        public void Resume()
        {
            IsPlaying = true;
            UTweener.Add(this);
        }
        public void Pause()
        {
            IsPlaying = false;
            UTweener.Remove(this);
        }
        public void Stop()
        {
            if (IsReverse)
                ResetReverse();
            else Reset();
            Pause();
        }

        public virtual void Reset()
        {
            if (PingPong != null) pingPongCount = PingPong.Count;
            timeElapsed = 0;

            Events.Reset();
            IsReverse = false;
        }
        public virtual void ResetReverse()
        {
            timeElapsed = 0;
            Events.Reset();
            IsReverse = true;
        }

        private void DoComplete()
        {
            if (pingPongCount > 0)
            {
                if (pingPongCount != -1)
                {
                    pingPongCount--;

                    if (pingPongCount == 0)
                    {
                        Complete();
                        return;
                    }
                }

                ResetReverse();
                Stop();
                Resume();
            }
            else
                Complete();
        }
        protected void Complete()
        {
            Stop();
            onCompleteAction?.Invoke();
        }
    }
}