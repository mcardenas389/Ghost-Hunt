using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	void OnGUI() {
/*		if(GUI.Button(new Rect(10, 100, 100 , 30), "Health Up")) {
			GameController.control.health += 10;
		}

		if(GUI.Button(new Rect(10, 140, 100 , 30), "Exp Up")) {
			GameController.control.experience += 10;
		}

		if(GUI.Button(new Rect(10, 180, 100 , 30), "Health Down")) {
			GameController.control.health -= 10;
		}
		
		if(GUI.Button(new Rect(10, 220, 100 , 30), "Exp Down")) {
			GameController.control.experience -= 10;
		}
*/
		if(GUI.Button(new Rect(10, 260, 100 , 30), "Save")) {
			GameController.control.Save();
		}

		if(GUI.Button(new Rect(10, 300, 100 , 30), "Load")) {
			GameController.control.Load();
		}
	}
}
