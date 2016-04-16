using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

public class XmlReaderTest : MonoBehaviour {
	//public Dictionary<string, List<string>[]> encounters = new Dictionary<string, List<string>[]>();

	void Start () {
		Read("Assets/Databases/enemy-encounters.xml");
		//Print();
	}
	
	public void Read(string path) {
		List<string>[] enemies;
		XDocument doc = XDocument.Load(path);
		int i;
		string str;

		foreach(XElement el in doc.Root.Elements()) {
			enemies = new List<string>[10];
			Debug.Log(el.Name + " = " + el.Attribute("name").Value);
			str = el.Attribute("name").Value;
			Debug.Log("str = " + str);

			foreach(XElement element in el.Elements()) {
				Debug.Log(element.Name + ": " + element.Attribute("pos").Value);
				i = int.Parse(element.Attribute("pos").Value);
				Debug.Log("i = " + i);
				enemies[i] = new List<string>();

				foreach(XElement e3 in element.Elements()) {
					Debug.Log(e3.Value);
					enemies[i].Add(e3.Value);
				}
			}

			//encounters[str] = enemies;
			GameController.control.encounters[str] = enemies;
		}
	}
	/*
	public void Print() {
		foreach(List<string> encounter in encounters["ghost"]) {
			if(encounter != null)
				for(int i = 0; i < encounter.Count; i++) {
					Debug.Log(i + ". " + encounter[i]);
				}
		}
	}*/
}