//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MathLevelScoreManager : MonoBehaviour {

	public Text totalText;
	public static int total = 0;
	public static bool level1Perfect, level2Perfect, level3Perfect, level4Perfect, level5Perfect, level6Perfect;

	private bool l1, l2, l3, l4, l5, l6;
	private bool[] rightOrWrong;

	void Awake(){
		l1 = level1Perfect;
		l2 = level2Perfect;
		l3 = level3Perfect;
		l4 = level4Perfect;
		l5 = level5Perfect;
		l6 = level6Perfect;
		rightOrWrong = new bool[6]{l1, l2, l3, l4, l5, l6};
		foreach (bool flag in rightOrWrong) {
			if (flag) {
				total++;
			}
		}
		ShowScore ();
	}

	void ShowScore(){
		totalText.text = "Total Perfect: " + total;
	}
}