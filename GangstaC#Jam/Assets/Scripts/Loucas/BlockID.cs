using UnityEngine;
using System.Collections;

public class BlockID : MonoBehaviour {

	public int blockID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetBlockID(int newID) {
		blockID = newID;
	}

	public int GetBlockID() {
		return blockID;
	}
}
