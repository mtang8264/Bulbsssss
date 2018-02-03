using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {
	public Material activeMat;
	public Material inactiveMat;
	public bool active = false;
	public ButtonHandler handler;
	
	public GameObject attachedScreen;
	
	void Start(){
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		if(active){
			attachedScreen.SetActive(true);
			sprite.material = activeMat;
		}else{
			attachedScreen.SetActive(false);
			sprite.material = inactiveMat;
		}
	}
	
	void OnMouseDown(){
		handler.ClearButtons();
		active = true;
	}
}
