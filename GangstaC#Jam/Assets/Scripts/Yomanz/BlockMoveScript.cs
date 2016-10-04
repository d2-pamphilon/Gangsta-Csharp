using UnityEngine;
using System.Collections;

public class BlockMoveScript : MonoBehaviour {

    [SerializeField] private bool hasInitiallyCollided;
    [SerializeField] private bool placed;
    [SerializeField] private bool alive;

    // Use this for initialization
    void Start () {
        alive = true;
        placed = false;
        hasInitiallyCollided = false;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasInitiallyCollided)
        {
            PlatformMoverScript mover = gameObject.AddComponent<PlatformMoverScript>();
            mover.speed = 10.0f;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.tag = "Terrain";
            hasInitiallyCollided = true;
            placed = true;
            ScreenShake.instance.Shake();

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bottom")
        {
            alive = false;
            hasInitiallyCollided = true;
        }
    }

    public bool IsAlive()
    {
        return alive;
    }

    public bool IsPlaced()
    {
        return placed;
    }
}
