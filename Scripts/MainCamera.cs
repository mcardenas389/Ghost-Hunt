using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	public float speed;
	public float scale;
	public Transform target;

	private Camera myCam;

	void Start() {
		myCam = GetComponent<Camera>();
	}

	void Update() {
		//directly relates to size variable of camera
		myCam.orthographicSize = (Screen.height / 100f) / scale;

		// if target exists
		// Lerp = Linear IntERPolate (to, from, how fast)
		// Linear Interpolation means to go from x to y by a scale, z
		// Vector3 is needed to create distance between camera and map
		if(target) {
			transform.position = Vector3.Lerp(transform.position, 
				target.position, speed) + new Vector3(0, 0, -10f);
		}
	}
}
