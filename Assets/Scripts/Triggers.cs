using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		this.collider2D.enabled = false;
	}
}
