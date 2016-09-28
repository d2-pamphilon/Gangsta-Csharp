using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private GameObject[] players;

	// Use this for initialization
	void Awake () {
		players = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < players.Length; i++) {
			players[i].GetComponent<PlayerID>().SetPlayerID(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
