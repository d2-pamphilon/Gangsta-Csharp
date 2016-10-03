using UnityEngine;
using System.Collections;

public class ExplosionCall : MonoBehaviour {

    bool isPlaying;
    private float activeTime;
    public float duration = 1.5f;
	
	// Update is called once per frame
	void Update ()
    {
        if (isPlaying)
        {
            activeTime += Time.deltaTime;
        }
        if (activeTime > duration)
        {
            isPlaying = false;
            gameObject.SetActive(false);
        }
	
	}
    public void Play()
    {
        isPlaying = true;
        activeTime = 0.0f;
    }
    
}
