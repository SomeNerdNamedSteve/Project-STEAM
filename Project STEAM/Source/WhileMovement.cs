//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class WhileMovement : GeneralMovement {

	public static int score, bonus;
	public static string level;
	public static bool getsNumBonus, getsTimeBonus;

	public InputField userInput;
	public Rigidbody rb;
	public Transform startPosition;
	public Text output, pause, hint;



	private int convertedNum, forBonus, changedOutput;
	private float time, speed;
	private bool moving, paused;

	[HideInInspector]
	override public void Start (){
		hint.enabled = false;
		getsNumBonus = false;
		getsTimeBonus = false;
		time = 123456789;
		userInput.ActivateInputField ();
		level = Application.loadedLevelName;
		score = 0;
		speed = 1.5f;
		moving = false;
		paused = false;
		pause.enabled = false;
		rb = null;
	}

	[HideInInspector]
	override public void Update (){
		
		print (level);

		time -= Time.timeSinceLevelLoad;
		output.text = convertedNum.ToString ();

		if (rb != null) {
			transform.Translate (speed * Vector3.forward * Time.deltaTime);
		} else {
			output.text = "";
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			paused = !paused;
			print (paused);

			if (paused == true) {
				pause.enabled = true;
				Time.timeScale = 0;

			}
			if (paused == false) {
				pause.enabled = false;
				Time.timeScale = 1;
			}
		}

		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) {
			BeginMoving ();
		}

	}

	override public void BeginMoving(){
		userInput.enabled = false;
		try{
			convertedNum = int.Parse(userInput.text);
			if(convertedNum > 0 && convertedNum < 31){
				rb = GetComponent<Rigidbody> ();
				userInput.enabled = false;
				moving = true;
				forBonus = convertedNum;
				print(forBonus);
				output.text = (convertedNum > 0) ? convertedNum.ToString () : "";
			}else{
				throw new FormatException();
			}
		}catch(FormatException e){
			userInput.enabled = true;
		}

	}

	[HideInInspector]
	override public void OnTriggerEnter (Collider c){
		
		if (c.gameObject.tag.Equals ("WhileLogicGate")) {

			if (level.Equals ("Loops6")) {
				if (convertedNum <= 5) {
					transform.position = startPosition.position;
					convertedNum++;
				}
			}

			if (level.Equals ("Loops7")) {
				if (convertedNum >= 12) {
					transform.position = startPosition.position;
				}
			}

			if (level.Equals ("Loops8")) {
				if (convertedNum < 32) {
					transform.position = startPosition.position;
				}
			}
		}

		if (c.gameObject.tag.Equals ("WhileMathGate")) {

			if (level.Equals ("Loops7")) {
				convertedNum -= 3;
			}

			if (level.Equals ("Loops8")) {
				convertedNum *= 2;
			}

		}

		if (c.gameObject.tag.Equals ("WinZone")) {
			score = (Mathf.FloorToInt(time))/17;
			CheckForBonus ();
			LevelCompleteScore.prevLevel = level;
			Application.LoadLevel ("LevelComplete");
		}
	}

	[HideInInspector]
	override public void CheckForBonus (){

		if (level.Equals ("Loops6")) {
		
			bonus = 1000;
			getsNumBonus = true;

		} else if (level.Equals ("Loops7")) {

			if (convertedNum % 2 == 1) {
				bonus = 2000;
				getsNumBonus = true;
			}
			
		} else if (level.Equals ("Loops8")) {

			if (forBonus == 1 || forBonus == 2 || forBonus == 4 || forBonus == 8 || forBonus == 16) {
				bonus = 3000;
				getsNumBonus = true;
			}
		
		}
		if(Time.timeSinceLevelLoad < 120){
			getsTimeBonus = true;
		}
	}
}