using UnityEngine;
using System.Collections;

public class Rumble : CameraEffect 
{
	public float _Size = 1.0f;
	public float _speed = 10.0f;
    public bool _useDmgSize = false;
    public static float _damageSize = 50;

	Vector3 _diff;
	float _size;

	public override void OnPlay()
	{
        _diff = Vector2.zero;

        if (_useDmgSize)
            _size = _damageSize;
	}

	public override void OnUpdate()
	{
		Vector3 rot = _camera.transform.rotation.eulerAngles;
        
		switch(_fadeState)
		{
			case FadeState.FADE_IN:
				_size = Math.LerpS3(0.0f, _Size, 1.0f - _fadeInNormalized);
				break;
			case FadeState.FADE_OUT:
				_size = Math.LerpS2(_Size, 0.0f, _fadeOutNormalized);
				break;
			case FadeState.FULL:
				_size = _Size;
				break;
		}

		Vector3 v0 = Math.GetVector3(_speed) * _size;
		Vector3 newRot = rot - _diff + v0;
		_diff = v0;

		_camera.transform.rotation = Quaternion.Euler(newRot);
	}
}
