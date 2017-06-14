using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcontroller : MonoBehaviour {

	public static levelcontroller current;

	void Awake()
	{
		current = this;
	}

	Vector3 startingPosition;
	public void setStartPosition(Vector3 pos)
	{
		this.startingPosition = pos;
	}
}
