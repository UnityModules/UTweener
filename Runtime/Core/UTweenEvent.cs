using System;
using UPatterns;

namespace UTweener
{
    public record UTweenEvents(UTweenEvent[] events)
    {
        public void Update(float time) =>
            events.ForEach(evt => { if (evt.CallIf(time)) evt.Call();});

        public void Reset() =>
             events.ForEach(evt => evt.Reset());
    }

    public record UTweenEvent(Action EventAction,float CallTime)
    {
        private const float thresholdTime = 0.01f;
        public bool IsDone { get; private set; }

        public void Reset() =>
            IsDone = false;

        public bool CallIf(float time) =>
             !IsDone && CallTime - thresholdTime <= time && CallTime >= time + thresholdTime;

        public void Call()
        {
            if (IsDone)
                return;

            IsDone = true;
            EventAction?.Invoke();
        }
    }
}