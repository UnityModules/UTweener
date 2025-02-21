using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPatterns;

namespace UTweener.Visual
{
    public class UTweens
    {
        private UTween[] tweens;
        public bool IsPlaying 
        {
            get{

                for (int i = 0; i < tweens.Length; i++)
                    if (tweens[i].IsPlaying)
                        return true;

                return false;
            }
        }

        public UTweens(UTween[] tweens) =>
            this.tweens = tweens;

        public virtual void Resume() =>
            tweens.ForEach(tween => tween.Resume());

        public virtual void Pause() =>
            tweens.ForEach(tween => tween.Pause());
              
        public virtual void Stop() =>
            tweens.ForEach(tween => tween.Stop());

        public virtual void Play() =>
            tweens.ForEach(tween => tween.Play());
        public virtual void ReversePlay() =>
            tweens.ForEach(tween => tween.ReversePlay());

        public virtual void ChangeState()
        {
            if (IsPlaying)
                Pause();
            else
                Resume();
        }

        public void PlayPingPong(float delay = 0,Action onComplete = null)
        {
            UTweener.Instance.StartCoroutine(Play());
            IEnumerator Play()
            {
                // Play
                Play();
                while (IsPlaying)
                    yield return new WaitForEndOfFrame();

                // Delay
                yield return new WaitForSeconds(delay);

                // Reverse Play
                ReversePlay();
                while (IsPlaying)
                    yield return new WaitForEndOfFrame();

                // Complete
                onComplete?.Invoke();
            }
        }
    }
}