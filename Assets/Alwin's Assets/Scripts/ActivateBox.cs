using UnityEngine;

namespace Alwin_s_Assets.Scripts {
    public class ActivateBox : MonoBehaviour {
        private Renderer box;

        private void Start() {
            box = GetComponent<Renderer>();
            box.enabled = false;
        }

        private void OnTriggerEnter(Collider other) {
            if (!box.enabled) {
                box.enabled = true;
            }
        }
    }
}
