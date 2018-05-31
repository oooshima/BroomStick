using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour {
	public Text ShowScore;
	// Use this for initialization
	void Start () {
		ShowScore.text = GameManager.point.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		var color = ShowScore.color;
		color.a += 0.005f;
		ShowScore.color = color;

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameManager.time = 50.0f;
			SceneManager.LoadScene ("Main");
		}

	}
}
