using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class HeroPeter : MonoBehaviour {
	//РУХ 
	public float speed = 1;
	Rigidbody2D myBody = null;
	//СТРИБОК
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;


	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		//КОНТРОЛЬ ПОЗИЦІЇ
		LevelController.current.setStartPosition (transform.position);
	}


	void FixedUpdate()
	{
		//ЧИТАННЯ КЛАВІШ - СТРІЛКИ
		float value = Input.GetAxis("Horizontal");  
		if (Mathf.Abs(value) > 0)
		{
			//РУХ
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		//ЗМІНА НАПРЯМКУ
		if (value < 0)
		{
			sr.flipX = true;
		}
		else if (value > 0)
		{
			sr.flipX = false;
		}
		//АНІМАЦІЯ БІГУ
		Animator animator = GetComponent<Animator>(); // run-idle
		if (Mathf.Abs(value) > 0)
		{
			animator.SetBool("run", true);
		}
		else
		{
			animator.SetBool("run", false);

		}

		//ВИЗНАЧЕННЯ ВІДСТАНІ , ЩО ВИМІРЮЄ , КОЛИ ПОЧИНАЄТЬСЯ СТРИБОК
		Vector3 from = transform.position + Vector3.up * 2f;
		Vector3 to = transform.position + Vector3.down * 1.2f;
		int layer_id = 1 << LayerMask.NameToLayer("Ground");
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if (hit)
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
		//ВИЗНАЧЕНЯ УМОВ ВКЛЮЧЕННЯ АНІМАЦІЇ СТРИБКУ
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			this.JumpActive = true;
		}
		if (this.JumpActive)
		{
			if (Input.GetButton("Jump"))
			{
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime)
				{
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			}
			else
			{
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}

		if (this.isGrounded)
		{
			animator.SetBool("jump", false);
		}
		else
		{
			animator.SetBool("jump", true);
		}
		//ВИЗНАЧЕННЯ КИДАННЯ ВОГНЕГАСНИКА
		if (Input.GetKeyDown(KeyCode.E)){
			//LevelController.current.onPeterDeath(this);

		}
	
	}
	void launchExtinguisher(float direction){
		GameObject obj = GameObject.Instantiate(this.prefabExtinguisher);
		Vector3 my_pos = this.transform.position;
		my_pos.y=this.GetComponent<BoxCollider2D>().bounds.center.y;
		Extinguisher extinguisher = obj.GetComponent<extinguisher>();
		extinguisher.transform.position = my_pos;
		extinguisher.launch(direction);
	}
}