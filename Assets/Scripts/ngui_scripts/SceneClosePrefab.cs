using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneClosePrefab : MonoBehaviour {
	public myButton yesGoToMainBtn;
	public myButton closeBackground;
	public myButton closeBtn;
	public myButton noGoToActiveLevelBtn;

	void Start () {
		yesGoToMainBtn.signalOnClick.AddListener(this.openMenu);
		closeBackground.signalOnClick.AddListener(this.repeat);
		closeBtn.signalOnClick.AddListener(this.repeat);
		noGoToActiveLevelBtn.signalOnClick.AddListener(this.repeat);
	}
	void openMenu()
	{
		SceneManager.LoadScene("MainScene");
	}
	void repeat()
	{
		Time.timeScale = 1;
		Destroy(this.gameObject);
	}
}
