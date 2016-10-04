using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathMessage : MonoBehaviour {

	public GameObject runner;
	public Text deathText;
	public string[] deathMessages;
	bool spawnedMessage;
	Color[] colors  = {Color.red, Color.cyan, Color.yellow , Color.green, Color.magenta, Color.white};

	// Use this for initialization
	void Start () {
		deathText.text = "";
		spawnedMessage = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (runner.GetComponent<AIJumpScript>().m_dead && !spawnedMessage) {
			deathText.text = deathMessages[(int)Random.Range(0, deathMessages.Length)];
			deathText.color = colors[(int)Random.Range(0, colors.Length)];
			spawnedMessage = true;
		}
	}
}
