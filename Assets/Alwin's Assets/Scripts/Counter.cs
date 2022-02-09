using UnityEngine;
using UnityEngine.UI;

namespace Alwin_s_Assets.Scripts {
    public class Counter : MonoBehaviour {
        public Image counterImageFill;

        public void SetImageFill(float fillAmt, float totalAmt) {
            counterImageFill.fillAmount = fillAmt / totalAmt;
        }
    }
}
