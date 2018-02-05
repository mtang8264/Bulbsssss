using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	Bulb bulb;
	Text nameText;
	Text genderText;
	Text levelText;
	
	int checkTime = 1;
	float hunger;
	float thirst;
	float sleep;
	
	StatBar hungerBar;
	StatBar thirstBar;
	StatBar sleepBar;
	bool tick = true;
	public bool feed = false;
	public bool drink = false;
	
	BulbIndex bulbIndex;
	
	
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
		if(bulbIndex == null){
			bulbIndex = GameObject.FindWithTag("BulbIndex").GetComponent<BulbIndex>();
		}
		if(bulb == null){
			bulb = GameObject.FindWithTag("Bulb").GetComponent<Bulb>();
		}
		if(nameText == null){
			nameText = GameObject.Find("UIName").GetComponent<Text>();
			genderText = GameObject.Find ("UIGender").GetComponent<Text> ();
			levelText = GameObject.Find ("UILevel").GetComponent<Text> ();
		}
		if(hungerBar == null){
			hungerBar = GameObject.Find("StatScreen/HungerBar").GetComponent<StatBar>();
			thirstBar = GameObject.Find("StatScreen/ThirstBar").GetComponent<StatBar>();
			sleepBar = GameObject.Find("StatScreen/SleepBar").GetComponent<StatBar>();
		}
		
		//Actual Updated function stuff
		nameText.text = bulb.bulbName;
		genderText.text = bulb.gender;
		levelText.text = "" + bulb.magic;
		
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
		if (hunger > 1) {
			hunger = 1;
		}
		if (thirst > 1) {
			thirst = 1;
		}
		if (sleep > 1) {
			sleep = 1;
		}
		
		hungerBar.percentageFull = hunger;
		thirstBar.percentageFull = thirst;
		sleepBar.percentageFull = sleep;
	}

	public void Feed(float amount){
		hunger += amount;
	}
	public void Drink(float amount){
		thirst += amount;
	}
}
