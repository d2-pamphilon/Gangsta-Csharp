using UnityEngine;
using System.Collections;

public class AIJumpScript : MonoBehaviour
{
    //he dead?
    private bool m_dead = false;
    //he on da ground?
    public bool m_onGround = false;

    //How strong are the runner's legs
    public float m_jumpPower = 100.0f;
    //How good is the runner's eyesight
    public float m_visionRange = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        Vector2 rayPos = transform.position;
        BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
        RaycastHit2D[] rayHits;
        rayHits = Physics2D.RaycastAll(rayPos, -Vector2.up, 1.0f);
        foreach(RaycastHit2D hit in rayHits)
        {
            if (hit.collider.tag == "Terrain")
            {
                m_onGround = true;
                break;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 rayPos = transform.position;
        BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
        if (hitbox != null)
        {
            //set ray pos to start just outside of the hitbox
            rayPos.x += GetComponent<BoxCollider2D>().size.x / 2.0f + 0.1f;
        }
        RaycastHit2D rayResult = Physics2D.Raycast(rayPos, new Vector2(1, 0), m_visionRange);
        //if there was collision
        if (rayResult.collider != null)
        {
            //if he on da ground
            if(m_onGround)
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
            physics.AddForce(new Vector2(0, m_jumpPower));
            m_onGround = false;
        }
        else
        {
            Debug.Log("No rigidbody??");
        }
    }


}
