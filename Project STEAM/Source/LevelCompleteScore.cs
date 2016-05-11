//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompleteScore : MonoBehaviour {

	public static string prevLevel;
	public Text levelScore, numBonus, timeBonus, total;

	// Use this for initialization
	void Start () {
		if (prevLevel.Equals ("Loops1") || prevLevel.Equals ("Loops2") || prevLevel.Equals ("Loops3") ||
		    prevLevel.Equals ("Loops4") || prevLevel.Equals ("Loops5")) {
			SetScoreOutput (ForMovement.score, ForMovement.bonus, ForMovement.getsNumBonus, ForMovement.getsTimeBonus);
		} else if (prevLevel.Contains ("Conditionals")) {
			SetScoreOutput 
			(ConditionalsMovement.score, ConditionalsMovement.bonus, 
				ConditionalsMovement.getsNumBonus, ConditionalsMovement.getsTimeBonus);
		} else if (prevLevel.Equals ("Loops6") || prevLevel.Equals ("Loops7") || prevLevel.Equals ("Loops8")) {
			SetScoreOutput 
			(WhileMovement.score, WhileMovement.bonus, 
				WhileMovement.getsNumBonus, WhileMovement.getsTimeBonus);
		} else if (prevLevel.Contains ("Math")) {
			SetScoreOutput (MathMovement.numRetries);	
		}
	}

	void SetScoreOutput(int num){
		levelScore.text = "Number of Retries: " + num;
		numBonus.text = "";
		timeBonus.text = "";
		total.text = "";
	}

	void SetScoreOutput(int num, int numB, bool numFlag, bool timeFlag){

		int totalScore = 0;
		int timeB = 2000;

		levelScore.text = "Score : " + num;
		numBonus.text = (numFlag) ? "Number Bonus: " + numB : "Number Bonus: 0";
		timeBonus.text = (timeFlag) ? "Time Bonus: " + timeB : "Time Bonus: 0";

		if (numFlag && timeFlag) {
			totalScore = num + numB + timeB;
		} else if (!numFlag && timeFlag) {
			totalScore = num + timeB;
		} else if (numFlag && !timeFlag) {
			totalScore = num + numB;
		} else {
			totalScore = num;
		}

		total.text = "Total score: " + totalScore;
		
	}

	public void GoToNextLevel(){
		if (prevLevel.Equals ("Loops1")) {
			Application.LoadLevel ("Loops2");
		}else if (prevLevel.Equals ("Loops2")) {
			Application.LoadLevel ("Loops3");
		}else if (prevLevel.Equals ("Loops3")) {
			Application.LoadLevel ("Loops4");
		}else if (prevLevel.Equals ("Loops4")) {
			Application.LoadLevel ("Loops5");
		}else if (prevLevel.Equals ("Loops5")) {
			Application.LoadLevel ("Loops6");
		}else if (prevLevel.Equals ("Loops6")) {
			Application.LoadLevel ("Loops7");
		}else if (prevLevel.Equals ("Loops7")) {
			Application.LoadLevel ("Loops8");
		}else if (prevLevel.Equals ("Loops8")) {
			Application.LoadLevel ("LoopsComplete");
		}

		if (prevLevel.Equals ("Conditionals1")) {
			Application.LoadLevel ("Conditionals2");
		}else if (prevLevel.Equals ("Conditionals2")) {
			Application.LoadLevel ("Conditionals3");
		}else if (prevLevel.Equals ("Conditionals3")) {
			Application.LoadLevel ("Conditionals4");
		}else if (prevLevel.Equals ("Conditionals4")) {
			Application.LoadLevel ("Conditionals5");
		}else if (prevLevel.Equals ("Conditionals5")) {
			Application.LoadLevel ("Conditionals6");
		}else if (prevLevel.Equals ("Conditionals6")) {
			Application.LoadLevel ("ConditionalsComplete");
		}

		if (prevLevel.Equals ("Math1")) {
			Application.LoadLevel ("Math2");
		}else if (prevLevel.Equals ("Math2")) {
			Application.LoadLevel ("Math3");
		}else if (prevLevel.Equals ("Math3")) {
			Application.LoadLevel ("Math4");
		}else if (prevLevel.Equals ("Math4")) {
			Application.LoadLevel ("Math5");
		}else if (prevLevel.Equals ("Math5")) {
			Application.LoadLevel ("Math6");
		}else if (prevLevel.Equals ("Math6")) {
			Application.LoadLevel ("MathComplete");
		}
	}

	public void ToLevelSelect(){
		if (prevLevel.Contains ("Conditionals")) {
			Application.LoadLevel ("ConditionalsLevelSelection");
		}
		if (prevLevel.Contains ("Loops")) {
			Application.LoadLevel ("ForLevelSelection");
		}
		if (prevLevel.Contains ("Math")) {
			Application.LoadLevel ("MathLevelSelection");
		}

	}
}