using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMainMenu : MonoBehaviour
{
	public void _onClick()
	{
		SceneManager.LoadScene ("Peter");
	}
}