using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public Transform target;
	
	void Start () {
	
	}

	void Update () {

		float translation = Time.deltaTime * 2;
		transform.Translate(translation, 0, 0);

	}
}
