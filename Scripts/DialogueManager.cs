using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {	
	public Text npcText;
	public float letterPause = 0.2f;
	public string[] dialogue = new string[5];
	public Image[] portraits = new Image[5];

	private bool isTalking = false;
	private Image dialogueBox;
	private Image portrait;
	private PlayerController playerController;

	void Start () {
		GameObject gameObj;

		gameObj = GameObject.Find("Dialogue Box");
		dialogueBox = gameObj.GetComponent<Image>();

		gameObj = GameObject.Find("Portrait");
		portrait = gameObj.GetComponent<Image>();

		gameObj = GameObject.FindGameObjectWithTag("Player");
		playerController = gameObj.GetComponent<PlayerController>();
	}

	IEnumerator OnCollisionStay2D(Collision2D other) {
		if(other.gameObject.tag == "Player" && Input.GetButton("Submit") && !isTalking) {
			isTalking = true;

			playerController.enabled = !playerController.enabled;
			dialogueBox.enabled = !dialogueBox.enabled;
			portrait.enabled = !portrait.enabled;

			for(int i = 0; i <= 2; i++) {
				yield return StartCoroutine(TypeText(dialogue[i]));
				yield return StartCoroutine(WaitForButtonUp());
				yield return StartCoroutine(WaitForButtonDown());
				npcText.text = "";
			}

			Debug.Log("Reenable.");
			playerController.enabled = !playerController.enabled;
			dialogueBox.enabled = !dialogueBox.enabled;
			portrait.enabled = !playerController.enabled;

			yield return StartCoroutine(WaitForButtonUp());

			isTalking = false;
		}
	}

	IEnumerator TypeText(string line) {
		Debug.Log("Entered TypeText");
		bool keyUP = false;

		foreach(char letter in line) {
			if(!keyUP && Input.GetButtonUp("Submit"))
				keyUP = true;

			if(keyUP && Input.GetButtonDown("Submit")) {
				npcText.text = line;
				break;
			}
			npcText.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
	}

	IEnumerator WaitForButtonDown() {
		while(!Input.GetButtonDown("Submit"))
			yield return null;
	}

	IEnumerator WaitForButtonUp() {
		while(!Input.GetButtonUp("Submit"))
			yield return null;
	}
}