using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbMove : MonoBehaviour {
	float startTime;
	float journeyLength;
	bool moving = false;
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 10f;
	
	public Animator anim;
	bool updated = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		//set unset variables
		if (anim == null){
			anim = gameObject.GetComponent<Animator>();
		}
		if (startMarker == null){
			startMarker = GameObject.FindWithTag("Start").GetComponent<Transform>();
		}
		if (endMarker == null){
			endMarker = GameObject.FindWithTag("End").GetComponent<Transform>();
		}
		
		if(moving){
			if(endMarker.position.x > transform.position.x){
				transform.localScale = new Vector3(-1,1,1);
			}else{
				transform.localScale = new Vector3(1,1,1);
			}
			
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			
			if(transform.position == endMarker.position){
				moving = false;
				updated = false;
			}
		}else{
			if(Random.value > 0.98){
				moving = true;
				updated = false;
				startTime = Time.time;
				RandomTravelPoint();
				journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
			}
		}
		
		if(moving && !updated){
			updated = true;
			anim.CrossFade("Move",0f);
		}else if(!moving && !updated){
			updated = true;
			anim.CrossFade("Idle",0f);
		}
		
	}
	
	void RandomTravelPoint(){
		startMarker.position = transform.position;
		float dist = Random.value;
		if(transform.position.x > 0){
			endMarker.position = new Vector3(transform.position.x - dist*2,1.5f,1.5f);
		}else{
			endMarker.position = new Vector3(transform.position.x + dist*2,1.5f,1.5f);
		}
	}
}
