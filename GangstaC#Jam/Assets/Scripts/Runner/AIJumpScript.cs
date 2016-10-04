using UnityEngine;
using System.Collections;

public class AIJumpScript : MonoBehaviour
{
    //he dead?
    public bool m_dead;
    //he on da ground?
    public bool m_onGround = false;

    //How strong are the runner's legs
    public float m_jumpPower = 100.0f;
    //How good is the runner's eyesight
    public float m_visionRange = 5.0f;

    // Use this for initialization
    void Start()
    {
    	m_dead = false;
    }

    void Update()
    {
        Vector2 rayPos = transform.position;
        BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
        RaycastHit2D[] rayHits;
        rayHits = Physics2D.RaycastAll(rayPos, -Vector2.up, 0.6f);
        bool hitDaGround = false;
        foreach(RaycastHit2D hit in rayHits)
        {
            if (hit.collider.tag == "Terrain")
            {
                m_onGround = true;
                hitDaGround = true;
                break;
            }
        }
        if(!hitDaGround)
        {
            m_onGround = false;
        }
    }

    void FixedUpdate()
    {
        BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
        if (m_onGround)
        {
            //Check in front for blocks + jump if there's something there
            Vector2 rayPos = transform.position;

            if (hitbox != null)
            {
                //set ray pos to start just outside of the hitbox
                rayPos.x += hitbox.size.x / 2.0f + 0.05f;
            }
            rayPos.y += hitbox.size.y / 2.0f - 0.05f;
            for (int i = 0; i < 3; i++)
            {
                RaycastHit2D rayResult = Physics2D.Raycast(rayPos, new Vector2(1, 0), m_visionRange);
                //if there was collision
                if (rayResult.collider != null)
                {
                    //if he on da ground
                    if (m_onGround && rayResult.collider.tag == "Terrain")
                    {
                        Jump();
                        break;
                    }
                }
                rayPos.y -= (hitbox.size.y / 2.0f - 0.1f);
            }
        }
        if(m_onGround)
        {
            Vector2 potentialGapPos = transform.position;
            potentialGapPos.x += (hitbox.size.x/2 + 0.5f);
            potentialGapPos.y -= (hitbox.size.y/2 + 0.5f);
            Collider2D coll = Physics2D.OverlapPoint(potentialGapPos);
            if(coll == null)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        Rigidbody2D physics = GetComponent<Rigidbody2D>();
        //if we actually have a rigidbody2d attached
        if (physics != null)
        {
            //push up lad
            Vector2 vel = physics.velocity;
            vel.y = m_jumpPower;
            physics.velocity = vel;
            m_onGround = false;
        }
        else
        {
            Debug.Log("No rigidbody??");
        }
    }
	void OnCollisionEnter2D(Collision2D other) {
    	if (other.gameObject.tag == "Terrain") {
    		print("On platform");
    	}
    }

    void OnCollisionExit2D(Collision2D other) {
    	if (other.gameObject.tag == "Terrain") {
    		print("Jumping off platform");
			Rigidbody2D physics = GetComponent<Rigidbody2D>();
			physics.AddForce(new Vector2(0, m_jumpPower));
            m_onGround = false;
    	}
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "Kill"){
    		m_dead = true;
    		//Destroy(gameObject, 5.0f);
    	}
    	if (other.tag == "JumpBox") {
			print("Jumping off platform");
			Rigidbody2D physics = GetComponent<Rigidbody2D>();
			physics.AddForce(new Vector2(0, m_jumpPower));
            m_onGround = false;
    	}
    }
}
