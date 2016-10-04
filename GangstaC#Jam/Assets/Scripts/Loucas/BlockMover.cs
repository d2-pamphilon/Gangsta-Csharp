using UnityEngine;
using System.Collections;

public class BlockMover : MonoBehaviour {

	GameObject player, spawner;
	public bool hasInitiallyCollided;

	// Use this for initialization
	void Start () {
		hasInitiallyCollided = false;
		player = GameObject.FindGameObjectWithTag("Player");
		spawner = GameObject.FindGameObjectWithTag("Respawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		gameObject.AddComponent<PlatformMover>();
		gameObject.GetComponent<PlatformMover>().speed = 10.0f;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		gameObject.tag = "Terrain";
		player.GetComponent<PlayerControls>().currentShape = null;
		if (!hasInitiallyCollided) {
			spawner.GetComponent<Spawner>().setNextBlockSpawnTrue();
			hasInitiallyCollided = true;
		}
		//player.GetComponent<PlayerControls>().currentShape = null;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Bottom") {
			player.GetComponent<PlayerControls>().currentShape = null;
			if (!hasInitiallyCollided) {
				spawner.GetComponent<Spawner>().setNextBlockSpawnTrue();
				hasInitiallyCollided = true;
			}

		}
	}
}
