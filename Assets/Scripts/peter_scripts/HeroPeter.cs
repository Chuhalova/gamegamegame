using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class HeroPeter : MonoBehaviour {
	//РУХ 
	public GameObject extinguisher;
	public GameObject healthhelper;
	public GameObject milkforstewie;
	public static HeroPeter peter = null;
	public float speed = 1;
	Rigidbody2D myBody = null;
	//СТРИБОК
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	float last_extinguisher = 0;
	float last_healthHelper = 0;
	float last_milkforstewie = 0;
	public int flowers = 0;
	public int heroes = 0;
	public static HeroPeter lastPeter = null;

	//МУЗИКА
	public AudioClip deathAudioClip = null;
	public AudioClip goAudioClip = null;
	AudioSource deathAudioSource = null;
	AudioSource goAudioSource = null;

	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		//КОНТРОЛЬ ПОЗИЦІЇ
		LevelController.current.setStartPosition (transform.position);

		//МУЗИКА
		this.deathAudioSource = gameObject.AddComponent<AudioSource>();
		this.deathAudioSource.clip = deathAudioClip;
		this.goAudioSource = gameObject.AddComponent<AudioSource>();
		this.goAudioSource.spatialBlend = 1;
		this.goAudioSource.clip = goAudioClip;
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
			if (SoundManager.Instance.isSoundOn() && !goAudioSource.isPlaying && isGrounded)
			{
				goAudioSource.Play();
			}
			else if (!isGrounded)
			{
				goAudioSource.Stop();
			}
			animator.SetBool("run", true);
		}
		else
		{
			animator.SetBool("run", false);
			if (SoundManager.Instance.isSoundOn())
			{
				goAudioSource.Stop();
			}

		}

		//ВИЗНАЧЕННЯ ВІДСТАНІ , ЩО ВИМІРЮЄ , КОЛИ ПОЧИНАЄТЬСЯ СТРИБОК
		Vector3 from = transform.position + Vector3.up * 1.4f;
		Vector3 to = transform.position + Vector3.down * 1.2f;
		Debug.DrawLine (from, to, Color.red);
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
		if (Input.GetKeyDown(KeyCode.W)){
			if(sr.flipX)launchMilkforstewie(-1.0f);
			else launchMilkforstewie(1.0f);
			last_milkforstewie=Time.time;
		}
		if (Input.GetKeyDown(KeyCode.E)){
			if(sr.flipX)launchExtinguisher(-1.0f);
				else launchExtinguisher(1.0f);
				last_extinguisher=Time.time;
		}
		if (Input.GetKeyDown(KeyCode.Q)){
			if(sr.flipX)launchHealthhelper(-1.0f);
			else launchHealthhelper(1.0f);
			last_healthHelper=Time.time;
		}
	}

	void launchMilkforstewie(float direction){
		GameObject obj = GameObject.Instantiate(this.milkforstewie);
		Vector3 my_pos = this.transform.position;
		my_pos.y=this.GetComponent<BoxCollider2D>().bounds.center.y;
		MilkForStewie milkforstewie = obj.GetComponent<MilkForStewie>();
		milkforstewie.transform.position = my_pos;
		milkforstewie.launch(direction);
	}

	void launchHealthhelper(float direction){
		GameObject obj = GameObject.Instantiate(this.healthhelper);
		Vector3 my_pos = this.transform.position;
		my_pos.y=this.GetComponent<BoxCollider2D>().bounds.center.y;
		HealthHelper healthhelper = obj.GetComponent<HealthHelper>();
		healthhelper.transform.position = my_pos;
		healthhelper.launch(direction);
	}

	void launchExtinguisher(float direction){
		GameObject obj = GameObject.Instantiate(this.extinguisher);
		Vector3 my_pos = this.transform.position;
		my_pos.y=this.GetComponent<BoxCollider2D>().bounds.center.y;
		extinguish extinguisher = obj.GetComponent<extinguish>();
		extinguisher.transform.position = my_pos;
		extinguisher.launch(direction);
	}
	void Awake(){
		peter = this;
		lastPeter=this;
	}

	public void peterDie(){
		Animator animator = GetComponent<Animator> ();
		animator.SetTrigger ("die");
		StartCoroutine (destroyLater());
	}

	public void increaseHeroes(){
		heroes++;
	}

	public void removeHealth(){
		//Animator animator = GetComponent<Animator>(); // run-idle	
		//animator.SetBool("die", true);
		StartCoroutine (destroyPeterLater());
	}
	IEnumerator destroyPeterLater(){
		yield return new WaitForSeconds (0.8f);	
		LevelController.current.onPeterDeath(this);
		//Animator animator = GetComponent<Animator>(); // run-idle	
		//animator.SetBool("die", false);
	}

	IEnumerator destroyLater(){
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}

	/*МУЗИКА ДЛЯ АНІМАЦІЇ ДАЙ 
	  if (soundManager.Instance.isSoundOn())
			{
				deathAudioSource.Play();
			}
	*/
}