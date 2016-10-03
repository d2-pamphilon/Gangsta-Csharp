using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionManager : MonoBehaviour {

    public static ExplosionManager instance { get; private set; }
    public int poolSize = 5;
    public bool hidePool = false;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private List<GameObject> explosionPool;
    private int indexer = 0;
    static Quaternion defaultRot = Quaternion.Euler(0, 0, 0);
    public bool test = false;

    // Use this for initialization
    void Awake () {
        instance = this;
        PopulatePool();
	
	}
    private void PopulatePool()
    {
        GameObject temp;

        foreach (GameObject gO in explosionPool)
        {
            Destroy(gO);
        }
        explosionPool.Clear();
        for(int i = 0; i < poolSize; i ++)
        {
            temp = Instantiate(explosionPrefab);
            temp.SetActive(false);
            if (hidePool)
                temp.hideFlags = HideFlags.HideInHierarchy;
            explosionPool.Add(temp);            
        }
    }
    public void Call(Vector3 _pos)
    {
        
        GameObject temp = explosionPool[indexer];
        temp.transform.position = _pos;
        temp.transform.rotation = defaultRot;
        temp.SetActive(true);
        temp.GetComponent<ExplosionCall>().Play();
        indexer = (indexer + 1) >= explosionPool.Count ? 0 : indexer + 1;
    }

    public void Call(Vector3 _pos, Vector3 _normal )
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, _normal);
        GameObject temp = explosionPool[indexer];
        temp.transform.position = _pos;
        temp.transform.rotation = rot;
        temp.SetActive(true);
        temp.GetComponent<ExplosionCall>().Play();
        indexer = (indexer + 1) >= explosionPool.Count ? 0 : indexer + 1;
       
    }

    // Update is called once per frame
    void Update ()
    {
        if (test)
        {
            Call(Vector3.zero);
            test = false;
        }
	}
}
