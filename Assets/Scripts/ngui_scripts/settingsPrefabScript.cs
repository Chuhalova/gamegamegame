using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsPrefabScript : MonoBehaviour {

	public myButton background;
	public myButton close;
	public myButton sound;
	public myButton volume;
	// Use this for initialization
	void Start ()
	{

		background.signalOnClick.AddListener(this.onClosePlay);
		close.signalOnClick.AddListener(this.onClosePlay);
		sound.signalOnClick.AddListener(this.onSoundPlay);
		volume.signalOnClick.AddListener(this.onVolumePlay);
	}

	void Update()
	{

	}


	void onClosePlay()
	{
		Time.timeScale = 1;
		Destroy(this.gameObject);
	}

	void onSoundPlay()
	{
		if (SoundManager.Instance.isSoundOn()) {
			SoundManager.Instance.setSoundOn(false);

		}
		else
		{
			SoundManager.Instance.setSoundOn(true);

		}

	}

	void onVolumePlay()
	{
		if (SoundManager.Instance.isVolumeOn())
		{
			SoundManager.Instance.setVolumeOn(false);

		}
		else
		{
			SoundManager.Instance.setVolumeOn(true);
		}
	}
}
