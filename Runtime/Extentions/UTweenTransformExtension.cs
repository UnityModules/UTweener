using UnityEngine;

namespace UTweener
{
    public static class UTweenTransformExtension
    {
        public static UTween<Vector3> TweenPosition(this Transform tr, Vector3 target, Space space, float duration = 1)
        {
            void Update(Vector3 value) => tr.position = value;
            void UpdateLocal(Vector3 value) => tr.localPosition = value;

            return UTweenLerp.Lerp(space == Space.Self ? tr.localPosition : tr.position, target, duration, space == Space.Self ? UpdateLocal : Update);
        }

        public static UTween<Vector2> TweenAnchoredPosition(this RectTransform tr, Vector2 target, float duration = 1) =>
            UTweenLerp.Lerp(tr.anchoredPosition, target, duration,value => tr.anchoredPosition = value);

        public static UTween<Vector3> TweenAnchoredPosition3D(this RectTransform tr, Vector3 target, float duration = 1) =>
            UTweenLerp.Lerp(tr.anchoredPosition3D, target, duration,value => tr.anchoredPosition3D = value);

        public static UTween<Vector3> TweenEulerAngles (this Transform tr, Vector3 target, Space space, float duration = 1)
        {
            void Update(Vector3 value) => tr.eulerAngles = value;
            void UpdateLocal(Vector3 value) => tr.localEulerAngles = value;

            return UTweenLerp.Lerp(space == Space.Self ? tr.localEulerAngles : tr.eulerAngles, target, duration, space == Space.Self ? UpdateLocal : Update);
        }

        public static UTween<Quaternion> TweenQuaternion(this Transform tr, Quaternion target, Space space, float duration = 1)
        {
            void Update(Quaternion value) => tr.rotation = value;
            void UpdateLocal(Quaternion value) => tr.localRotation = value;

            return UTweenLerp.Lerp(space == Space.Self ? tr.localRotation : tr.rotation, target, duration, space == Space.Self ? UpdateLocal : Update);
        }

        public static UTween<Vector3> TweenScale(this Transform tr, Vector3 target, float duration = 1) =>
          UTweenLerp.Lerp(tr.localScale, target, duration, value => tr.localScale = value);

        public static UTween<Vector3> TweenRectSize(this RectTransform tr, Vector3 target, float duration = 1) =>
            UTweenLerp.Lerp((Vector3)tr.sizeDelta, target, duration, value => tr.sizeDelta = value);
    }
}