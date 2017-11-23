using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
	public static int count = 0;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void SetCountText(){
		countText.text = "Caught: " + count.ToString();
		if (count >= 10) {
			winText.text = "You Win!";
		}
	}

	// Update is called once per frame
	void Update () {
		SetCountText ();
	}
}
