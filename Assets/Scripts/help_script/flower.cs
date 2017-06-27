using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : Collectable {

	protected override void OnPeterHit (HeroPeter peter)
	{
		peter.flowers++;
		this.CollectedHide ();
	}
}
