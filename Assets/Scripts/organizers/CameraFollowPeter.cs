using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPeter : MonoBehaviour {

	public HeroPeter peter ;

	void Update () {
		Transform peter_transform = peter.transform;
		Transform camera_transform = this.transform;

		Vector3 peter_position=peter_transform.position;
		Vector3 camera_position = camera_transform.position;

		//camera_position.x = peter_position.x;
		camera_position.y = peter_position.y;

		camera_transform.position = camera_position;
	}
}