using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
	public static GameController control;
	public Stats[] playerStats;

	private PlayerData data;

	void Awake() {
		if(control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if(control != this) {
			Destroy(gameObject);
		}
	}

	void Start() {
		playerStats = new Stats[2];

		playerStats[0] = new Stats("Joe", "Nerd", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
		playerStats[1] = new Stats("Steve", "Nerd", 10, 2, 3, 4, 5, 6, 7, 8, 9, 10);
	}

	public void Save() {
		BinaryFormatter binForm = new BinaryFormatter();
		FileStream file = File.Open("C:/Users/Michael/Documents/Unity Test Games/Nov2015/save.dat", FileMode.Create);

		PlayerData data = new PlayerData();
		data.playerStats = playerStats;

		//data.health = health;
		//data.experience = experience;

		binForm.Serialize(file, data);
		file.Close();
	}

	public void Load() {
		if(File.Exists("C:/Users/Michael/Documents/Unity Test Games/Nov2015/save.dat")) {
			BinaryFormatter binForm = new BinaryFormatter();
			FileStream file = File.Open("C:/Users/Michael/Documents/Unity Test Games/Nov2015/save.dat", FileMode.Open);
			PlayerData data = (PlayerData)binForm.Deserialize(file);

			Debug.Log("P1 health: " + data.playerStats[0].health);
			Debug.Log("P2 health: " + data.playerStats[1].health);
		}
	}

	public void Test() {
		Debug.Log("Success");
	}

	T[] InitializeArray<T>(int length) where T : new()
	{
		T[] array = new T[length];
		for (int i = 0; i < length; ++i)
		{
			array[i] = new T();
		}
		
		return array;
	}
}

[Serializable]
class PlayerData
{
	public Stats[] playerStats;
	//public bool[] flags;
}