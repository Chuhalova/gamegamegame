using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lois : MonoBehaviour {

	Rigidbody2D myBody = null;
	public GameObject winAllGamePrefab;
	public GameObject loseAllGamePrefab;
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
		if ((col.transform.tag == "peter") && (HeroPeter.peter.flowers == 11) && (HeroPeter.peter.heroes > 2)) {
			animator.SetBool ("happy", true);
			StartCoroutine (addWinPrefabLater());
		}
		if ((col.transform.tag == "peter") && (HeroPeter.peter.flowers != 11) && (HeroPeter.peter.heroes == 3)) {
			animator.SetBool ("cry", true);
			HeroPeter.peter.peterDie ();
			StartCoroutine (addLosePrefabLater());
		}
		if ((col.transform.tag == "peter") && (HeroPeter.peter.flowers == 11) && (HeroPeter.peter.heroes < 3)) {
			animator.SetBool ("cry", true);
			HeroPeter.peter.peterDie ();
			StartCoroutine (addLosePrefabLater());
		}
		if ((col.transform.tag == "peter") && (HeroPeter.peter.flowers != 11) && (HeroPeter.peter.heroes < 3)) {
			animator.SetBool ("cry", true);
			HeroPeter.peter.peterDie ();
			StartCoroutine (addLosePrefabLater());
		}
	}

	IEnumerator addLosePrefabLater(){
		yield return new WaitForSeconds (0.8f);
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent, loseAllGamePrefab);
		obj.GetComponent<LoseAllGamePrefabScript>();
	}

	IEnumerator addWinPrefabLater(){
		yield return new WaitForSeconds (0.8f);
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent, winAllGamePrefab);
		obj.GetComponent<WinAllGamePrefabScript>();
	}
}
