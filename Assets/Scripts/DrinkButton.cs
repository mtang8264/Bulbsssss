using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkButton : MonoBehaviour {
	public GameManager gameManager;

	void OnMouseDown(){
		gameManager.Drink(0.01f);
		gameManager.drink = true;
	}
}
