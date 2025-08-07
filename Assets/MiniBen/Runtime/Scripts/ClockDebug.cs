using UdonSharp;
using UnityEngine;

namespace MiniBen {
    public class ClockDebug : UdonSharpBehaviour {
        [Header("ボタン種")]
        [SerializeField]
        private ButtonType type;

        private Clock _clock;

        private void Start() {
            this._clock = this.GetComponentInParent<Clock>();
        }

        public override void Interact() {
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            // ReSharper disable push PossibleNullReferenceException
            switch(this.type) {
                case ButtonType.Zero:
                    this._clock.PlayTest0Min();
                    break;
                case ButtonType.Quarter:
                    this._clock.PlayTest15Min();
                    break;
                case ButtonType.Half:
                    this._clock.PlayTest30Min();
                    break;
                case ButtonType.ThreeQuarter:
                    this._clock.PlayTest45Min();
                    break;
                case ButtonType.Hour:
                    this._clock.PlayTestHour();
                    break;
            }
            // ReSharper disable pop PossibleNullReferenceException
        }
    }

    internal enum ButtonType {
        Zero,
        Quarter,
        Half,
        ThreeQuarter,
        Hour
    }
}
