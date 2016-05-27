using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {
	public static DialogueManager dm;	
	public float letterPause = 0.05f;
	public bool Complete {
		get {return complete;}
	}

	private Image[] dialogueImages; //stores top and bottom portraits
	private Text[] dialogueText; //stores top and bottom text fields
	//private bool isTalking = false;
	private bool complete = false;
	private bool skip = false;

	void Awake() {
		if(dm == null) {
			DontDestroyOnLoad(gameObject);
			dm = this;
		} else if(dm != this) {
			Destroy(gameObject);
		}
	}

	void Start () {
		dialogueImages = GetComponentsInChildren<Image>();
		dialogueText = GetComponentsInChildren<Text>();
	}

	void Update() {
		if(Input.GetButton("Submit")) //&& isTalking)	
			skip = true;
		else skip = false;
	}

	public void TriggerBottomUI() {
		dialogueImages[0].enabled = !dialogueImages[0].enabled;
		dialogueImages[1].enabled = !dialogueImages[1].enabled;
	}

	public void TriggerTopUI() {
		dialogueImages[2].enabled = !dialogueImages[2].enabled;
		dialogueImages[3].enabled = !dialogueImages[3].enabled;
	}

	public void TypeText() {
		//isTalking = true;
		complete = false;
		StartCoroutine(CoTypeText("hello world, hope you're having a nice day!", 0));
	}

	IEnumerator CoTypeText(string line, int i) {
		foreach(char letter in line) {
			if(skip) {
				dialogueText[i].text = line;
				break;
			}

			dialogueText[i].text += letter;

			yield return new WaitForSeconds(letterPause);
		}

		yield return WaitForButtonDown();
		dialogueText[i].text = "";
		complete = true;
	}

	IEnumerator WaitForButtonDown() {
		Debug.Log("Waiting . . .");
		while(!Input.GetButtonDown("Submit"))
			yield return null;

		Debug.Log("Done.");
	}

	IEnumerator WaitForButtonUp() {
		while(!Input.GetButtonUp("Submit"))
			yield return null;
	}
}