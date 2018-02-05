using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	float tim;

	// Use this for initialization
	void Start () {
		tim = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > tim + 2f){
			Destroy(gameObject);
		}
	}
}
