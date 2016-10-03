using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public GameObject[] platformPrefabs;
	public float spawnWait, startWait, newForce, speed;
	public int platformCount;
	public Vector3 spawnValues;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnPlatform());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnPlatform() {
		yield return new WaitForSeconds(startWait);
		while(true) {
			platformCount = Random.Range(1, 3);
			for (int i = 0; i < platformCount; i++) {
				Vector3 spawnPos = new Vector3(spawnValues.x, Random.Range(spawnValues.y, spawnValues.z), 0.0f);
				Quaternion spawnRot = Quaternion.identity;
				GameObject tempPlatform = (GameObject)Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], spawnPos, spawnRot);
				tempPlatform.GetComponent<Rigidbody2D>().AddForce(new Vector2(newForce, 0) * (Time.deltaTime * speed));
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}
}
