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

		MovePattern m1=new MovePattern();
		m1.x=0;
		m1.y=1;
		m1.ableExtend=1;
		movePatterns.Add(m1);

		MovePattern m2=new MovePattern();
		m2.x=1;
		m2.y=1;
		m2.ableExtend=1;
		movePatterns.Add(m2);

		MovePattern m3=new MovePattern();
		m3.x=1;
		m3.y=0;
		m3.ableExtend=1;
		movePatterns.Add(m3);

		MovePattern m4=new MovePattern();
		m4.x=1;
		m4.y=-1;
		m4.ableExtend=1;
		movePatterns.Add(m4);

		MovePattern m5=new MovePattern();
		m5.x=0;
		m5.y=-1;
		m5.ableExtend=1;
		movePatterns.Add(m5);

		MovePattern m6=new MovePattern();
		m6.x=-1;
		m6.y=-1;
		m6.ableExtend=1;
		movePatterns.Add(m6);

		MovePattern m7=new MovePattern();
		m7.x=-1;
		m7.y=0;
		m7.ableExtend=1;
		movePatterns.Add(m7);

		MovePattern m8=new MovePattern();
		m8.x=-1;
		m8.y=1;
		m8.ableExtend=1;
		movePatterns.Add(m8);
		//Debug.Log(movePatterns);
	}
}
