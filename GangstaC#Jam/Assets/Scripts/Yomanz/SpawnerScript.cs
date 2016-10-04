using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public GameObject[] blockPrefab;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;            // How long between each spawn
    private GameObject currentBlock;
    GameObject upcomingBlock;
    public GameObject player, runner;
    private bool spawnedFirstBlock;
    private float stopwatch;

    // Use this for initialization
    void Start ()
    {
        stopwatch = 0.0f;
        spawnedFirstBlock = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!spawnedFirstBlock)
        {
            stopwatch += Time.deltaTime;
            if (stopwatch > spawnTime)
            {
                SpawnUpcomingBlock();
                Spawn();
                stopwatch -= spawnTime;
                spawnedFirstBlock = true;
            }
        }
        else
        {
            if(!currentBlock.GetComponent<BlockMoveScript>().IsAlive())
            {
                Destroy(currentBlock);
                Spawn();
            }
            if (currentBlock.GetComponent<BlockMoveScript>().IsPlaced())
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        currentBlock = upcomingBlock;
        currentBlock.transform.position = spawnPoints[0].position;
        currentBlock.GetComponent<Rigidbody2D>().isKinematic = false;
        currentBlock.GetComponent<BoxCollider2D>().enabled = true;
        SpawnUpcomingBlock();
        player.GetComponent<PlayerControls>().currentShape = currentBlock.gameObject;
    }

    private void SpawnUpcomingBlock()
    {
        upcomingBlock = (GameObject)Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
        upcomingBlock.GetComponent<Rigidbody2D>().isKinematic = true;
        upcomingBlock.GetComponent<BoxCollider2D>().enabled = false;
    }
}
