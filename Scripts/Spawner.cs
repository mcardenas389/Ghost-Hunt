using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] enemies;

	void Start () {
		int i = Random.Range(0, enemies.Length - 1);

		Debug.Log("Random: " + i);

		if(i != 0)
			Instantiate(enemies[i], transform.position, transform.rotation);
	}
}
