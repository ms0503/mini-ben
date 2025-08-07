using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace MiniBen {
    public class LiteSync : UdonSharpBehaviour {
        [Header("処理間隔")]
        [SerializeField]
        private float interval;

        [UdonSynced]
        private Vector3 _syncedPos;

        [UdonSynced]
        private Quaternion _syncedRot;

        private void Start() {
            if(this.interval <= 0) {
                Debug.Log("処理間隔には0より大きい数を指定してください。");
            } else {
                this.Sync();
            }
        }

        public void Sync() {
            if(Networking.IsOwner(this.gameObject)) {
                this._syncedPos = this.transform.position;
                this._syncedRot = this.transform.rotation;
                this.RequestSerialization();
            } else {
                this.transform.position = this._syncedPos;
                this.transform.rotation = this._syncedRot;
            }
            this.SendCustomEventDelayedSeconds(nameof(this.Sync), this.interval);
        }
    }
}
