using UnityEngine;
using System.Collections;

public abstract class CameraEffect : MonoBehaviour 
{
	public bool _isPlaying;
	public bool _loop;
	
	protected float _timeout;
	protected float _timeoutNormalized;
	protected float _fadeInNormalized;
	protected float _fadeOutNormalized;
	public float _length = 1.0f;
	public float _fadeIn = 0.5f;
	public float _fadeOut = 0.5f;
	protected FadeState _fadeState;
	protected Camera _camera;
	bool _isStarted = false;

	protected enum FadeState
	{
		FADE_IN,
		FULL,
		FADE_OUT
	}

	void Start()
	{
		if(!_camera)
		{
			CameraEffectManager.Instance.Register(this);
			Init();
		}
	}

	public virtual void Init()
	{
		_camera = Camera.main;
		_isPlaying = false;
	}

	public void Play()
	{
		_isStarted = true;
		_isPlaying = true;
		_timeout = 0.0f;
		_fadeIn = Mathf.Clamp(_fadeIn, 0.0f, _length);
		_fadeOut = Mathf.Clamp(_fadeOut, 0.0f, _length);

		OnPlay();
	}

	public void Stop()
	{
		_isStarted = false;
		_isPlaying = false;
		OnStop();
	}

	public void Delete()
	{
		CameraEffectManager.Instance.Delete(this);
	}

	public virtual void OnPlay()
	{ }
	public virtual void OnStop()
	{ }
	public virtual void OnUpdate()
	{ }

	public void PostUpdate()
	{
		if (!_isStarted)
		{
			Play();
			return;
		}

		_timeout += Time.deltaTime;
		_timeoutNormalized = Mathf.Clamp01(_timeout / _length);

		_fadeState = FadeState.FULL;

		if(_fadeIn > 0.0f)
		{
			if(_timeout < _fadeIn)
			{
				_fadeInNormalized = _timeout / _fadeIn;
				_fadeState = FadeState.FADE_IN;
			}
			else
			{
				_fadeInNormalized = 1.0f;
			}
		}

		if(_fadeOut > 0.0f)
		{
			if(_timeout > _length - _fadeOut)
			{
				_fadeOutNormalized = (_timeout - (_length - _fadeOut)) / _fadeOut;
				_fadeState = FadeState.FADE_OUT;
			}
			else
			{
				_fadeOutNormalized = 0.0f;
			}
		}

		if(_timeout > _length)
		{
			if(_loop)
			{
				Play();
			}
			else
			{
				Stop();
			}
		}

		OnUpdate();
	}
}
