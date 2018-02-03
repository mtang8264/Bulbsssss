using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	Bulb bulb;
	Text nameText;
	
	int checkTime = 1;
	float hunger;
	float thirst;
	float sleep;
	
	StatBar hungerBar;
	StatBar thirstBar;
	StatBar sleepBar;
	bool tick = true;
	
	// Use this for initialization
	void Start () {
		hunger = 1f;
		thirst = 1f;
		sleep = 1f;
		checkTime = 600;
	}
	
	// Update is called once per frame
	void Update () {
		//Assign missing variables
		if(bulb == null){
			bulb = GameObject.FindWithTag("Bulb").GetComponent<Bulb>();
		}
		if(nameText == null){
			nameText = GameObject.Find("UIName").GetComponent<Text>();
		}
		if(hungerBar == null){
			hungerBar = GameObject.Find("StatScreen/HungerBar").GetComponent<StatBar>();
			thirstBar = GameObject.Find("StatScreen/ThirstBar").GetComponent<StatBar>();
			sleepBar = GameObject.Find("StatScreen/SleepBar").GetComponent<StatBar>();
		}
		
		//Actual Updated function stuff
		nameText.text = bulb.bulbName;
		
		if((int)Time.time % checkTime == 0){
			if(tick){
				hunger -= 0.01f*bulb.hunger;
				thirst -= 0.01f*bulb.thirst;
				sleep -= 0.01f*bulb.sleep;
				tick = false;
			}
		}else{
			tick = true;
		}
		
		if(hunger < 0){
			hunger = 0;
		}
		if(thirst < 0){
			thirst = 0;
		}
		if(sleep < 0){
			sleep = 0;
		}
		
		hungerBar.percentageFull = hunger;
		thirstBar.percentageFull = thirst;
		sleepBar.percentageFull = sleep;
	}
}
