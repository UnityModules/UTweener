using UnityEngine;
using UTweener.Visual;

namespace UTweener
{
    public static class UTweenExtension
    {
        public static UTween<T> SetConfig<T>(this UTween<T> tweener, UTweenConfig config) =>
            tweener.SetDuration(config.Duration).
            SetTimeScale(config.TimeScale).
            SetEase(config.EaseAnimation).
            SetPingPong(config.PingPong);

        // Sprite Renderer
        public static UTween<Color> TweenColor(this SpriteRenderer sr, Color target, float duration = 1) =>
            UTweenLerp.Lerp(sr.color, target, duration, value => sr.color = value);
        public static UTween<Color> TweenAlpha(this SpriteRenderer sr, float target, float duration = 1) =>
          UTweenLerp.Lerp(sr.color, target, duration, value => sr.color = value);
    }
}