using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Board : MonoBehaviour {

	public static int BOARDSIZE=5;
	public static Koma[,] komaBoard;
	public static GameObject[,] panelBoard;
	public static int turn=0;
	public static Koma choiceKoma;
	public static bool firstKomaSetFlag=false;
	public static bool choiceFlag;
	public static bool komaSetFinishFlag=false;
	public static bool komaMoveFinishFlag=false;
	public User userA;
	public User userB;

	public static bool userAFirstSetFlag=false;
	public static bool userBFirstSetFlag=false;

	public static string boardSequesnce="userAFirstSet";

	public static string turnUser="userA";

	// Use this for initialization
	void Start () {
		createBoard();
	}
	
	void createBoard(){
		GameObject blackPlane =(GameObject)Resources.Load("BlackPlane");
		GameObject whitePlane =(GameObject)Resources.Load("WhitePlane");

		komaBoard=new Koma[BOARDSIZE,BOARDSIZE];
		//Debug.Log(komaBoard[0,0]);
		panelBoard = new GameObject[BOARDSIZE,BOARDSIZE];

		for(int i=0;i<BOARDSIZE;i++){
			for(int j=0;j<BOARDSIZE;j++){
				panelBoard[i,j]=Instantiate (blackPlane, new Vector3(i,0,j), Quaternion.identity);
				panelBoard[i,j].name=i+","+j;
			}
		}	
	}


	public void turnProcess(){


		turn++;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
