using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ValacAnimationEventHandler : MonoBehaviour 
{
	// Footstep
	AudioSource _footstepSource;
	public GameObject _footstepSourceObject;

	// Slam
	AudioSource _slamSource;
	public GameObject _slamSourceObject;

	// Whirlwind
	AudioSource _whirlwindSource;
	public GameObject _whirlwindSourceObject;

	// Chopchop
	AudioSource _chopchopSource;
	public GameObject _chopchopSourceObject;
	public List<AudioClip> _chopSounds = new List<AudioClip>();

	// Cleave
	AudioSource _cleaveSource;
	public GameObject _cleaveSourceObject;
	public AudioClip _cleaveStartSound;
	public AudioClip _cleaveEndSound;

    public GameObject _footstepDustParticles;

	void Start()
	{
		_footstepSource = _footstepSourceObject.GetComponent<AudioSource>();
		_slamSource = _slamSourceObject.GetComponent<AudioSource>();
		_whirlwindSource = _whirlwindSourceObject.GetComponent<AudioSource>();
		_chopchopSource = _chopchopSourceObject.GetComponent<AudioSource>();
		_cleaveSource = _cleaveSourceObject.GetComponent<AudioSource>();
	}

	public void OnStep()
	{
		_footstepSource.pitch = Random.Range(0.7f, 1.3f);
		_footstepSource.Play();
        if (_footstepDustParticles)
        {
            GameObject tmp = Instantiate(_footstepDustParticles);
            tmp.transform.SetParent(gameObject.transform);
            tmp.transform.localPosition = Vector3.zero;
        }
        else
            Debug.LogError("no particle effect @ boss step");
	}

	public void OnSlamDown()
	{
		_slamSource.Play();
	}

	public void OnWhirlwindStart()
	{
		_whirlwindSource.Play();
	}

	public void OnChopChop()
	{
		int soundIndex = Random.Range(1, _chopSounds.Count - 1);
		_chopchopSource.clip = _chopSounds[soundIndex];
		_chopchopSource.Play();
		AudioClip tmp = _chopSounds[0];
		_chopSounds[0] = _chopSounds[soundIndex];
		_chopSounds[soundIndex] = tmp;
	}

	public void OnCleaveStart()
	{
		_cleaveSource.clip = _cleaveStartSound;
		_cleaveSource.Play();
	}

	public void OnCleaveEnd()
	{
		_cleaveSource.clip = _cleaveEndSound;
		_cleaveSource.Play();
	}
}
