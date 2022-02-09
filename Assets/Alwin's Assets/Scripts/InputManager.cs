using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

namespace Alwin_s_Assets.Scripts {
   public class InputManager : MonoBehaviour {
      [SerializeField] private XRNode xrNode = XRNode.LeftHand;

      private List<InputDevice> _devices = new List<InputDevice>();

      private InputDevice _device;

      void GetDevice() {
         InputDevices.GetDevicesAtXRNode(xrNode,_devices);
         _device = _devices.FirstOrDefault();
      }

      private void Update() {
         if (!_device.isValid) {
            GetDevice();
         }

         List<InputFeatureUsage> featureUsages = new List<InputFeatureUsage>();
         _device.TryGetFeatureUsages(featureUsages);

         foreach (InputFeatureUsage inputFeatureUsage in featureUsages) {
            Debug.Log($"Feature: {inputFeatureUsage.name}, Type: {inputFeatureUsage.type}");
         }
      }
   }
}
