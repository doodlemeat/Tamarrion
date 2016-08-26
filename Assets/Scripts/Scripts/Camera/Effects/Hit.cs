using UnityEngine;
using System.Collections;

public class Hit : CameraEffect 
{
	public float _mass;
	public float _distance;
	public float _strength;
	public float _damping;
	public Vector3 _position;
	public float _Size = 1.0f;
	public float _speed = 10.0f;

	float _size;
	Math.Spring _posSpring;
	Vector3 _v0;
	Vector3 _diff;

	public override void Init()
	{
		base.Init();
		_posSpring = new Math.Spring();
	}

	public override void OnPlay()
	{
		_posSpring.Setup(_mass, _distance, _strength, _damping);
		_v0 = (_position - _camera.transform.position).normalized;
		_diff = Vector3.zero;
	}

	public override void OnUpdate()
	{
		Vector3 rot = _camera.transform.rotation.eulerAngles;
		_size = _Size;

		float springDistance = _posSpring.Calculate(Time.deltaTime);
		float ratio = 1.0f;

		switch(_fadeState)
		{
			case FadeState.FADE_IN:
				ratio = Math.LerpS3(0.0f, springDistance, _fadeOutNormalized);
				_size = Math.LerpS3(0.0f, _Size, 1.0f - _fadeInNormalized);
				break;
			case FadeState.FADE_OUT:
				ratio = Math.LerpS2(springDistance, 0.0f, _fadeOutNormalized);
				_size = Math.LerpS2(_Size, 0.0f, _fadeOutNormalized);
				break;
		}

		Vector3 v1 = Math.GetVector3(_speed) * _size;
		Vector3 newRot = rot - _diff + v1;
		_diff = v1;
		_camera.transform.rotation = Quaternion.Euler(newRot);
		_camera.transform.position += _v0 * springDistance * ratio;
	}
}
