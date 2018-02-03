using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour {
	public Transform barFiller;
	public float percentageFull;
	public float TIM;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TIM = (int)Time.time;
		barFiller.localScale = new Vector3(0f + percentageFull,1f,1f);
	}
}
