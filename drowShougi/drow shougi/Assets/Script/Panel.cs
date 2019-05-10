using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {

	public string active="false";
	string[] strXY;
	int x=0;
	int y=0;
	[SerializeField]Material BoardMaterial;
	[SerializeField]Koma kkk;

	
	void Start () {
		strXY=this.name.Split(',');
		x=int.Parse(strXY[0]);
		y=int.Parse(strXY[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click(){
		if(active=="active"){
			komaSet();
		}

		else if(active=="moveActive"){
			//Debug.Log("active:"+Board.choiceKoma+":"+this.name);
			Board boardInstance=Board.choiceKoma.masterUser.boardInstance;
			Board.komaBoard[x,y]=Board.choiceKoma;
			Board.komaBoard[Board.choiceKoma.posX,Board.choiceKoma.posY]=null;
			Board.choiceKoma.posX=x;
			Board.choiceKoma.posY=y;
			Koma removeKoma=Instantiate(kkk);
			foreach(Koma k in Board.choiceKoma.masterUser.hand){
				if(Board.choiceKoma.name==k.name){
					removeKoma=k;
				}
			}
			Board.choiceKoma.masterUser.hand.Remove(removeKoma);
			if(Board.choiceKoma.masterUser.hand.Count==0){
				if(Board.choiceKoma.masterUser.name=="userA"){
					Board.userAFirstSetFlag=true;
				}
				else{
					Board.userBFirstSetFlag=true;
				}
				if(Board.userAFirstSetFlag&&Board.userBFirstSetFlag&&!Board.firstKomaSetFlag){
					if(Board.choiceKoma.masterUser.name=="userA"){
						Board.boardSequesnce="userB" +"Turn";
					}
					else if(Board.choiceKoma.masterUser.name=="userB"){
						Board.boardSequesnce="userA" +"Turn";
					}
					Board.firstKomaSetFlag=true;
				}
			}
			Board.choiceKoma.masterUser.setCardPos();
			Vector3 ps=Board.choiceKoma.transform.position;
			ps.x=x;
			ps.z=y;
			Board.choiceKoma.transform.position=ps;
			if(Board.choiceKoma.masterUser.name=="userB"){
				//Board.choiceKoma.transform.Rotate(0,180,0);
			}

			for(int i=0;i<Board.BOARDSIZE;i++){
				for(int j=0;j<Board.BOARDSIZE;j++){
					Board.panelBoard[i,j].GetComponent<Renderer>().material=BoardMaterial;
			 		Board.panelBoard[i,j].GetComponent<Panel>().active="false";
				}
		 	}
			if(Board.boardSequesnce=="userATurn"){
				Board.boardSequesnce="userBTurn";
				if(Board.turn%2==1){
		    	    boardInstance.userB.draw();
                }
				Board.komaMoveFinishFlag=false;
				Board.komaSetFinishFlag=false;
			}
			else if(Board.boardSequesnce=="userBTurn"){
				Board.boardSequesnce="userATurn";
                Board.turn++;
                if(Board.turn%2==1){
				    boardInstance.userA.draw();
                }
				Board.komaMoveFinishFlag=false;
				Board.komaSetFinishFlag=false;
			}

			komaNari(x,y);
		}
		else if(active=="moveGetActive"){
			getKomaAndMove();
		}
		else{
			//Debug.Log("not active");
		}

	}


    void komaNari(int x, int y)
    {
        int nariRange = 2;
        if (Board.choiceKoma.masterUser.name == "userA")
        {
            nariRange = 2;
            if (nariRange < y&&Board.choiceKoma.ableNariFlag)
            {
               // Debug.Log("usera nari");
                Board.choiceKoma.nariFlag = true;
                Board.choiceKoma.komaTextMesh.color = Color.red;
				Board.choiceKoma.nari();
            }

        }
        else if (Board.choiceKoma.masterUser.name == "userB")
        {
            if (nariRange > y&&Board.choiceKoma.ableNariFlag)
            {
                //Debug.Log("userb nari");
                Board.choiceKoma.nariFlag = true;
                Board.choiceKoma.komaTextMesh.color = Color.red;
				Board.choiceKoma.nari();
            }

        }

    }

    void getKomaAndMove()
    {
        //Debug.Log("active:" + Board.choiceKoma + ":" + this.name);
        Board boardInstance = Board.choiceKoma.masterUser.boardInstance;
        Koma tmpKoma;

        tmpKoma = Board.komaBoard[x, y];
        Board.komaBoard[x, y] = Board.choiceKoma;
        Board.komaBoard[Board.choiceKoma.posX, Board.choiceKoma.posY] = null;

        Board.choiceKoma.posX = x;
        Board.choiceKoma.posY = y;

        Koma removeKoma = Instantiate(kkk);
        Koma tKoma = removeKoma;

        foreach (Koma k in Board.choiceKoma.masterUser.hand)
        {
            if (Board.choiceKoma.name == k.name)
            {
                removeKoma = k;
            }
        }

        Board.choiceKoma.masterUser.hand.Remove(removeKoma);
        Destroy(tKoma);

        /*if (Board.choiceKoma.masterUser.hand.Count == 0)
        {
            if (Board.choiceKoma.masterUser.name == "userA")
            {
                Board.userAFirstSetFlag = true;
            }
            else
            {
                Board.userBFirstSetFlag = true;
            }
            if (Board.userAFirstSetFlag && Board.userBFirstSetFlag )
            {
                /*if (Board.choiceKoma.masterUser.name == "userA")
                {
                    Board.boardSequesnce = "userB" + "Turn";
                }
                else if (Board.choiceKoma.masterUser.name == "userB")
                {
                    Board.boardSequesnce = "userA" + "Turn";
                }
                Board.firstKomaSetFlag = true;
                Board.turn = 1;
                //Board.turn = 1;
				Debug.Log("angent one");
            }
        }*/


        Vector3 ps = Board.choiceKoma.transform.position;
        ps.x = x;
        ps.z = y;
        Board.choiceKoma.transform.position = ps;

        if (tmpKoma.kingFlag)
        {
            Debug.Log(Board.choiceKoma.masterUser.name + " win");
        }
        if (Board.choiceKoma.masterUser.name == "userB")
        {
            //Board.choiceKoma.transform.Rotate(0,180,0);
            tmpKoma.masterUser = Board.choiceKoma.masterUser;
            tmpKoma.setFlag = false;
            Board.choiceKoma.masterUser.hand.Add(tmpKoma);
            tmpKoma.finishNari();
        }

        else
        {
            tmpKoma.masterUser = Board.choiceKoma.masterUser;
            tmpKoma.setFlag = false;
            tmpKoma.transform.Rotate(0, 180, 0);
            tmpKoma.finishNari();
            Board.choiceKoma.masterUser.hand.Add(tmpKoma);

        }




        Board.choiceKoma.masterUser.setCardPos();

        Board.choiceKoma.transform.position = ps;
        if (Board.choiceKoma.masterUser.name == "userB")
        {
            //Board.choiceKoma.transform.Rotate(0,180,0);
        }

        for (int i = 0; i < Board.BOARDSIZE; i++)
        {
            for (int j = 0; j < Board.BOARDSIZE; j++)
            {
                Board.panelBoard[i, j].GetComponent<Renderer>().material = BoardMaterial;
                Board.panelBoard[i, j].GetComponent<Panel>().active = "false";
            }
        }
        if (Board.boardSequesnce == "userATurn")
        {
            Board.boardSequesnce = "userBTurn";

            boardInstance.userB.draw();

            Board.komaMoveFinishFlag = false;
            Board.komaSetFinishFlag = false;
        }
        else if (Board.boardSequesnce == "userBTurn")
        {
            Board.boardSequesnce = "userATurn";

            boardInstance.userA.draw();
            Board.komaMoveFinishFlag = false;
            Board.komaSetFinishFlag = false;
        }
        //Board.turn++;
        komaNari(x, y);
    }


    void komaSet()
    {
        if (Board.boardSequesnce == "userATurn")
        {
            Board.komaSetFinishFlag = true;
        }
        else if (Board.boardSequesnce == "userBTurn")
        {
            Board.komaSetFinishFlag = true;
        }

        //Debug.Log("active:" + Board.choiceKoma + ":" + this.name);
        Board.komaBoard[x, y] = Board.choiceKoma;
        Board boardInstance = Board.choiceKoma.masterUser.boardInstance;
        Board.choiceKoma.posX = x;
        Board.choiceKoma.posY = y;
        Koma removeKoma = Instantiate(kkk);

        foreach (Koma k in Board.choiceKoma.masterUser.hand)
        {
            if (Board.choiceKoma.name == k.name)
            {
                removeKoma = k;
            }
        }
        Board.choiceKoma.masterUser.hand.Remove(removeKoma);
        if (Board.choiceKoma.masterUser.hand.Count == 0)
        {
            if (Board.choiceKoma.masterUser.name == "userA")
            {
                Board.userAFirstSetFlag = true;
            }
            else
            {
                Board.userBFirstSetFlag = true;
            }
            if (Board.userAFirstSetFlag && Board.userBFirstSetFlag && !Board.firstKomaSetFlag)
            {
                if (Board.choiceKoma.masterUser.name == "userA")
                {
                    Board.boardSequesnce = "userB" + "Turn";
                    boardInstance.userB.draw();
                }
                else if (Board.choiceKoma.masterUser.name == "userB")
                {
                    Board.boardSequesnce = "userA" + "Turn";
                    boardInstance.userA.draw();
                    Board.turn++;
                    //Debug.Log("aaaaaaaaaaaaaaaaaaa");
                }
                Board.komaMoveFinishFlag = false;
                Board.komaSetFinishFlag = false;
                Board.firstKomaSetFlag = true;
            }
        }
        Board.choiceKoma.masterUser.setCardPos();
        Vector3 ps = Board.choiceKoma.transform.position;
        ps.x = x;
        ps.z = y;
        Board.choiceKoma.transform.position = ps;
        if (Board.choiceKoma.masterUser.name == "userB")
        {
            Board.choiceKoma.transform.Rotate(0, 180, 0);
            //Debug.Log("rotate");
        }

        for (int i = 0; i < Board.BOARDSIZE; i++)
        {
            for (int j = 0; j < Board.BOARDSIZE; j++)
            {
                Board.panelBoard[i, j].GetComponent<Renderer>().material = BoardMaterial;
                Board.panelBoard[i, j].GetComponent<Panel>().active = "false";
            }
        }

        
        //Board.choiceFlag=true;
        //Board.choiceKoma.setFlag=true;
        userFirstSet();


    }

    void userFirstSet(){
        if (Board.boardSequesnce == "userAFirstSet")
        {
            Board.boardSequesnce = "userBFirstSet";
            if (Board.userAFirstSetFlag && Board.userBFirstSetFlag)
            {
                Board.boardSequesnce = "userBTurn";
                //Board.turn++;
            }
            //Debug.Log("aaaa");
           /// Board.turn++;
        }

        else if (Board.boardSequesnce == "userBFirstSet")
        {
            Board.boardSequesnce = "userAFirstSet";
            if (Board.userAFirstSetFlag && Board.userBFirstSetFlag)
            {
                Board.boardSequesnce = "userATurn";
                //Board.turn++;
            }
            //Debug.Log("aaaaaa");
            //Board.turn++;
        }
        //Board.turn++;
    }

}
