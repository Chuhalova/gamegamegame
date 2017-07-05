using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Product_Counter : MonoBehaviour {


	public static UI_Product_Counter productsCounter;

	UILabel productslabel;


	private void Awake()
	{
		this.productslabel = this.transform.GetComponent<UILabel>();
		productsCounter = this;
		productslabel.text = "00/15";

	}


	public void setProductsInCounter(int products)
	{
		string productsNum = products.ToString();
		string forPast = "/15";
		string forStart = "0";
		forStart += productsNum;
		forStart += forPast;
		productslabel.text = forStart;
	}
	public void removeproducts(){
		productslabel.text="00/00";
	}
}