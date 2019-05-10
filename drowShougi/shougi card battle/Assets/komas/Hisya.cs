using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hisya :Koma {


	public override void makeMV(){
		
		movePatterns=new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();

		mozi="飛";
		nariMozi="龍";
		

		makeMovePattern(0,1,5);
		makeMovePattern(1,0,5);
		makeMovePattern(-1,0,5);
		makeMovePattern(0,-1,5);

		makeNariMovePattern(1, 1, 1);
        makeNariMovePattern(-1, 1, 1);
        makeNariMovePattern(1, -1, 1);
        makeNariMovePattern(-1, -1, 1);

        makeNariMovePattern(1,0,5);
        makeNariMovePattern(0,1,5);
        makeNariMovePattern(-1,0,5);
        makeNariMovePattern(0,-1,5);
	}
}
