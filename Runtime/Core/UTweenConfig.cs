using UnityEngine;

namespace UTweener
{
    [System.Serializable]
    public class UTweenConfig
    {
        [field:SerializeField] public EasingFunction.Ease EaseAnimation { get; private set; }
        [field:SerializeField] public float Duration { get; private set; } = 1;
        [field:SerializeField] public bool TimeScale { get; private set; } = false;
        [field:SerializeField] public UTweenPingPong PingPong { get; private set; }

        public UTweenConfig(EasingFunction.Ease easeAnimation, float duration = 1, bool timeScale = false, UTweenPingPong pingPong = null) =>
            (EaseAnimation, Duration, TimeScale, PingPong) = (easeAnimation, duration, timeScale, pingPong);
    }
}