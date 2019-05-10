using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class User : MonoBehaviour {

	public List<Koma> hand;
	public List<Koma> deck;

	[SerializeField]Koma HuObject;
	[SerializeField]Koma OuObject;
	[SerializeField]Koma KinInstance;
	[SerializeField]Koma ginObjecet;
	[SerializeField]Koma keimaObject;
	[SerializeField]Koma kyousyaObject;
	[SerializeField]Koma hisyaObject;
	[SerializeField]Koma kakuObject;

	public const int  huNum=9;
	public const int kinNum=2;
	public const int ginNum=2;
	public const int keimaNum=2;
	public const int kyousyaNum=2;
	public const int hisyaNum=1;
	public const int kakuNum=1; 


	public const int handNum=3;

	public Board boardInstance;

	void Start () {
		deck=new  List<Koma>();

		makeKoma(kinNum,KinInstance,"kin");
		makeKoma(keimaNum,keimaObject,"keima");
		makeKoma(huNum,HuObject,"hu");
		makeKoma(ginNum,ginObjecet,"gin");
		makeKoma(kyousyaNum,kyousyaObject,"kyousya");
		makeKoma(hisyaNum,hisyaObject,"hisya");
		makeKoma(kakuNum,kakuObject,"kaku");

		deck = deck.OrderBy(a => Guid.NewGuid()).ToList();

		Koma ou=Instantiate(OuObject);
		ou.name="Ou";
		ou.masterUser=this;
		ou.settingturn=Board.turn;
		ou.makeMV();
		hand.Add(ou);

		for(int i=0;i<handNum;i++){
			draw();
		}
		setCardPos();
	}
	
	// Update is called once per frame
	void makeKoma (int komaNum,Koma komaObj,string name) {
		for(int i=0;i<komaNum;i++){
			Koma madeHu=Instantiate(komaObj);
			deck.Add(madeHu);
			madeHu.name=name+i;
			madeHu.settingturn=Board.turn;
			madeHu.makeMV();
			
		}
	}


	public void setCardPos(){
		Vector3 thisPos = this.transform.position;
		float x=thisPos.x;
		foreach(Koma koma in hand){
			Vector3 pos =koma.transform.position;
			thisPos.x =x;
			koma.transform.position = thisPos;
			x=x+2;
		}
	}

	public void draw(){
		hand.Add(deck[0]);
		deck[0].settingturn=Board.turn;
		deck[0].masterUser=this;
		deck.RemoveAt(0);
		setCardPos();
	}

	public void firstDraw(){

	}
}
