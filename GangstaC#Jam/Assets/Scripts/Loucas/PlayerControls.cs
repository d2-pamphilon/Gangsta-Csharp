using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public GameObject currentShape, spawner;
	private GameObject[] shapesSpawned;
	public float fallSpeed, moveDistance, higherFallSpeed;
	private float currentRot;
	private int playerID;
	private bool canMoveBlock;

	// Use this for initialization
	void Start () {
		currentRot = 90.0f;
		playerID = GetComponent<PlayerID>().GetPlayerID();
		canMoveBlock = false;
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D body = currentShape.GetComponent<Rigidbody2D>();
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
                    Vector2 vel = body.velocity;
                    vel.y = -higherFallSpeed;
                    body.velocity = vel;
				}
                else
                {
                    Vector2 vel = body.velocity;
                    vel.y = -fallSpeed;
                    body.velocity = vel;
                }
				if (Input.GetKeyDown(KeyCode.UpArrow)) {
					print("Pressed Up Arrow Button");
					Transform rotPoint = currentShape.gameObject.transform.FindChild("RotatePoint");
					currentShape.transform.RotateAround(rotPoint.transform.position, Vector3.forward, currentRot);
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
                    Vector2 vel = body.velocity;
                    vel.y = -higherFallSpeed;
                    body.velocity = vel;
                }
                else
                {
                    Vector2 vel = body.velocity;
                    vel.y = -fallSpeed;
                    body.velocity = vel;
                }
                if (Input.GetKeyDown(KeyCode.W)) {
					print("Pressed W Button");
					Transform rotPoint = currentShape.gameObject.transform.FindChild("RotatePoint");
					currentShape.transform.RotateAround(rotPoint.transform.position, Vector3.forward, currentRot);
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
                    Vector2 vel = body.velocity;
                    vel.y = -higherFallSpeed;
                    body.velocity = vel;
                }
                else
                {
                    Vector2 vel = body.velocity;
                    vel.y = -fallSpeed;
                    body.velocity = vel;
                }
                if (Input.GetKeyDown(KeyCode.I)) {
					print("Pressed I Button");
					Transform rotPoint = currentShape.gameObject.transform.FindChild("RotatePoint");
					currentShape.transform.RotateAround(rotPoint.transform.position, Vector3.forward, currentRot);
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
                    Vector2 vel = body.velocity;
                    vel.y = -higherFallSpeed;
                    body.velocity = vel;
                }
                else
                {
                    Vector2 vel = body.velocity;
                    vel.y = -fallSpeed;
                    body.velocity = vel;
                }
                if (Input.GetKeyDown(KeyCode.Keypad8)) {
					print("Pressed Keypad 8 Button");
					Transform rotPoint = currentShape.gameObject.transform.FindChild("RotatePoint");
					currentShape.transform.RotateAround(rotPoint.transform.position, Vector3.forward, currentRot);
				}
			}

		}
	}

	public void setCanMoveBlock(bool newBoolValue) {
		canMoveBlock = newBoolValue;
	}

	public GameObject getCurrentShape() {
		return currentShape;
	}
}
