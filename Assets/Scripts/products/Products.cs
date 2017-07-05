public class Products : PeterCollects {


	protected override void OnPeterHit (HeroPeter peter)
	{		
		LevelController.current.addProduct(1);
		this.CollectedHide ();
	}
}