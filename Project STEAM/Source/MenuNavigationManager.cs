//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using System.Collections;

public class MenuNavigationManager : MonoBehaviour {


	void Update(){
		if (Application.loadedLevelName.Equals ("MainMenu") && 
			(Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) {
			ViewConceptsMenu ();
		}
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void ViewConceptsMenu(){
		Application.LoadLevel ("ConceptSelection");
	}

	public void ToLoopLevels(){
		Application.LoadLevel ("ForLevelSelection");
	}

	public void ToConditionalLevels(){
		Application.LoadLevel("ConditionalsLevelSelection");
	}

	public void ToIOLevel(){
		Application.LoadLevel ("IODirections");
	}

	public void ToMath(){
		Application.LoadLevel ("MathLevelSelection");
	}

	public void GoToConditionals1(){
		Application.LoadLevel ("Conditionals1");
	}

	public void GoToConditionals2(){
		Application.LoadLevel ("Conditionals2");
	}

	public void GoToConditionals3(){
		Application.LoadLevel ("Conditionals3");
	}

	public void GoToConditionals4(){
		Application.LoadLevel ("Conditionals4");
	}

	public void GoToConditionals5(){
		Application.LoadLevel ("Conditionals5");
	}

	public void GoToConditionals6(){
		Application.LoadLevel ("Conditionals6");
	}

	public void GoToLoops1(){
		Application.LoadLevel ("Loops1");
	}

	public void GoToLoops2(){
		Application.LoadLevel ("Loops2");
	}

	public void GoToLoops3(){
		Application.LoadLevel ("Loops3");
	}

	public void GoToLoops4(){
		Application.LoadLevel ("Loops4");
	}

	public void GoToLoops5(){
		Application.LoadLevel ("Loops5");
	}

	public void GoToLoops6(){
		Application.LoadLevel ("Loops6");
	}

	public void GoToLoops7(){
		Application.LoadLevel ("Loops7");
	}

	public void GoToLoops8(){
		Application.LoadLevel ("Loops8");
	}
		
	public void ToIODirections(){
		Application.LoadLevel ("IODirections");
	}

	public void ToAddition(){
		Application.LoadLevel ("Math1");
	}

	public void ToSubtraction(){
		Application.LoadLevel ("Math2");
	}

	public void ToMultiplication(){
		Application.LoadLevel ("Math3");
	}

	public void ToDivision(){
		Application.LoadLevel ("Math4");
	}

	public void ToModulus(){
		Application.LoadLevel ("Math5");
	}

	public void ToAlgebra(){
		Application.LoadLevel ("Math6");
	}

	public void BeginIO(){
		Application.LoadLevel ("IO1");
	}

}