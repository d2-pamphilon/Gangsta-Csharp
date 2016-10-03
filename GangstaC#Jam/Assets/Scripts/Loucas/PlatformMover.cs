using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0) * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
