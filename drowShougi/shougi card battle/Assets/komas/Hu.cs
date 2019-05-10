using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hu : Koma {

	[SerializeField]int t=0;
	public override void makeMV(){
		
		movePatterns=new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();

		mozi="歩";
		nariMozi="と";
		

		makeMovePattern(0,1,1);

		makeNariMovePattern(0,1,1);
		makeNariMovePattern(1,1,1);
		makeNariMovePattern(1,0,1);
		makeNariMovePattern(0,-1,1);
		makeNariMovePattern(-1,0,1);
		makeNariMovePattern(-1,1,1);
	}
	
}
