using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	private GameObject currentShape;
	private GameObject[] shapesSpawned;
	public float moveSpeed, moveDistance;
	private float currentRot;
	private int playerID;

	// Use this for initialization
	void Start () {
		currentRot = 90.0f;
		playerID = GetComponent<PlayerID>().GetPlayerID();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentShape == null) {
			shapesSpawned = GameObject.FindGameObjectsWithTag("CurrentShape");
			for (int i = 0; i < shapesSpawned.Length; i++) {
				int tempBlockID = shapesSpawned[i].GetComponent<BlockID>().GetBlockID();
				if (tempBlockID == playerID) {
					currentShape = shapesSpawned[i].gameObject;
				}
			}
			//currentShape = GameObject.FindGameObjectWithTag("CurrentShape");
		}
		if (currentShape != null) {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				print("Pressed Left Arrow Button");
				currentShape.transform.position += new Vector3(-moveDistance, 0.0f, 0.0f);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				print("Pressed Right Arrow Button");
				currentShape.transform.position += new Vector3(moveDistance, 0.0f, 0.0f);
			}
			if (Input.GetKey(KeyCode.DownArrow)) {
				print("Pressed Down Arrow Button");
				currentShape.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * (Time.deltaTime * moveSpeed);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				print("Pressed Down Arrow Button");
				currentShape.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRot);
				currentRot += 90.0f;
			}
		}
	}
}
