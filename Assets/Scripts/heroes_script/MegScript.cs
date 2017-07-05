using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegScript : MonoBehaviour {
	public enum Mode {
		walkToA,
		walkToB,
		burn,
		survive,
		die
	}
	//starting from point .. 
	Mode mode = Mode.walkToA;
	public Vector3 pointA;
	public Vector3 pointB;
	public float speed = 1;
	public bool angry = false;
	float startPoint, finishPoint;
	Rigidbody2D myBody = null;


	//initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		startPoint = Mathf.Min(pointA.x, pointB.x);
		finishPoint = Mathf.Max(pointA.x, pointB.x);
	}

	void Update () {
		//initialization 
		/*Animator animator = GetComponent<Animator>();

		if(mode==Mode.survive){animator.SetTrigger("live");}
		if(mode==Mode.die)animator.SetTrigger("pray");*/
	}

	void OnCollisionEnter2D(Collision2D col){
		Collider2D collider = col.collider;
		Animator animator = GetComponent<Animator>();
		if (col.transform.tag == "extinguisher") {
			animator.SetBool ("live", true);
		}
		if (col.transform.tag == "healthhelper") {
			animator.SetBool ("pray", true);
			HeroPeter.peter.peterDie ();
		}
		if (col.transform.tag == "milk") {
			animator.SetBool ("pray", true);
			HeroPeter.peter.peterDie ();
		}
	}

	void OnCollisionExit2D(Collision2D col){
		Animator animator = GetComponent<Animator> ();
		Collider2D collider = col.collider;
		if (col.transform.tag == "extinguisher") {
			Hero_Icon_Script.heroes.Heroes ("Meg");
			HeroPeter.peter.increaseHeroes ();
			Destroy (this.gameObject);
		}
	}

	void FixedUpdate(){
		float value = this.direction();
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		//change sides
		if (angry == true) {
			if (value < 0)
				sr.flipX = true;
			else if (value > 0)
				sr.flipX = false;
			if (Mathf.Abs (value) > 0) {
				Vector2 vel = myBody.velocity;
				vel.x = value * speed;
				myBody.velocity = vel;
			}
		}
	}

	float direction(){
		Vector3 my_pos = this.transform.position;
		//learn situations in which orc start attack 
		//mode = Mode.walkToB;
		if(mode==Mode.walkToA){
			if(my_pos.x > startPoint)return -1;
			else {
				mode = Mode.walkToB;
				return 1;
			}
		}
		if (mode == Mode.walkToB) {	
			if (my_pos.x < finishPoint)
				return 1;
			else {
				mode = Mode.walkToA;
				return -1;
			}
		} else {
			//mode = Mode.walkToA;
			return direction();
		}
	}
	/*//learn situations in which rabbit die or orc die 
	void OnCollisionEnter2D(Collision2D col){

		Collider2D collider = col.collider;

		if(col.transform.tag == "Player")
		{
			Vector3 contactPoint = col.contacts[0].point;
			float up = this.GetComponent<BoxCollider2D>().bounds.max.y;
			if (Mathf.Abs (contactPoint.y - up) < 0.02f) {
				mode = Mode.attacked;
				StartCoroutine(dieLater ());
			}
			else mode=Mode.attack;
		}
	}
	public void DestroyOrc(){
		Destroy(this.gameObject);
	}
	void OnCollisionExit2D(Collision2D col){
		if(col.transform.tag == "Player")
		{
			mode=Mode.walkToA;
		}
	}
	//pause before dying and destroying 
	IEnumerator dieLater(){
		yield return new WaitForSeconds (0.8f);	
		DestroyOrc ();
	}

	void launchCarrot(float direction){
		GameObject obj = GameObject.Instantiate(this.prefabCarrot);

		Vector3 my_pos = this.transform.position;
		my_pos.y=this.GetComponent<BoxCollider2D>().bounds.center.y;

		carrot carrot = obj.GetComponent<carrot>();
		carrot.transform.position = my_pos;
		carrot.launch(direction);
	}*/

}