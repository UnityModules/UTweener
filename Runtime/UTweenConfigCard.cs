using UnityEngine;

namespace UTweener.Visual
{
    [CreateAssetMenu(fileName = nameof(UTweenConfigCard),menuName = nameof(UTweenConfigCard))]
    public class UTweenConfigCard : ScriptableObject
    {
        [field: SerializeField] public EasingFunction.Ease EaseAnimation { private set; get; }
        [field: SerializeField] public float Duration { private set; get; } = 1;
        [field: SerializeField] public bool TimeScale { private set; get; } = true;
        [field: SerializeField] public UTweenPingPong PingPong { private set; get; }

        public UTweenConfig Get =>
            new(EaseAnimation, Duration, TimeScale, PingPong);
    }
}