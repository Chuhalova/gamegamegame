using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorToLevel3 : MonoBehaviour
{
	// int productsOnLevel=0;
	void OnCollisionEnter2D(Collision2D col){
		Collider2D collider = col.collider;
		if (LevelController.current.getHomeNeeds()!= 15) {
			HeroPeter.lastPeter.removeHealth ();		
		}
		else{
			if(col.transform.tag == "peter"){
				SceneManager.LoadScene ("Peter4");
			}
		}
	}
}