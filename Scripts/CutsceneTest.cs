using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutsceneTest : MonoBehaviour {
	public float letterPause = 0.05f;
	public Transform ghost;
	public string[] dialogue = new string[10];
	public Sprite[] sprites = new Sprite[5];

	private bool exeCutscene = false;
	private Animator anim;
	private GameObject obj;
	private Image dialogueBox;
	private Image portrait;
	private PlayerController player;
	//private Rigidbody2D rbody;
	private Text gameText;

	void Start () {
		obj = GameObject.Find("Dialogue Box Bottom");
		dialogueBox = obj.GetComponent<Image>();

		obj = GameObject.Find("Portrait Bottom");
		portrait = obj.GetComponent<Image>();

		obj = GameObject.Find("Text Bottom");
		gameText = obj.GetComponent<Text>();

		obj = GameObject.FindGameObjectWithTag("Player");
		player = obj.GetComponent<PlayerController>();
		//rbody = obj.GetComponent<Rigidbody2D>();
		anim = obj.GetComponent<Animator>();
	}
	
	IEnumerator OnTriggerEnter2D(Collider2D other) {
		if(!exeCutscene) {
			Debug.Log("Entered box");
			anim.SetBool("IsWalking", false);

			dialogueBox.enabled = !dialogueBox.enabled;
			portrait.enabled = !portrait.enabled;
			player.enabled = !player.enabled;

			yield return StartCoroutine(Cutscene());

			dialogueBox.enabled = !dialogueBox.enabled;
			portrait.enabled = !portrait.enabled;
			player.enabled = !player.enabled;

			//exeCutscene = true;
		}
	}

	IEnumerator Cutscene() {
		//portrait.sprite = Resources.Load("UI/ghost") as Sprite;
//		portrait.sprite = sprites[0];
//		yield return StartCoroutine(TypeText("Hello! How are you today, good friend?"));
//		yield return StartCoroutine(WaitForButtonDown());
//		yield return StartCoroutine(WaitForButtonUp());
//		gameText.text = "";
//
//		portrait.sprite = sprites[1];
//		yield return StartCoroutine(TypeText("I find the context of this conversation disturbing . . ."));
//		yield return StartCoroutine(WaitForButtonDown());
//		yield return StartCoroutine(WaitForButtonUp());
//		gameText.text = "";

		for(int i = 0; i <= 7; i++) {
			//portrait.sprite = sprites[0];
			portrait.overrideSprite = Resources.Load("Assets/UI/temp man portrait") as Sprite;
			yield return StartCoroutine(TypeText(dialogue[i]));
			//yield return StartCoroutine(WaitForButtonUp());
			yield return StartCoroutine(WaitForButtonDown());
			yield return StartCoroutine(WaitForButtonUp());
			gameText.text = "";
		}

	}

	IEnumerator TypeText(string line) {
		Debug.Log("Entered TypeText");

		foreach(char letter in line) {
			if(Input.GetButton("Submit")) {
				gameText.text = line;
				break;
			}

			gameText.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
	}

	IEnumerator WaitForButtonDown() {
		Debug.Log("Waiting down");
		while(!Input.GetButtonDown("Submit"))
			yield return null;
	}

	IEnumerator WaitForButtonUp() {
		Debug.Log("Waiting up");
		while(!Input.GetButtonUp("Submit"))
			yield return null;
	}
}