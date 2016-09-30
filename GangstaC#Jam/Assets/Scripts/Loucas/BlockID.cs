using UnityEngine;
using System.Collections;

public class BlockID : MonoBehaviour {

	public int blockID;
	public Sprite blockSprite;
	private bool spriteSet;

	// Use this for initialization
	void Start () {
		spriteSet = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!spriteSet) {
			SetSprite(blockSprite);
		}
	}

	public void SetBlockID(int newID) {
		blockID = newID;
	}

	public int GetBlockID() {
		return blockID;
	}

	public void SetSprite(Sprite newSprite) {
		gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
	}
}
