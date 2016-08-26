// C#
using System;
using UnityEngine;


public class LookAtTarget : MonoBehaviour
{
	private Transform target;

    void Start() {
        target = desecration_lookatthis.instance;
    }
	void Update()
	{
		if(target != null)
		{
			transform.LookAt(target);
		}
	}
	
}