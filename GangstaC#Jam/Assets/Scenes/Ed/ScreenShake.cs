using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    public static ScreenShake instance { get; private set; }
    
    
    private Transform thisTrans;
    private Vector3 startPos;     
    private float min = -1.0f, max = 1.0f;
    [SerializeField]
    private float shakeDuration = 0.5f;
    [SerializeField]
    private float magnitude = 5.0f;
    [SerializeField]
    private float speed = 2.0f;

    //Debug variables
    [SerializeField]
    private bool testShake;
    private bool debugCurves = false;
    private AnimationCurve testX = new AnimationCurve();
    private AnimationCurve testY = new AnimationCurve();

    // Use this for initialization
    void Awake ()
    {
        instance = this;
        thisTrans = transform;
        startPos = thisTrans.position; 
	}

    IEnumerator Shaker()
    {        
        testX = debugCurves ? new AnimationCurve() : testX;
        testY = debugCurves ? new AnimationCurve() : testY;
        float timeElapsed = 0.0f;
        float randomX = Random.Range(min, max);
        float randomY = Random.Range(min, max);
        while (timeElapsed < shakeDuration)
        {
            timeElapsed += Time.deltaTime;
            float percent = timeElapsed / shakeDuration;
            float damping = 1.0f - Mathf.Clamp(2.0f * percent - 1.0f, 0.0f, 1.0f);
            float alphaX = randomX + speed * percent;
            float alphaY = randomY + speed * percent;

            float x = Mathf.PerlinNoise(alphaX, 0) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0, alphaY) * 2.0f - 1.0f;
            if (debugCurves)
            {
                testX.AddKey(timeElapsed, x);
                testY.AddKey(timeElapsed, y);
            }
            x *= magnitude * damping;
            y *= magnitude * damping;
            thisTrans.position = new Vector3(x, y, thisTrans.position.z);
           
            yield return null;
        }
        thisTrans.position = startPos;
    }

    public void Shake()
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
