using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {
	public GameButton[] buttons;
	private int currentMenu;
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i< buttons.Length; i ++){
			if(buttons[i].active){
				currentMenu = i;
				break;
			}
		}
	}
	
	public void ClearButtons(){
		for(int i = 0;i < buttons.Length; i ++){
			buttons[i].active = false;
		}
	}
}
