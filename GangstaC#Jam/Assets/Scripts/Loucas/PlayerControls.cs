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
			if (playerID == 0) {
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
			if (playerID == 1) {
				if (Input.GetKeyDown(KeyCode.A)) {
					print("Pressed A Button");
					currentShape.transform.position += new Vector3(-moveDistance, 0.0f, 0.0f);
				}
				if (Input.GetKeyDown(KeyCode.D)) {
					print("Pressed D Button");
					currentShape.transform.position += new Vector3(moveDistance, 0.0f, 0.0f);
				}
				if (Input.GetKey(KeyCode.S)) {
					print("Pressed S Button");
					currentShape.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * (Time.deltaTime * moveSpeed);
				}
				if (Input.GetKeyDown(KeyCode.W)) {
					print("Pressed W Button");
					currentShape.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRot);
					currentRot += 90.0f;
				}
			}
			if (playerID == 2) {
				if (Input.GetKeyDown(KeyCode.J)) {
					print("Pressed J Button");
					currentShape.transform.position += new Vector3(-moveDistance, 0.0f, 0.0f);
				}
				if (Input.GetKeyDown(KeyCode.L)) {
					print("Pressed L Button");
					currentShape.transform.position += new Vector3(moveDistance, 0.0f, 0.0f);
				}
				if (Input.GetKey(KeyCode.K)) {
					print("Pressed K Button");
					currentShape.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * (Time.deltaTime * moveSpeed);
				}
				if (Input.GetKeyDown(KeyCode.I)) {
					print("Pressed I Button");
					currentShape.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRot);
					currentRot += 90.0f;
				}
			}
			if (playerID == 3) {
				if (Input.GetKeyDown(KeyCode.Keypad4)) {
					print("Pressed Keypad 4 Button");
					currentShape.transform.position += new Vector3(-moveDistance, 0.0f, 0.0f);
				}
				if (Input.GetKeyDown(KeyCode.Keypad6)) {
					print("Pressed Keypad 6 Button");
					currentShape.transform.position += new Vector3(moveDistance, 0.0f, 0.0f);
				}
				if (Input.GetKey(KeyCode.Keypad5)) {
					print("Pressed Keypad 5 Button");
					currentShape.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * (Time.deltaTime * moveSpeed);
				}
				if (Input.GetKeyDown(KeyCode.Keypad8)) {
					print("Pressed Keypad 8 Button");
					currentShape.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRot);
					//currentShape.transform.RotateAround
					currentRot += 90.0f;
				}
			}

		}
	}
}
