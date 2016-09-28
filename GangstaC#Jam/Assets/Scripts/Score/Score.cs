using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text scoreTxt;
	public Text highScoreTxt;
	private int score;
	private int highScore;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();

		highScore = 0;
		UpdateHighScore ();
	}
	void Update()
	{
		if (score >= highScore) 
		{
			highScore = score;	
			UpdateHighScore ();
		}
	}

	public void Addscore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	// Update is called once per frame
	void UpdateScore () {
		scoreTxt.text = "Score: " + score;
	}
	void UpdateHighScore()
	{
		highScoreTxt.text = "High Score: " + highScore;
	}
}
