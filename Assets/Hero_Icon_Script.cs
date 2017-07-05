using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Icon_Script : MonoBehaviour {

	public Sprite first;
	public Sprite second;
	public Sprite third;

	//for win panel
	/*public bool firstWin=false;
	public bool secondWin=false;
	public bool thirdWin=false;*/

	public static Hero_Icon_Script heroes;

	UI2DSprite[] gemComponents;


	private void Awake()
	{
		heroes = this;
		gemComponents = new UI2DSprite[3];
		loadComponents();
	}

	private void loadComponents()
	{
		for (int i = 0; i < transform.childCount; ++i)
			gemComponents[i] = transform.GetChild(i).GetComponent<UI2DSprite>();
	}

	public void Heroes(string heroes) {
		if (heroes == "Chris") {
			gemComponents [0].sprite2D = first;
			//firstWin == true;
		} else if (heroes == "Meg") {
			gemComponents [1].sprite2D = second;
			//secondWin = true;
		} else if (heroes == "Stewie") {
			gemComponents [2].sprite2D = third;
			//thirdWin = true;
		}
	}
}
