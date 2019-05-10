using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyousya :Koma {

	[SerializeField]int t=0;
	public override void makeMV(){
		
		movePatterns=new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();
		
		mozi="香";
		nariMozi="杏";

		makeMovePattern(0,1,5);

		makeNariMovePattern(0,1,1);
		makeNariMovePattern(1,1,1);
		makeNariMovePattern(1,0,1);
		makeNariMovePattern(0,-1,1);
		makeNariMovePattern(-1,0,1);
		makeNariMovePattern(-1,1,1);
	}
	
}
