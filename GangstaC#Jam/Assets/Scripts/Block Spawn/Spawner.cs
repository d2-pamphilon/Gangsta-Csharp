using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject[] blockPrefab;
    public Transform[] spawnPoints;
    public int blockCount = 64;             // Amount of usable blocks
    public float spawnTime = 3f;            // How long between each spawn

    // Use this for initialization
    void Start () {

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < blockCount; i++)
        {
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[0].position, spawnPoints[0].rotation);
            Instantiate(blockPrefab[Random.Range(0, 6)], spawnPoints[1].position, spawnPoints[0].rotation);
            yield return new WaitForSeconds(spawnTime);
        }
 
    }
}
