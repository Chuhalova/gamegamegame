using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;

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
	}
}