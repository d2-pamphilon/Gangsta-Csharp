using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float lifetime = 10f;
    public Rigidbody rb;
    private bool collided;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnerCurrBlock")
        {
            collided = true;
        }

        //Turn on kinematic when block hits the floor, or other blocks
        //if (other.tag == "Floor")
        //{
        //    collided = false;
        //}
    }

    void Update ()
    {
        if (collided)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
    

	
}
