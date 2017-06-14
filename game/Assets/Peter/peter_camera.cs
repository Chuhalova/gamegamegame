using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peter_camera : MonoBehaviour {

	public peter peter;

	void Update () {
		Transform peter_transform = peter.transform;
		Transform peter_camera_transform = this.transform;

		Vector3 peter_position = peter_transform.position;
		Vector3 peter_camera_position = peter_camera_transform.position;

		peter_camera_position.x = peter_position.x;
		peter_camera_position.y = peter_position.y;

		peter_camera_transform.position = peter_camera_position;
	}
}
