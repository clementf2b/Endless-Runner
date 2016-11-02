﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public Text scoreText;
	public Image backgroundImg;

	private float transition = 0.0f;
	private bool isShowned = false;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShowned)
			return;

		transition += Time.deltaTime;
		backgroundImg.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	}

	public void ToggleEndMenu(float score)
	{
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isShowned = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void ToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}