using UnityEngine;
using System.Collections;

public class BasePlatformDestroy : MonoBehaviour {

	public float lifetime = 10f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
