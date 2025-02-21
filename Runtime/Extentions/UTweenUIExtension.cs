using UnityEngine;
using UnityEngine.UI;

namespace UTweener
{
    public static class UTweenUIExtension
    {
        public static UTween<Color> TweenColor(this Graphic graphic, Color target, float duration = 1) =>
          UTweenLerp.Lerp(graphic.color, target, duration, value => graphic.color = value);

        public static UTween<Color> TweenAlpha(this Graphic graphic, float target, float duration = 1) =>
          UTweenLerp.Lerp(graphic.color, target, duration, value => graphic.color = value);

        public static UTween<float> TweenAlpha(this CanvasGroup canvasGroup, float target, float duration = 1) =>
          UTweenLerp.Lerp(canvasGroup.alpha, target, duration, value => canvasGroup.alpha = value);

        public static UTween<float> TweenFillAmount(this Image img, float target, float duration = 1) =>
          UTweenLerp.Lerp(img.fillAmount, target, duration, value => img.fillAmount = value);

        public static UTween<float> TweenPixelPerUnitMultiplier(this Image img, float target, float duration = 1) =>
          UTweenLerp.Lerp(img.pixelsPerUnitMultiplier, target, duration, value => img.pixelsPerUnitMultiplier = value);
    }
}