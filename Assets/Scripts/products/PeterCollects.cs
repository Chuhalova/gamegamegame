using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PeterCollects : MonoBehaviour {
	//МУЗИКА
	public AudioClip hitAudioClip = null;
	AudioSource hitAudioSource = null;

	void Start () {
		//МУЗИКА

		this.hitAudioSource = gameObject.AddComponent<AudioSource>();
		this.hitAudioSource.clip = hitAudioClip;
	}


	protected virtual void OnPeterHit(HeroPeter peter) {
		if (SoundManager.Instance.isSoundOn() && !hitAudioSource.isPlaying)
		{
			hitAudioSource.Play();
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {

		HeroPeter peter = collider.GetComponent<HeroPeter>();
		if(peter != null) {
			this.OnPeterHit (peter);
		}

	}
	public void CollectedHide() {
		Destroy(this.gameObject);
	}
}
