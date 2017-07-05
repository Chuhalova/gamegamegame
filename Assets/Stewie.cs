using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stewie : MonoBehaviour {

	Rigidbody2D myBody = null;
	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		Collider2D collider = col.collider;
		Animator animator = GetComponent<Animator>();
		if (col.transform.tag == "milk") {
			animator.SetBool ("drink", true);
		}
		if (col.transform.tag == "healthhelper") {
			animator.SetBool ("pray", true);
			HeroPeter.peter.peterDie ();
		}
		if (col.transform.tag == "extinguisher") {
			animator.SetBool ("pray", true);
			HeroPeter.peter.peterDie ();
		}
	}

	void OnCollisionExit2D(Collision2D col){
		Animator animator = GetComponent<Animator> ();
		Collider2D collider = col.collider;
		if (col.transform.tag == "milk") {
			Hero_Icon_Script.heroes.Heroes ("Stewie");
			HeroPeter.peter.increaseHeroes ();
			Destroy (this.gameObject);
		}
	}
}

