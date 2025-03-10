using System;
using UnityEngine;

namespace UTweener
{
    public static class UTweenLerp
    {
        public static float LerpAlgorithm(float start, float target, float t) => Mathf.Lerp(start, target, t);
        public static Vector2 LerpAlgorithm(Vector2 start, Vector2 target, float t) => Vector2.Lerp(start, target, t);
        public static Vector3 LerpAlgorithm(Vector3 start, Vector3 target, float t) => Vector3.Lerp(start, target, t);
        public static Quaternion LerpAlgorithm(Quaternion start, Quaternion target, float t) => Quaternion.Lerp(start, target, t);
        public static Color LerpAlgorithm(Color start, Color target, float t) => Color.Lerp(start, target, t);

        // Base Extensions
        public static UTween<float> Lerp(this float start, float target, float duration, Action<float> onUpdate = null) =>
            new UTween<float>(start, target, duration, LerpAlgorithm, onUpdate);

        public static UTween<Vector2> Lerp(this Vector2 start, Vector2 target, float duration, Action<Vector2> onUpdate = null) =>
            new UTween<Vector2>(start, target, duration, LerpAlgorithm, onUpdate);

        public static UTween<Vector3> Lerp(this Vector3 start, Vector3 target, float duration, Action<Vector3> onUpdate = null) =>
            new UTween<Vector3>(start, target, duration, LerpAlgorithm, onUpdate);

        public static UTween<Quaternion> Lerp(this Quaternion start, Quaternion target, float duration, Action<Quaternion> onUpdate = null) =>
           new UTween<Quaternion>(start, target, duration, LerpAlgorithm, onUpdate);

        public static UTween<Color> Lerp(this Color start, Color target, float duration, Action<Color> onUpdate = null) =>
           new UTween<Color>(start, target, duration, LerpAlgorithm, onUpdate);

        public static UTween<Color> Lerp(this Color color, float target, float duration, Action<Color> onUpdate = null) =>
           new UTween<Color>(color, new Color(color.r,color.g,color.b, target), duration, LerpAlgorithm, onUpdate);
    }
}
