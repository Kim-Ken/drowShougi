using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Koma:MonoBehaviour {

	 public List<MovePattern> movePatterns;
	 public List<MovePattern> nariMovePatterns;
	 public User masterUser;
	 public int settingturn;
	 public bool kingFlag=false;
	 public bool setFlag=false;
	 public bool nariFlag=false;
	 public bool ableNariFlag=true;
	 
	 public string mozi;
	 public string nariMozi;

	 public int posX;
	 public int posY;
	 [SerializeField]Material BoardMaterial;
	 public TextMesh komaTextMesh;

	 public void setter(int turn,User user){
		 settingturn = turn;
		 masterUser = user;
		 makeMV();
	 }

	void start(){
		makeMV();
	}

	public void nari(){
		komaTextMesh.text =nariMozi;
	}

	public void finishNari(){
		komaTextMesh.text =mozi;
		nariFlag=false;
		komaTextMesh.color=Color.black;
	}

	public abstract void makeMV();

	public void makeMovePattern(int x,int y,int extendNum){
		MovePattern m=new MovePattern();
		m.x=x;
		m.y=y;
		m.ableExtend=extendNum;
		movePatterns.Add(m);
	}

	public void makeNariMovePattern(int x,int y,int extendNum){
		MovePattern m=new MovePattern();
		m.x=x;
		m.y=y;
		m.ableExtend=extendNum;
		nariMovePatterns.Add(m);
	}
	 
	 public void clickKoma(){
		 if(masterUser.hand.Count==0){
			 //Debug.Log("hand empty");
			 if(Board.boardSequesnce=="userATurn"&&masterUser.name=="userA"){
				 Board.komaSetFinishFlag=true;
			 }
			 else if(Board.boardSequesnce=="userBTurn"&&masterUser.name=="userB"){
				 Board.komaSetFinishFlag=true;
			 }
			 
		 }

		 if(masterUser.name+"FirstSet"==Board.boardSequesnce){
			 setFirstKoma();
		 }
		 else if(masterUser.name+"Turn"==Board.boardSequesnce&&!Board.komaSetFinishFlag){
			 setFirstKoma();
		     //Debug.Log("uma");
		 }
		 else if(masterUser.name+"Turn"==Board.boardSequesnce&&Board.komaSetFinishFlag){
		     //Debug.Log("kani");
			 moveKoma();
		 }
		 //Debug.Log(masterUser.name);
	 }


	 public void setFirstKoma(){
		 if(setFlag){
			 //Debug.Log("aa");
			 return;
		 }
		 //Debug.Log("aa");
		 int bigNum=Board.BOARDSIZE;
		 int smallNum=0;
		 if(masterUser.name=="userA"){
			bigNum=2;
		 }
		 else{
			smallNum=3;
		 }
		 
		 for(int i=0;i<Board.BOARDSIZE;i++){
			for(int j=0;j<Board.BOARDSIZE;j++){
				if(smallNum<=j&&j<bigNum){

					if(Board.komaBoard[i,j]==null){
			 	    	Board.panelBoard[i,j].GetComponent<Renderer>().material.color=Color.red;
			 			Board.panelBoard[i,j].GetComponent<Panel>().active="active";
					}
					else{
						Board.panelBoard[i,j].GetComponent<Renderer>().material=BoardMaterial;
			 			Board.panelBoard[i,j].GetComponent<Panel>().active="false";
					}
				}
				else{
					Board.panelBoard[i,j].GetComponent<Renderer>().material=BoardMaterial;
			 		Board.panelBoard[i,j].GetComponent<Panel>().active="false";
				}
			}
		 }

		 
		 Board.choiceKoma=this;
		 Board.choiceKoma.settingturn=Board.turn;
		 //Debug.Log(Board.choiceKoma);
		 Board.choiceFlag=true;
		 setFlag=true;
		 //Board.komaSetFinishFlag=true;
		 
	 }

	 public void moveKoma(){
		if(!setFlag){
			return;
		}
		//Debug.Log(movePatterns);
		List<MovePattern> usedMovePatterns =movePatterns;
		if(nariFlag){
			usedMovePatterns=nariMovePatterns;
		}
		Board.choiceKoma=this;
		for(int i=0;i<Board.BOARDSIZE;i++){
			for(int j=0;j<Board.BOARDSIZE;j++){
				Board.panelBoard[i,j].GetComponent<Renderer>().material=BoardMaterial;
				Board.panelBoard[i,j].GetComponent<Panel>().active="false";
			}
		}
		if(settingturn==Board.turn){
			return;
		}
		foreach(MovePattern mv in usedMovePatterns){
            for (int extendPos = 1; extendPos <= mv.ableExtend; extendPos++)
            {
				
                int movePointX = posX + mv.x*extendPos;
                int movePointY = posY;

                if (masterUser.name == "userA")
                {
                    movePointY += mv.y*extendPos;
                }
                else
                {
                    movePointY -= mv.y*extendPos;
                }

                if (0 <= movePointX && movePointX < Board.BOARDSIZE && 0 <= movePointY && movePointY < Board.BOARDSIZE)
                {
                    if (Board.komaBoard[movePointX, movePointY] == null)
                    {
                        Board.panelBoard[movePointX, movePointY].GetComponent<Renderer>().material.color = Color.red;
                        Board.panelBoard[movePointX, movePointY].GetComponent<Panel>().active = "moveActive";
                    }
                    else if (Board.komaBoard[movePointX, movePointY].masterUser.name != masterUser.name)
                    {
                        //Debug.Log("getMOve");
                        Board.panelBoard[movePointX, movePointY].GetComponent<Renderer>().material.color = Color.red;
                        Board.panelBoard[movePointX, movePointY].GetComponent<Panel>().active = "moveGetActive";
						break;
                    }
					else if(Board.komaBoard[movePointX, movePointY].masterUser.name == masterUser.name){
						break;
					}
                }
            }

			//else{
			//	Board.panelBoard[posX,posY].GetComponent<Renderer>().material=BoardMaterial;
			// 	Board.panelBoard[posX,posY].GetComponent<Panel>().active="false";
			//}
		}
	 }
}


public struct MovePattern{
	public int x;
	public int y;
	public int ableExtend;
}
