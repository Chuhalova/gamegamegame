using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseAllGamePrefabScript : MonoBehaviour {
	public myButton mainMenuNoButton;
	public myButton closeBackground;
	public myButton closeButton;
	public myButton repeatYesButton;

	void Start () {
		mainMenuNoButton.signalOnClick.AddListener(this.openMenu);
		closeBackground.signalOnClick.AddListener(this.openMenu);
		repeatYesButton.signalOnClick.AddListener(this.repeat);
		closeButton.signalOnClick.AddListener(this.openMenu);
	}
	void openMenu()
	{
		SceneManager.LoadScene("MainScene");
	}
	void repeat()
	{
		SceneManager.LoadScene("Peter2");
	}
}
