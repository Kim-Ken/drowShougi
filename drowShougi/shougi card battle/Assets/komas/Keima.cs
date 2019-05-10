using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keima : Koma {

	// Use this for initialization
	public  override void makeMV(){
		movePatterns = new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();

		mozi="桂";
		nariMozi="圭";

		makeMovePattern(1,2,1);
		makeMovePattern(-1,2,1);
		
		makeNariMovePattern(0,1,1);
		makeNariMovePattern(1,1,1);
		makeNariMovePattern(1,0,1);
		makeNariMovePattern(0,-1,1);
		makeNariMovePattern(-1,0,1);
		makeNariMovePattern(-1,1,1);
	}


}
