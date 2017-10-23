using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	LineRenderer line;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = true;
	}

	public void OnTriggerEnter(Collider col){
		// Kill the player when he hits the laser
		Character_data cd = col.GetComponent<Character_data> ();
		if (cd != null) {
			cd.kill ();
		}
	}
}
