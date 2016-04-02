using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatUIController : MonoBehaviour {
	public static CombatUIController combatUI;

	private int choice;
	public int Choice {
		get {return choice;}
		set {choice = minChoice;}
	}

	private Image[] uiCursors;
	private Text[] textColumns;
	private int minChoice = 1;
	private int maxChoice = 5;


	void Awake() {
		if(combatUI == null) {
			DontDestroyOnLoad(gameObject);
			combatUI = this;
		} else if(combatUI != this) {
			Destroy(gameObject);
		}
	}

	void Start () {
		choice = minChoice;
		uiCursors = GetComponentsInChildren<Image>();
		textColumns = GetComponentsInChildren<Text>();

		combatUI.enabled = !combatUI.enabled;
	}
	
	void Update () {
		float inputHorizontal = Input.GetAxisRaw("Horizontal");
		float inputVertical = Input.GetAxisRaw("Vertical");

		if(inputVertical > 0 && choice > minChoice) {
			uiCursors[choice].enabled = !uiCursors[choice--].enabled;
			uiCursors[choice].enabled = !uiCursors[choice].enabled;
		}
		else if(inputVertical < 0 && choice < maxChoice) {
			uiCursors[choice].enabled = !uiCursors[choice++].enabled;
			uiCursors[choice].enabled = !uiCursors[choice].enabled;
		}
		else if(inputHorizontal > 0) {
			if(choice == 1 || choice == 2) {
				uiCursors[choice].enabled = !uiCursors[choice].enabled;
				choice += 3;
				uiCursors[choice].enabled = !uiCursors[choice].enabled;
			}
		}
		else if(inputHorizontal < 0) {
			if(choice == 4 || choice == 5) {
				uiCursors[choice].enabled = !uiCursors[choice].enabled;
				choice -= 3;
				uiCursors[choice].enabled = !uiCursors[choice].enabled;
			}
		}
	}

	//switches UI elements from the current on/off state to the opposite
	public void triggerUI() {
		combatUI.enabled = !combatUI.enabled;

		uiCursors[0].enabled = !uiCursors[0].enabled;
		uiCursors[choice].enabled = !uiCursors[choice].enabled;

		textColumns[0].enabled = !textColumns[0].enabled;
		textColumns[1].enabled = !textColumns[1].enabled;

		if(choice != minChoice) choice = minChoice;
	}
}
