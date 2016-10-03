using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text scoreTxt;
	public Text highScoreTxt;
	public int m_score;
	private int m_highScore;
	private AIJumpScript m_death;
	private Data data;
	public bool death;

	// Use this for initialization
	void Start () {
		
		death = m_death.m_dead; //store the dead bool into this variable
		Debug.Log ("start");

		m_score = 0; //set score to 0 then update
		UpdateScore ();

		m_highScore = 0;//data.Instantiate;
		UpdateHighScore ();

		//get player score
	}


	void Update()
	{
        //If not dead
		if (death == false) {
			//m_score = (int)Time.timeSinceLevelLoad; // set score as the time
			m_score = (int)Time.realtimeSinceStartup;

			UpdateScore ();

			//if the score is greater or equal to the high score then update the highscore
			if (m_score >= m_highScore) {
				m_highScore = m_score;	
				UpdateHighScore ();
				Debug.Log (m_highScore);
			}
		} 
	}


	//add the new score to the original score
	public void Addscore(int newScoreValue)
	{
		m_score += newScoreValue;
		UpdateScore();
	}

	//Update the score and highscore
	void UpdateScore () {
		scoreTxt.text = "Score: " + m_score;
	}
	void UpdateHighScore()
	{
		highScoreTxt.text = "High Score: " + m_highScore;
	}
}
