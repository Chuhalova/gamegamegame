public class HomeNeeds : PeterCollects {


	protected override void OnPeterHit (HeroPeter peter)
	{		
		LevelController.current.addHomeNeeds(1);
		this.CollectedHide ();
	}
}