using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour {
	public static CombatManager combat;

	private Transform camPosition;
	private Transform combatPosition;
	private PlayerController playerController;
	private MainCamera mainCam;
	private CombatStates state;
	private int playerChoice;
	private bool inCombat = false;
	private List<int> actionQueue = new List<int>();

	enum CombatStates {
		START,
		PLAYERCHOICE,
		ENEMYACTION,
		PLAYERACTION,
		WIN,
		LOSE
	}

	void Awake() {
		if(combat == null) {
			DontDestroyOnLoad(gameObject);
			combat = this;
		} else if(combat != this)
			Destroy(gameObject);
	}

	void Start() {
		GameObject gameObj;

		gameObj = GameObject.FindGameObjectWithTag("MainCamera");
		camPosition = gameObj.GetComponent<Transform>();
		mainCam = gameObj.GetComponent<MainCamera>();

		gameObj = GameObject.FindGameObjectWithTag("Player");
		playerController = gameObj.GetComponent<PlayerController>();

		combatPosition = GameObject.Find("combat position").GetComponent<Transform>();

		state = CombatStates.START;
	}
	
	void Update() {
		if(inCombat)
			switch(state) {
				case CombatStates.START:
					Debug.Log("Combat Start");
					//enable ui
					CombatUIController.combatUI.triggerUI();

					state = CombatStates.PLAYERCHOICE;
					break;
				case CombatStates.PLAYERCHOICE:
					//wait for player input
					if(Input.GetButtonDown("Submit")) {
						playerChoice = CombatUIController.combatUI.Choice;
						actionQueue.Add(playerChoice);

						CombatUIController.combatUI.triggerUI();

						state = CombatStates.ENEMYACTION;						
					}				
					break;
				case CombatStates.ENEMYACTION:
					Debug.Log("Enemy Action");
					//enemy takes turns attacking
					state = CombatStates.PLAYERACTION;

					break;
				case CombatStates.PLAYERACTION:
					//player choices are executed and results are determined
					for(int i = 0; i < actionQueue.Count; i++) {
						if(actionQueue[i] == 1) {
							Debug.Log("Attack!");
						}
						else if(actionQueue[i] == 2) {
							Debug.Log("Skill!");
						}
						else if(actionQueue[i] == 3) {
							Debug.Log("Flee!");
						}
						else if(actionQueue[i] == 4) {
							Debug.Log("Defend!");
						}
						else if(actionQueue[i] == 5) {
							Debug.Log("Item!");
						}
					}

					actionQueue.Clear();
					
					state = CombatStates.START;

					break;
				case CombatStates.WIN:
					//player has defeated all enemies; money and loot are awarded
					inCombat = false;
					break;
				case CombatStates.LOSE:
					//player was defeated; give option to return to last save point or title screen
					inCombat = false;
					break;
			}
	}

	//disables movement controls for player character, fade-out, 
	//positions camera to the combat map, initialize encounter, and fade-in
	public void StartCombat() {
		playerController.SetAnimation(false);
		playerController.enabled = !playerController.enabled;
		mainCam.enabled = !mainCam.enabled;
		camPosition.position = combatPosition.position;

		inCombat = true;
	}
}
