using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRepeatScript : MonoBehaviour {
	public myButton SceneRepeatBtn;
	public GameObject SceneRepeatObj;
	public static float time;
	void Start () {
		SceneRepeatBtn.signalOnClick.AddListener (this.OnSceneRepeatBtn);

	}

	void OnSceneRepeatBtn() {
		showSceneRepeatPrefab ();
	}

	void showSceneRepeatPrefab() {
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent,SceneRepeatObj);
		obj.GetComponent<SceneRepeatPrefab>();

	}
}
