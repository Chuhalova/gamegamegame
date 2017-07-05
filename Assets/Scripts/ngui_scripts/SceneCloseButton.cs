using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCloseButton : MonoBehaviour {
	public myButton SceneCloseBtn;
	public GameObject SceneCloseObj;
	public static float time;
	void Start () {
		SceneCloseBtn.signalOnClick.AddListener (this.OnSceneCloseBtn);

	}

	void OnSceneCloseBtn() {
		showSceneClosePrefab ();
	}

	void showSceneClosePrefab() {
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent,SceneCloseObj);
		obj.GetComponent<SceneClosePrefab>();

	}
}