using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour {
	public System.String bulbName;
	public System.String gender;
	public int hunger;
	public int thirst;
	public int sleep;
	public int magic;
	public System.String[] likes = new System.String[3];
	public System.String[] dislikes = new System.String[3];
	public GameManager gameManager;
	
	private BulbMove mover;
	public float feedTime;
	public float testTime;
	public GameObject food;
	public GameObject water;
	
	void Start(){
		mover = GetComponent<BulbMove>();
	}
	
	void Update(){		
		if(gameManager.feed == true && mover.enabled == true){
			mover.enabled = false;
			transform.position = new Vector3(0f,1.5f,0f);
			feedTime = Time.time;
			Instantiate(food);
		}
		if(gameManager.drink == true && mover.enabled == true){
			mover.enabled = false;
			transform.position = new Vector3(0f,1.5f,0f);
			feedTime = Time.time;
			Instantiate(water);
		}
		
		if(Time.time > feedTime + 2f){
			mover.enabled = true;
			gameManager.feed = false;
			gameManager.drink = false;
		}
		
		testTime = Time.time;
	}
}
