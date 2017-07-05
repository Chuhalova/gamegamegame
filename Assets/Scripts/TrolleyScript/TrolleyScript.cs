using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyScript : MonoBehaviour {
	
	//МУЗИКА
	public AudioClip destroyAudioClip = null;
	AudioSource destroyAudioSource = null;

	public enum Mode {
		walkToA,
		walkToB,
	}
	//start mode
	Mode mode = Mode.walkToA;

	//points (start and finish)
	public Vector3 pointA;
	public Vector3 pointB;
	//start and finish 
	float startPoint, finishPoint;
	//speed of orc 
	public float speed = 3;
	//----------------
	Rigidbody2D myBody = null;
	//initislization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		//start point -> point with smaller coordinates
		startPoint = Mathf.Min(pointA.x, pointB.x);
		//finish point -> point with bigger coordinates 
		finishPoint = Mathf.Max(pointA.x, pointB.x);

		//МУЗИКА

		this.destroyAudioSource = gameObject.AddComponent<AudioSource>();
		this.destroyAudioSource.clip = destroyAudioClip;
	}
	//--------------------------
	void Update () {
		//initialize our animator 
		//Animator animator = GetComponent<Animator>();
		//modes and animations , which is followed by this modes 
		//if(mode==Mode.walkToA || mode==Mode.walkToB){
		//	animator.SetBool("walk",true);
		//}
	}

	void FixedUpdate(){
		//transportation of orc
		float value = this.direction();
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		//changing of direction
		if (value<0) sr.flipX = false;
		else if (value>0) sr.flipX = true;
		//---------------
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}

	}
	float direction(){
		//green orc position
		Vector3 trolley_pos = this.transform.position;
		//rabbit position
		Vector3 peter_pos = HeroPeter.lastPeter.transform.position;

		if(mode==Mode.walkToA){
			if(trolley_pos.x > startPoint)return -1;
			else {
				mode = Mode.walkToB;
				return 1;
			}
		}
		if(mode==Mode.walkToB){	
			if(trolley_pos.x < finishPoint)return 1;
			else {
				mode = Mode.walkToA;
				return -1;
			}
		}
		return 0;
	}
//learn the actions of the rabbit and orc by the rabbit`s location
	void OnCollisionEnter2D(Collision2D col){
		Collider2D collider = col.collider;

		if(col.transform.tag == "peter")
		{
			//HeroPeter.lastPeter.removeHealth ();
			Vector3 location = col.contacts[0].point;
			float up = this.GetComponent<BoxCollider2D>().bounds.max.y;
			if (Mathf.Abs (location.y - up)<0.1f) {
				StartCoroutine (playMusicLater());
				Destroy (this.gameObject);

			} else {
				HeroPeter.lastPeter.removeHealth();
			}
		}
	}
	IEnumerator playMusicLater(){
		yield return new WaitForSeconds (0.8f);	
		if (SoundManager.Instance.isSoundOn() && !destroyAudioSource.isPlaying)
		{
			destroyAudioSource.Play();
		}
	}
	/*destroy orc 
	public void destoyGreenOrc(){
		Destroy(this.gameObject);
	}
	void OnCollisionExit2D(Collision2D col){
		if(col.transform.tag == "Player")
		{
			mode=Mode.walkToA;
		}
	}
	//pause after dying and before destroying
	IEnumerator dieLater(){
		yield return new WaitForSeconds (0.8f);	
		destoyGreenOrc ();
	}
	//pause after orc`s attack and before rabbit dying
	IEnumerator attackLater(){
		yield return new WaitForSeconds (0.5f);	
		HeroRabbit.lastRabbit.orcAttack();
	}*/
}