using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour{

	void OnTriggerEnter2D(Collider2D collider)
	{
		HeroPeter peter = collider.GetComponent<HeroPeter>();

		if (peter != null)
		{
			LevelController.current.onPeterDeath(peter);
		}
	}
}
