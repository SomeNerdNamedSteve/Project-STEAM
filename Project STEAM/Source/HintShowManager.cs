//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintShowManager : MonoBehaviour {

	public Text Hint;
	bool showing = false;

	public void ToggleHint(){
		showing = !showing;
		Hint.enabled = (showing) ? true : false;	
	}
}