using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneRepeatPrefab : MonoBehaviour {

	public myButton yesRepeatBtn;
	public myButton closeBackground;
	public myButton closeBtn;
	public myButton noGoToActiveLevelBtn;

	void Start () {
		yesRepeatBtn.signalOnClick.AddListener(this.openMenu);
		closeBackground.signalOnClick.AddListener(this.repeat);
		closeBtn.signalOnClick.AddListener(this.repeat);
		noGoToActiveLevelBtn.signalOnClick.AddListener(this.repeat);
	}
	void openMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	void repeat()
	{
		Time.timeScale = 1;
		Destroy(this.gameObject);
	}
}
