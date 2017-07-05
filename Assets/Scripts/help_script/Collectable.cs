using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	protected virtual void OnPeterHit(HeroPeter rabbit) {
	}
	void OnTriggerEnter2D(Collider2D collider) {

		HeroPeter rabbit = collider.GetComponent<HeroPeter>();
		if(rabbit != null) {
			this.OnPeterHit (rabbit);
		}

	}
	public void CollectedHide() {
		Destroy(this.gameObject);
	}
}
