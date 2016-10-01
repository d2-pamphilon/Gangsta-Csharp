using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    List<int> blockQ = new List<int>();
    public GameObject[] blockPrefab;
    public Transform[] spawnPoints;         // Spawn from either current or next spawner
    public float spawnTime = 3f;            // How long between each spawn


    // Use this for initialization
    void Start () {

        for (int i = 0; i < 10; i++)
        {
            blockQ.Add(Random.Range(0, 6));
        }
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn()
    {
        for (int j = 0; j < 10; j++)
        {
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(blockPrefab[blockQ[j]], spawnPoints[0].position, spawnPoints[0].rotation);
            Instantiate(blockPrefab[blockQ[j]+1], spawnPoints[1].position, spawnPoints[0].rotation);
        }
    }
}
