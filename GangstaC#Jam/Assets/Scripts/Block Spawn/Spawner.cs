using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject[] blockPrefab;
    public GameObject[] nextBlockPrefab;
    public Transform[] spawnPoints;
    public int blockCount = 64;             // Amount of usable blocks
    public float spawnTime = 3f;            // How long between each spawn
	public GameObject currentBlock;
    GameObject tempBlock;
	public GameObject player, runner;
	private bool spawnNextBlock, spawnedFirstBlock;


    // Use this for initialization
    void Start () {
       
       // StartCoroutine(Spawn());
       StartCoroutine(TestStartSpawner());
    }

    void Update() {
		if (!runner.GetComponent<AIJumpScript>().m_dead) {
			if(spawnedFirstBlock) {
				spawnNextBlock = true;
				spawnedFirstBlock = false;
			}
			if (spawnNextBlock) {
				spawnNextBlock = false;
				StartCoroutine(TestSpawner());
				//spawnNextBlock = true;
			/*for (int i = 0; i < blockCount; i++)
	        {

	            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
	            tempBlock = (GameObject)Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
	            tempBlock.GetComponent<Rigidbody2D>().isKinematic = true;
	            StartCoroutine(Waiter());

	            currentBlock = tempBlock;
	            currentBlock.transform.position = spawnPoints[0].position;
	            currentBlock.GetComponent<Rigidbody2D>().isKinematic = false;

	        }*/
	        }
		}
    }

	IEnumerator Spawn()
    {
        for (int i = 0; i < blockCount; i++)
        {

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            tempBlock = (GameObject)Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
            tempBlock.GetComponent<Rigidbody2D>().isKinematic = true;
            yield return new WaitForSeconds(spawnTime);

            currentBlock = tempBlock;
            currentBlock.transform.position = spawnPoints[0].position;
            currentBlock.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<PlayerControls>().currentShape = currentBlock.gameObject;

        }
    }

    IEnumerator Waiter() {
		yield return new WaitForSeconds(spawnTime);
    }

    IEnumerator TestStartSpawner() {
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            tempBlock = (GameObject)Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
            tempBlock.GetComponent<Rigidbody2D>().isKinematic = true;
            //tempBlock.gameObject.tag = "Temp";
            yield return new WaitForSeconds(spawnTime);

            currentBlock = tempBlock;
            currentBlock.transform.position = spawnPoints[0].position;
            currentBlock.GetComponent<Rigidbody2D>().isKinematic = false;
			player.GetComponent<PlayerControls>().currentShape = currentBlock.gameObject;
			//currentBlock.gameObject.tag = "CurrentBlock";

			tempBlock = (GameObject)Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
            tempBlock.GetComponent<Rigidbody2D>().isKinematic = true;
			//tempBlock.gameObject.tag = "Temp";
            spawnedFirstBlock = true;
    }


    IEnumerator TestSpawner() {
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            
            yield return new WaitForSeconds(spawnTime);

            currentBlock = tempBlock;
            currentBlock.transform.position = spawnPoints[0].position;
            currentBlock.GetComponent<Rigidbody2D>().isKinematic = false;
			player.GetComponent<PlayerControls>().currentShape = currentBlock.gameObject;
			//currentBlock.gameObject.tag = "CurrentBlock";

			tempBlock = (GameObject)Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
            tempBlock.GetComponent<Rigidbody2D>().isKinematic = true;
			//tempBlock.gameObject.tag = "Temp";
    }

    public void setNextBlockSpawnTrue() {
    	spawnNextBlock = true;
    }
}
