using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    public static ScreenShake instance { get; private set; }
    [SerializeField]
    private  bool testShake;
    private Transform thisTrans;
    private Vector3 startPos;
    private Vector3 newPos;    
    private float min = -1.0f, max = 1.0f;
    [SerializeField]
    private float shakeDuration = 0.5f;
    [SerializeField]
    private float magnitude = 5.0f;
    [SerializeField]
    private float speed = 1.0f;
    

	// Use this for initialization
	void Awake ()
    {
        instance = this;
        thisTrans = transform;
        startPos = thisTrans.position; 
	}

    IEnumerator Shaker()
    {
        float timeElapsed = 0.0f;
        float randomStart = Random.Range(min, max);
        while (timeElapsed < shakeDuration )
        {
            timeElapsed += Time.deltaTime;
            float percent = timeElapsed / shakeDuration;
            float damping = 1.0f - Mathf.Clamp(2.0f * percent - 1.0f, 0.0f, 1.0f);
            float alpha = randomStart + speed * percent;

            float x = Mathf.PerlinNoise(alpha, 0) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0, alpha) * 2.0f - 1.0f;
            x *= magnitude * damping;
            y *= magnitude * damping;
            thisTrans.position = new Vector3(x, y, thisTrans.position.z);
           
            yield return null;
        }
        thisTrans.position = startPos;
    }

    void Shake()
    {
        StopCoroutine("Shaker");
        StartCoroutine("Shaker");
       
    }

	// Update is called once per frame
	void Update () {
        if (testShake)
        {
            Shake();
            testShake = false;
        }
	
	}
}
