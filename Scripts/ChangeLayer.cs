using UnityEngine;
using System.Collections;

public class ChangeLayer : MonoBehaviour {
	public int upperLayer = 3;
	public int lowerLayer = 2;

	private Renderer render;

	void Start () {
		render = GetComponent<Renderer>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		render.sortingOrder = upperLayer;
	}

	void OnTriggerExit2D(Collider2D other) {
		render.sortingOrder = lowerLayer;
	}
}
