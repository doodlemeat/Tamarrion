using UnityEngine;
using System.Collections;

public class LineFollow : MonoBehaviour {

	LineRenderer myLine;
	Transform target;
	GameObject niht;

	// Use this for initialization
	void Start () 
	{
		niht = GameObject.Find ("6_1");
		myLine = GetComponent<LineRenderer> ();
		myLine.SetVertexCount (2);
		target = niht.transform.Find ("Nihteana_Animations_COMPLETE/hips");
	}
	
	// Update is called once per frame
	void Update () 
	{
		myLine.SetPosition (0, transform.position);
		myLine.SetPosition (1, target.position);
		float distance = Vector3.Distance (transform.position, target.position);
		myLine.material.mainTextureScale = new Vector2 (distance * 2, 1);

	}
}
