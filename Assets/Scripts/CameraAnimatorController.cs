using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class CameraAnimatorController : MonoBehaviour {
		List<GameObject> _cameraAnimators = new List<GameObject>();
		List<TorchActivator> _torchActivators = new List<TorchActivator>();
		float _activateAnimatorDuration = 2.0f;
		float _activateTimer = 0.0f;
		bool _activated = false;
		int _currentCameraAnimatorIndex = 0;

		CameraController cameraController;
		GameObject hudObject;

		void Start() {
			cameraController = Camera.main.GetComponent<CameraController>();
			hudObject = GameObject.Find("HUD");

			foreach (Transform child in transform) {
				child.gameObject.SetActive(false);
				_cameraAnimators.Add(child.gameObject);
			}

			GameObject[] torchActivators = GameObject.FindGameObjectsWithTag("Torch activators");
			foreach (GameObject torchActivator in torchActivators) {
				TorchActivator activator = torchActivator.GetComponent<TorchActivator>();
				_torchActivators.Add(activator);
			}
		}

		void Update() {
			if (Input.GetButton("LeftTrigger") && Input.GetButton("Spell B") && Input.GetButton("RightTrigger")) {
				hudObject.SetActive(!hudObject.activeSelf);
			}

			if (Input.GetButton("Spell A") && Input.GetButton("Spell B") && Input.GetButton("Spell X") && Input.GetButton("Spell Y")) {
				_activateTimer += Time.deltaTime;
			}
			else {
				_activateTimer = 0.0f;
			}

			if (_activateTimer >= _activateAnimatorDuration) {
				_activateTimer = 0.0f;
				_activated = !_activated;
				UpdateActive();
			}

			if (_activated) {
				if (Input.GetButtonDown("LeftTrigger")) {
					foreach (GameObject o in _cameraAnimators) {
						o.SetActive(false);
					}

					--_currentCameraAnimatorIndex;

					if (_currentCameraAnimatorIndex < 0) {
						_currentCameraAnimatorIndex = _cameraAnimators.Count - 1;
					}

					_cameraAnimators[_currentCameraAnimatorIndex].SetActive(true);

					CameraPathAnimator animator = _cameraAnimators[_currentCameraAnimatorIndex].GetComponent<CameraPathAnimator>();
					animator.Stop();
					animator.Play();

					CameraPathAnimatorClip clip = animator.GetComponentInParent<CameraPathAnimatorClip>();
					if (clip._lightsOn) {
						foreach (TorchActivator torchActivator in _torchActivators) {
							torchActivator.Activate();
						}
					}
					else {
						foreach (TorchActivator torchActivator in _torchActivators) {
							torchActivator.Deactivate();
						}
					}
				}

				if (Input.GetButtonDown("RightTrigger")) {
					foreach (GameObject o in _cameraAnimators) {
						o.SetActive(false);
					}

					++_currentCameraAnimatorIndex;

					if (_currentCameraAnimatorIndex > _cameraAnimators.Count - 1) {
						_currentCameraAnimatorIndex = 0;
					}

					_cameraAnimators[_currentCameraAnimatorIndex].SetActive(true);
					CameraPathAnimator animator = _cameraAnimators[_currentCameraAnimatorIndex].GetComponent<CameraPathAnimator>();
					animator.Stop();
					animator.Play();

					CameraPathAnimatorClip clip = animator.GetComponentInParent<CameraPathAnimatorClip>();
					if (clip._lightsOn) {
						foreach (TorchActivator torchActivator in _torchActivators) {
							torchActivator.Activate();
						}
					}
					else {
						foreach (TorchActivator torchActivator in _torchActivators) {
							torchActivator.Deactivate();
						}
					}
				}
			}
		}

		void UpdateActive() {
			if (_activated) {
				cameraController.enabled = false;
				hudObject.SetActive(false);

				if (_cameraAnimators.Count > 0) {
					_cameraAnimators[_currentCameraAnimatorIndex].SetActive(true);

					CameraPathAnimator animator = _cameraAnimators[_currentCameraAnimatorIndex].GetComponent<CameraPathAnimator>();
					animator.Stop();
					animator.Play();

					CameraPathAnimatorClip clip = animator.GetComponentInParent<CameraPathAnimatorClip>();
					if (clip._lightsOn) {
						foreach (TorchActivator torchActivator in _torchActivators) {
							torchActivator.Activate();
						}
					}
					else {
						foreach (TorchActivator torchActivator in _torchActivators) {
							torchActivator.Deactivate();
						}
					}
				}
			}
			else {
				cameraController.enabled = true;
				hudObject.SetActive(true);

				foreach (GameObject o in _cameraAnimators) {
					o.SetActive(false);
				}
			}
		}
	}
}