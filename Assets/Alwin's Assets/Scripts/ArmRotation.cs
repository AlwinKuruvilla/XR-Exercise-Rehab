using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace Alwin_s_Assets.Scripts {
	public class ArmRotation : MonoBehaviour {
		private Initialization _armInit;

		[SerializeField] private TextMeshProUGUI instructions;
		[SerializeField] private GameObject circle;
		[SerializeField] private Counter repCounter;
		[SerializeField] private Counter setCounter;
		[SerializeField] private int repTotal = 10;
		[SerializeField] private int setTotal = 3;

		private bool _leftTriggerButtonAction;
		private bool _rightTriggerButtonAction;
		private Vector3 _leftHandInitPos;
		private Vector3 _rightHandInitPos;
		private InputDevice _leftHand;
		private InputDevice _rightHand;
		private bool _circlesCreated;
		private int _leftCount = 0;
		private int _rightCount = 0;
		private List<GameObject> _leftCirclePoints;
		private List<GameObject> _rightCirclePoints;
		private float _repCount = 0;
		private float _setCount = 0;
		private GameObject _leftCircle;
		private GameObject _rightCircle;

		private void Start() {
			instructions.text = "Please place the controllers out in front of you and press the trigger";
			repCounter.SetImageFill(_repCount, repTotal);
			setCounter.SetImageFill(_setCount, setTotal);
		}

		private void Update() {
			if (_leftHandInitPos == Vector3.zero && _rightHandInitPos == Vector3.zero) {
				InitializeArmPosition();
			}
			else {
				if (!_circlesCreated) {
					instructions.text = ($"Initialization set! Values: L={_leftHandInitPos}, R={_rightHandInitPos}\n" +
					                     $"Please hold the trigger at move the controllers in a circular motion");
					CreateCircle();
				}
			}

			if (_circlesCreated) {
				_leftCount = 0;
				_rightCount = 0;
				foreach (GameObject leftCirclePoint in _leftCirclePoints) {
					if (leftCirclePoint.GetComponent<Renderer>().enabled == true) {
						_leftCount++;
					}
				}

				foreach (GameObject rightCirclePoint in _rightCirclePoints) {
					if (rightCirclePoint.GetComponent<Renderer>().enabled == true) {
						_rightCount++;
					}
				}

				if (_leftCount == _leftCirclePoints.Count && _rightCount == _rightCirclePoints.Count) {
					_repCount++;
					repCounter.SetImageFill(_repCount, repTotal);
					if ((int)_repCount == repTotal) {
						_setCount++;
						setCounter.SetImageFill(_setCount, setTotal);
						if ((int)_setCount == setTotal) {
							if(_leftCircle != null) Destroy(_leftCircle);
							if(_rightCircle != null) Destroy(_rightCircle);
							instructions.text = "CONGRATULATIONS! YOU HAVE FINISHED!";
						}
						_repCount = 0;
						repCounter.SetImageFill(_repCount, repTotal);
					}
					ResetPoints();
				}
			}

		}

		private void ResetPoints() {
			foreach (GameObject leftCirclePoint in _leftCirclePoints) {
				leftCirclePoint.GetComponent<Renderer>().enabled = false;
			}
			foreach (GameObject rightCirclePoint in _rightCirclePoints) {
				rightCirclePoint.GetComponent<Renderer>().enabled = false;
			}
		}

		private void CreateCircle() {
			_leftCircle = Instantiate(circle, _leftHandInitPos + new Vector3(0,0, 0.2f), Quaternion.identity * Quaternion.Euler(90,0,0));
			_rightCircle = Instantiate(circle, _rightHandInitPos + new Vector3(0,0, 0.2f), Quaternion.identity * Quaternion.Euler(90,0,0));
			// _leftCircle = Instantiate(circle, _leftHandInitPos, Quaternion.identity);
			// _rightCircle = Instantiate(circle, _rightHandInitPos, Quaternion.identity);
			_leftCirclePoints = _leftCircle.GetComponent<Circle>().points;
			_rightCirclePoints = _rightCircle.GetComponent<Circle>().points;
			_rightCirclePoints.Reverse();
			_circlesCreated = true;
		}

		private void InitializeArmPosition() {
			_leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
			_rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
			if (_leftHand.TryGetFeatureValue(CommonUsages.triggerButton, out _leftTriggerButtonAction) && _leftTriggerButtonAction && _rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out _rightTriggerButtonAction) && _rightTriggerButtonAction) {
				_leftHand.TryGetFeatureValue(CommonUsages.devicePosition, out _leftHandInitPos);
				_rightHand.TryGetFeatureValue(CommonUsages.devicePosition, out _rightHandInitPos);
			}
		}

		public void Reinitialize() {
			_leftHandInitPos = Vector3.zero;
			_rightHandInitPos = Vector3.zero;
			_circlesCreated = false;
			if(_leftCircle != null) Destroy(_leftCircle);
			if(_rightCircle != null) Destroy(_rightCircle);
			_setCount = 0;
			_repCount = 0;
			repCounter.SetImageFill(_repCount, repTotal);
			setCounter.SetImageFill(_setCount, setTotal);
			instructions.text = "Please place the controllers out in front of you and press the trigger";
		}
	}
}
