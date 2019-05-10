using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaku : Koma
{


    public override void makeMV()
    {

        movePatterns = new List<MovePattern>();
        nariMovePatterns = new List<MovePattern>();

        mozi="角";
		nariMozi="馬";


        makeMovePattern(1, 1, 5);
        makeMovePattern(-1, 1, 5);
        makeMovePattern(1, -1, 5);
        makeMovePattern(-1, -1, 5);

        makeNariMovePattern(1, 1, 5);
        makeNariMovePattern(-1, 1, 5);
        makeNariMovePattern(1, -1, 5);
        makeNariMovePattern(-1, -1, 5);

        makeNariMovePattern(1,0,1);
        makeNariMovePattern(0,1,1);
        makeNariMovePattern(-1,0,1);
        makeNariMovePattern(0,-1,1);

        
    }
}
