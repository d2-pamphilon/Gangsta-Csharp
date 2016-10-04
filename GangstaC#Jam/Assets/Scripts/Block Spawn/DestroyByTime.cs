using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float lifetime = 10f;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, lifetime);
    }

}
