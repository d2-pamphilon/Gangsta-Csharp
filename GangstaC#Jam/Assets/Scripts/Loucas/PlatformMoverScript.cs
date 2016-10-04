using UnityEngine;
using System.Collections;

public class PlatformMoverScript : MonoBehaviour {

	public float speed;
	//private Vector3 targetPos;


	// Use this for initialization
	void Start () {
		//targetPos = new Vector3(-15.0f, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 vel = new Vector2(-speed, 0);
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        Rigidbody2D physics = GetComponent<Rigidbody2D>();
        if(physics != null)
        { 
            physics.velocity = vel;
        }
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Kill") {
			Destroy(gameObject);
		}
	}
}
