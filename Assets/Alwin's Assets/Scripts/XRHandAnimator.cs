using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace XR {
    public class XRHandAnimator : MonoBehaviour {
        [SerializeField] private ActionBasedController controller;
        [SerializeField] private Animator animator;
        private static readonly int FistBool = Animator.StringToHash("Fist");
        private static readonly int PointBool = Animator.StringToHash("Point");

        private void Start() {
            controller.selectAction.action.started += Point;
            controller.selectAction.action.canceled += PointReleased;

            controller.activateAction.action.started += Fist;
            controller.activateAction.action.canceled += FistReleased;
        }

        private void Fist(InputAction.CallbackContext obj) {
            animator.SetBool(FistBool, true);
        }

        private void FistReleased(InputAction.CallbackContext obj) {
            animator.SetBool(FistBool, false);
        }

        private void Point(InputAction.CallbackContext ctx) {
            animator.SetBool(PointBool, true);
        }
        private void PointReleased(InputAction.CallbackContext obj) {
            animator.SetBool(PointBool, false);
        }

    }
}
