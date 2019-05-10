using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kin : Koma {

	// Use this for initialization
	public  override void makeMV(){
		mozi="金";
		nariMozi="gold";

		ableNariFlag=false;
		movePatterns = new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();
		kingFlag =false;

		makeMovePattern(0,1,1);
		makeMovePattern(1,1,1);
		makeMovePattern(1,0,1);
		makeMovePattern(0,-1,1);
		makeMovePattern(-1,0,1);
		makeMovePattern(-1,1,1);
	}
}
