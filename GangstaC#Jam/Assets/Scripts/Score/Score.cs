using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text scoreTxt;
	public Text highScoreTxt;
	public int m_score;
	private int m_highScore;
	private bool m_death;
	private Data data;


	[SerializeField] GameObject aiJump;

	// Use this for initialization
	void Start () {
		m_death = aiJump.GetComponent<AIJumpScript>().m_dead;
		
		//death = m_death.m_dead; //store the dead bool into this variable



		m_score = 0; //set score to 0 then update
		UpdateScore ();

		m_highScore = (int)Data.instance.GetHighScore ();
		UpdateHighScore ();
		Debug.Log (m_highScore);

		//get player score
	}


	void Update()
	{
		Debug.Log (m_highScore);
        //If not dead
		if (m_death == false) {
			m_score = (int)Time.timeSinceLevelLoad; // set score as the time
			//m_score = (int)Time.realtimeSinceStartup;

			UpdateScore ();

			//if the score is greater or equal to the high score then update the highscore
			if (m_score >= m_highScore) {
				m_highScore = m_score;	
				UpdateHighScore ();
				Debug.Log (m_highScore);
			}
		} else {
			Data.instance.SetHighScore (m_highScore);
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
		if (m_highScore >= Data.instance.GetHighScore ()) {
			highScoreTxt.text = "High Score: " + m_highScore;
		} 
		else {
			highScoreTxt.text = "High Score: " + Data.instance.GetHighScore ();
		}
			
	}
	void OnApplicationQuit()
	{
		Data.instance.SetHighScore (m_highScore);
	}
}
