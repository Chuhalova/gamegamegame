using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowers : Collectable {

	protected override void OnPeterHit (HeroPeter peter)
	{
		peter.flowers++;
		UI_Flower_Counter.flowersCounter.setFlowersInCounter(peter.flowers);
		this.CollectedHide ();
	}
}
