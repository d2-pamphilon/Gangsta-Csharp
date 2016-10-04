using UnityEngine;
using System.Collections;

public class BgScroll : MonoBehaviour {

    public float speed = 0.0f;
    public Renderer rend;
    public Vector2 test;
	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rend.sharedMaterial.mainTextureOffset = test + new Vector2(0.1f * speed * Time.deltaTime, 0);
        test = rend.material.mainTextureOffset;
	}
}
