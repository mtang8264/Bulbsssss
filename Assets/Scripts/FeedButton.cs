using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedButton : MonoBehaviour {
	public GameManager gameManager;

	void OnMouseDown(){
		gameManager.Feed(0.1f);
	}
}
