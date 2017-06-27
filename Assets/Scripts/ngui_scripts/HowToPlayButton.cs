using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour {
	public myButton howToPlayBtn;
	public GameObject howToPlayPrefab;
	public static float time;

	void Start () {
		howToPlayBtn.signalOnClick.AddListener (this.onHowToPlayBtn);
	}

	void onHowToPlayBtn() {
		showHowToPlay ();
	}

	void showHowToPlay() {
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent, howToPlayPrefab);
		obj.GetComponent<HowToPlayPrefabScript>();

	}
}