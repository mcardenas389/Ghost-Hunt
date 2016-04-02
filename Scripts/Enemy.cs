using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float speed = 2f;

	private Transform camPosition;
	private Transform combatPosition;
	private Transform targetPosition;
	private PlayerController playerController;
	private MainCamera mainCam;
	private float minDistance = 0.01f;
	private float maxDistance = 2f;
	private float range;
	private bool inCombat = false;

	void Start() {
		GameObject gameObj;

		gameObj = GameObject.FindGameObjectWithTag("MainCamera");
		targetPosition = gameObj.GetComponent<Transform>();
	}

	void Update()	{
		if(!inCombat) {
			range = Vector2.Distance(transform.position, targetPosition.position);

			if(range >= minDistance && range <= maxDistance)
				transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log("Touched.");

		if(other.gameObject.tag == "Player") {
			Debug.Log("Found player.");

			inCombat = true;

			CombatManager.combat.StartCombat();
			//GameController.control.Test();
		}
	}
}
