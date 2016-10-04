using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	public float speed;
	private Vector3 targetPos;


	// Use this for initialization
	void Start () {
		targetPos = new Vector3(-15.0f, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Kill") {
			Destroy(gameObject);
		}
	}
}
