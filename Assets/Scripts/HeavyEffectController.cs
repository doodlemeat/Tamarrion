using UnityEngine;
using System.Collections;

public class HeavyEffectController : MonoBehaviour 
{
	public float _timeout = 1.0f;
	//Animation _animation;
	float _timer = 0.0f;

	void Start () 
	{
		//_animation = GetComponent<Animation>();
	}
	
	void Update () 
	{
			_timer += Time.deltaTime;

		if (_timer >= _timeout) 
		{
			Destroy(this.gameObject);
		}
	}
}
