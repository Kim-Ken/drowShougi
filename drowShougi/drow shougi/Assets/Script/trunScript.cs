using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trunScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField]Text text;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text=Board.turn.ToString();
	}
}
