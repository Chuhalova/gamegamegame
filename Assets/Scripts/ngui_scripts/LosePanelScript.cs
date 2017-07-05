using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanelScript : MonoBehaviour {
	public myButton mainMenuButton;
	public myButton closeBackground;
	public myButton repeatButton;
	public UILabel products;

	void Start () {
		mainMenuButton.signalOnClick.AddListener(this.openMenu);
		closeBackground.signalOnClick.AddListener(this.repeat);
		repeatButton.signalOnClick.AddListener(this.repeat);
		setProducts (products);
	}
	void openMenu()
	{
		SceneManager.LoadScene("MainScene");
	}
	void repeat()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void setProducts(UILabel products){
		//if (SceneManager.GetActiveScene().name=="Peter2"){
			this.products.text = LevelController.current.getProducts().ToString()+"/15";
		//}
			//if (SceneManager.GetActiveScene().name=="Peter3"){
			//	this.products.text = LevelController.current.getHomeNeeds().ToString()+"/15";
			//}
	}
}
