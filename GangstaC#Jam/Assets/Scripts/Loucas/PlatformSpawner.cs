using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public GameObject[] platformPrefabs;
	public float spawnWait, startWait, newForce;
	public int platformCount;
	public Vector3 spawnValues;
    public float difficultyIncreaseTime = 6.0f; //time for difficulty to reach maximum in seconds
    private float stopwatch = 0.0f;
    private float difficultyMultiplier = 0.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnPlatform());
	}
	
	// Update is called once per frame
	void Update () {
        stopwatch += Time.deltaTime;
        if(stopwatch > difficultyIncreaseTime)
        {
            stopwatch = difficultyIncreaseTime;
        }
        difficultyMultiplier = stopwatch / difficultyIncreaseTime;
	}

	IEnumerator SpawnPlatform() {
		yield return new WaitForSeconds(startWait);
		while(true) {
			platformCount = Random.Range(1, 3);
			for (int i = 0; i < platformCount; i++) {
                float range = spawnValues.z - spawnValues.y;
                range *= difficultyMultiplier;
				Vector3 spawnPos = new Vector3(spawnValues.x, Random.Range((int)spawnValues.y, (int)(spawnValues.y + range)), 0.0f);
				Quaternion spawnRot = Quaternion.identity;
				GameObject tempPlatform = (GameObject)Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], spawnPos, spawnRot);
				//tempPlatform.GetComponent<Rigidbody2D>().AddForce(new Vector2(newForce, 0) * (Time.deltaTime * speed));
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}
}
