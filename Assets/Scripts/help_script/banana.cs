using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : Collectable {

	protected override void OnPeterHit (HeroPeter peter)
	{
		peter.flowers++;
		this.CollectedHide ();
	}
}
