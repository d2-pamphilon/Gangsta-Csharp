using UnityEngine;
using System.Collections;

//kill me

public class MoveLeftScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
	}
}
