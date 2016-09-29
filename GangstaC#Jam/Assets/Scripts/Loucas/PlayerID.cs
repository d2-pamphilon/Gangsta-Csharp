using UnityEngine;
using System.Collections;

public class PlayerID : MonoBehaviour {

	protected int playerID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetPlayerID(int newID) {
		playerID = newID;
	}

	public int GetPlayerID() {
		return playerID;
	}
}
