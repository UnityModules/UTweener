using System.Collections.Generic;
using UnityEngine;

namespace UTweener
{
    public sealed class UTweener : MonoBehaviour
    {
        private static UTweener instance;
        public static UTweener Instance => instance ??= new GameObject(nameof(UTweener)).AddComponent<UTweener>();

        private List<UTween> items = new List<UTween>();

        public static bool IsExist(UTween tween) => Instance.items.Find(item => item == tween) != null;
        public static void Add(UTween newTween)
        {
            if(!IsExist(newTween)) 
                Instance.items.Add(newTween);
        }
        public static void Remove(UTween tween) => Instance.items.Remove(tween);

        private void Update()
        {
            if (items.Count == 0) return;

            for (int i = 0; i < items.Count; i++)
                items[i].Update();
        }

        private void OnDestroy() =>
            instance = null;
    }
}