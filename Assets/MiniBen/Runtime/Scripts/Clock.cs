using System;
using UdonSharp;
using UnityEngine;

namespace MiniBen {
    public sealed class Clock : UdonSharpBehaviour {
        [Header("正時鐘")]
        [SerializeField]
        private AudioClip sound0Min;

        [Header("15分鐘")]
        [SerializeField]
        private AudioClip sound15Min;

        [Header("半時鐘")]
        [SerializeField]
        private AudioClip sound30Min;

        [Header("45分鐘")]
        [SerializeField]
        private AudioClip sound45Min;

        [Header("ビッグ・ベン")]
        [SerializeField]
        private AudioClip soundHour;

        private AudioSource _audio;

        private void Start() {
            this._audio = this.GetComponent<AudioSource>();
        }

        private void Update() {
            var time = DateTime.Now;
            var hour = 12 < time.Hour ? time.Hour - 12 : time.Hour == 0 ? 12 : time.Hour;
            var min = time.Minute;
            var sec = time.Second;
            if(0 <= min && min < 15) {
                var delay = (15 - min) * 60 - sec;
                this.SendCustomEventDelayedSeconds(nameof(this.Play15Min), delay);
            }
            if(15 <= min && min < 30) {
                var delay = (30 - min) * 60 - sec;
                this.SendCustomEventDelayedSeconds(nameof(this.Play30Min), delay);
            }
            if(30 <= min && min < 45) {
                var delay = (45 - min) * 60 - sec;
                this.SendCustomEventDelayedSeconds(nameof(this.Play45Min), delay);
            }
            if(45 <= min) {
                var delay = (60 - min) * 60 - sec;
                this.SendCustomEventDelayedSeconds(nameof(this.Play0Min), delay);
                for(var i = 0; i < hour; i++) {
                    this.SendCustomEventDelayedSeconds(nameof(this.PlayHour), delay + 13.0f + 2.0f * i);
                }
            }
        }

        public void Play0Min() {
            // ReSharper disable once PossibleNullReferenceException
            this._audio.PlayOneShot(this.sound0Min);
        }

        public void Play15Min() {
            // ReSharper disable once PossibleNullReferenceException
            this._audio.PlayOneShot(this.sound15Min);
        }

        public void Play30Min() {
            // ReSharper disable once PossibleNullReferenceException
            this._audio.PlayOneShot(this.sound30Min);
        }

        public void Play45Min() {
            // ReSharper disable once PossibleNullReferenceException
            this._audio.PlayOneShot(this.sound45Min);
        }

        public void PlayHour() {
            // ReSharper disable once PossibleNullReferenceException
            this._audio.PlayOneShot(this.soundHour);
        }

        public void PlayTest0Min() {
            Debug.Log("正時鐘をテスト...");
            this.SendCustomEvent(nameof(this.Play0Min));
        }

        public void PlayTest15Min() {
            Debug.Log("15分鐘をテスト...");
            this.SendCustomEvent(nameof(this.Play15Min));
        }

        public void PlayTest30Min() {
            Debug.Log("半時鐘をテスト...");
            this.SendCustomEvent(nameof(this.Play30Min));
        }

        public void PlayTest45Min() {
            Debug.Log("45分鐘をテスト...");
            this.SendCustomEvent(nameof(this.Play45Min));
        }

        public void PlayTestHour() {
            Debug.Log("ビッグ・ベンをテスト...");
            var time = DateTime.Now;
            Debug.Log($"現在時刻: {time}");
            var hour = 12 < time.Hour ? time.Hour - 12 : time.Hour == 0 ? 12 : time.Hour;
            Debug.Log($"回数: {hour}");
            for(var i = 0; i < hour; i++) {
                this.SendCustomEventDelayedSeconds(nameof(this.PlayHour), 2.0f * i);
            }
        }
    }
}
