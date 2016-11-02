using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text HighScore;
	// Use this for initialization
	void Start () {
		HighScore.text = "Highscore : "+ ((int)PlayerPrefs.GetFloat("Highestscore")).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToGame()
	{
		SceneManager.LoadScene ("Game");
	}
}
