using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Flower_Counter : MonoBehaviour {


	public static UI_Flower_Counter flowersCounter;

	UILabel flowerslabel;


	private void Awake()
	{
		this.flowerslabel = this.transform.GetComponent<UILabel>();
		flowersCounter = this;
		flowerslabel.text = "00/11";

	}


	public void setFlowersInCounter(int flowers)
	{
		string flowersNum = flowers.ToString();
		string forPast = "/11";
		string forStart = "0";
		forStart += flowersNum;
		forStart += forPast;
		flowerslabel.text = forStart;
	}
	public void removeproducts(){
		flowerslabel.text="00/00";
	}
}
