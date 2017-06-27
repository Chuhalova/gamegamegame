using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSoundscript : MonoBehaviour {

	public AudioClip audioClip = null;
	AudioSource audioClipSource = null;
	void Start(){
		audioClipSource = gameObject.AddComponent<AudioSource>();
		audioClipSource.clip = audioClip;
		audioClipSource.loop = true;
		audioClipSource.volume = 0.1f;
		audioClipSource.priority = 255;

		if(SoundManager.Instance.isVolumeOn()) audioClipSource.Play();
	}

	void FixedUpdate(){
		if (!SoundManager.Instance.isVolumeOn()){
			audioClipSource.Stop();
		}
		else if (!audioClipSource.isPlaying) audioClipSource.Play();
	}
}
