using UnityEngine;
using System.Collections;


public class Data : MonoBehaviour {

    public static Data instance { get; private set; }

    private string str = "HighScore";

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
	}

	 public bool SetHighScore(float hs)
    {
        if (PlayerPrefs.HasKey(str))
        {
            if ( PlayerPrefs.GetFloat(str)< hs)
            {
                PlayerPrefs.SetFloat(str, hs);
                PlayerPrefs.Save();
                return true;
            } 
        }
        else
        {
            PlayerPrefs.SetFloat(str, hs);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }
    public float  GetHighScore()
    {
        if (PlayerPrefs.HasKey(str))
            return (PlayerPrefs.GetFloat(str));
        else
            return 0.0f;
    }
}
