using System.Collections;
using UnityEngine.Events;
using UnityEngine;
public class myButton : MonoBehaviour
{
	//МУЗИКА
	public AudioClip btnAudioClip = null;
	AudioSource btnAudioSource = null;
	void Start () {
		//МУЗИКА

		this.btnAudioSource = gameObject.AddComponent<AudioSource>();
		this.btnAudioSource.clip = btnAudioClip;
	}

	public UnityEvent signalOnClick = new UnityEvent();
	public void _onClick()
	{
		if (SoundManager.Instance.isSoundOn())
		{
			btnAudioSource.Play();
		}
		this.signalOnClick.Invoke();
	}
}