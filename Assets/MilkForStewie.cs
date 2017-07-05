﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkForStewie : MonoBehaviour {

	float direction = 0;
	public float speed = 10.0f;

	void Start(){
		StartCoroutine (destroyLater (3.0f));
	}
	void FixedUpdate(){
		Vector3 my_pos = this.transform.position;
		my_pos.x+=Time.deltaTime*direction;
		this.transform.position=my_pos;
	}
	IEnumerator destroyLater(float time){
		yield return new WaitForSeconds(time);
		Destroy(this.gameObject);
	}

	internal void launch(float direction){
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		if (direction<0) sr.flipX = true;
		else if (direction>0) sr.flipX = false;
		this.direction=direction;
	}
}
