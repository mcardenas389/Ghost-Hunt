using UnityEngine;
using System.Collections;

public class CutsceneTest2 : MonoBehaviour {
	public Transform[] positions = new Transform[2];

	private PlayerController playerController;

	void Start() {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			playerController.SetAnimation(false);
			playerController.enabled = !playerController.enabled;

			DialogueManager.dm.TriggerBottomUI();
			DialogueManager.dm.TypeText();
			Debug.Log("back from TypeText");

			while(!DialogueManager.dm.Complete)
				yield return null;

			DialogueManager.dm.TriggerBottomUI();
			Animate.animator.MoveToPosition(0, positions[0]);

			while(!Animate.animator.Complete)
				yield return null;

			Debug.Log("End of cutscene script.");
			playerController.SetAnimation(false);

			playerController.enabled = !playerController.enabled;
			Debug.Log("game object destroyed.");
			Destroy(gameObject);
		}
	}

	IEnumerator WaitForButtonDown() {
		while(!Input.GetButtonDown("Submit"))
			yield return null;
	}
}
