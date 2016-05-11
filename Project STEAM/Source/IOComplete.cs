//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IOComplete : MonoBehaviour {
	
	public Text showScore;
	public static int score;

	// Use this for initialization
	void Start () {
		showScore.text = "Score: " + score;
	}

}