using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	public int productsNumber=0;
	public int products =0;

	public int homeNeedsNumber=0;
	public int homeNeeds=0;

	public GameObject losePanel;
	void Awake()
	{
		current = this;
	}

	Vector3 startingPosition;

	public void setStartPosition(Vector3 pos)
	{
		this.startingPosition = pos;
	}

	public void onPeterDeath(HeroPeter peter)
	{
		peter.transform.position = this.startingPosition;
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, losePanel);

	}
	//PRODUCTS ADD 
	public void addProduct(int number)
	{
		productsNumber++;
		products += number;
		UI_Product_Counter.productsCounter.setProductsInCounter(products);
	}
	//PRODUCTS GET
	public int getProducts(){
		return productsNumber;	
	}
	//PRODUCTS ADD 
	public void addHomeNeeds(int number)
	{
		homeNeedsNumber++;
		homeNeeds += number;
	}
	//PRODUCTS GET
	public int getHomeNeeds(){
		return homeNeedsNumber;	
	}
}