using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gin : Koma{

	public  override void makeMV(){
		movePatterns = new List<MovePattern>();
		nariMovePatterns = new List<MovePattern>();
		mozi="銀";
		nariMozi="全";

		makeMovePattern(0,1,1);
		makeMovePattern(1,1,1);
		makeMovePattern(-1,-1,1);
		makeMovePattern(1,-1,1);
		makeMovePattern(-1,1,1);

		makeNariMovePattern(0,1,1);
		makeNariMovePattern(1,1,1);
		makeNariMovePattern(1,0,1);
		makeNariMovePattern(0,-1,1);
		makeNariMovePattern(-1,0,1);
		makeNariMovePattern(-1,1,1);
	}
}