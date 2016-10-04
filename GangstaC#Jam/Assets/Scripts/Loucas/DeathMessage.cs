using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMessage : MonoBehaviour {

	public GameObject runner;
	public Text deathText, promptText;
	public string[] deathMessages;
	bool spawnedMessage;
	Color[] colors  = {Color.red, Color.cyan, Color.yellow , Color.green, Color.magenta, Color.white};

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
		deathText.text = "";
        promptText.text = "";
		spawnedMessage = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (runner.GetComponent<AIJumpScript>().m_dead && !spawnedMessage) {
			deathText.text = deathMessages[(int)Random.Range(0, deathMessages.Length)];
            promptText.text = "Press ESC to restart";
            deathText.color = colors[(int)Random.Range(0, colors.Length)];
            promptText.color = deathText.color;
			spawnedMessage = true;
		}
        if (spawnedMessage)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                //print("exit game");
                SceneManager.LoadScene(1);
                //  Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
