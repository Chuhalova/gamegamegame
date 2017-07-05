using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMainMenu : MonoBehaviour
{	
	//МУЗИКА
	public AudioClip btnMainAudioClip = null;
	AudioSource btnMainAudioSource = null;
	void Start () {
		//МУЗИКА

		this.btnMainAudioSource = gameObject.AddComponent<AudioSource>();
		this.btnMainAudioSource.clip = btnMainAudioClip;
	}



	public void _onClick()
	{
		if (SoundManager.Instance.isSoundOn())
		{
			btnMainAudioSource.Play();
		}
		SceneManager.LoadScene ("Peter2");
	}
}