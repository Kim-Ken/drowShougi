using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ou : Koma {

	// Use this for initialization
	public  override void makeMV(){
		
		mozi="王";
		nariMozi="king";

		movePatterns = new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();
		kingFlag =true;
		ableNariFlag=false;

		makeMovePattern(0,1,1);
		makeMovePattern(1,1,1);
		makeMovePattern(1,0,1);
		makeMovePattern(1,-1,1);
		makeMovePattern(0,-1,1);
		makeMovePattern(-1,-1,1);
		makeMovePattern(-1,0,1);
		makeMovePattern(-1,1,1);
		//Debug.Log(movePatterns);
	}
}
