//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using System.Collections;

public class TryAgain : MonoBehaviour {

	public static string levelName;

	public void TryLevelAgain(){
		Application.LoadLevel(levelName);
	}

}