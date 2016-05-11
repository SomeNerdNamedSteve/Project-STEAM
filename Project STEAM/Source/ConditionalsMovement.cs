//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class ConditionalsMovement : GeneralMovement {

	public static int bonus, score;
	public static float time;
	public static string level;
	public static bool getsNumBonus, getsTimeBonus;
	public Text output, changedOutput, pause, hintText;
	public Transform portal1, portal2, portal3;
	public Transform playerStart;
	public InputField userInput;
	public Rigidbody rb;

	private bool paused;
	private int convertedNum, forBonus, sum;
	private bool moving;
	private float speed;
	private Vector3 portal1Pos, portal2Pos, portal3Pos;

	[HideInInspector]
	override public void Start (){
		getsNumBonus = false;
		getsTimeBonus = false;
		portal1Pos = new Vector3 (portal1.position.x, portal1.position.y + 0.5f, portal1.position.z);
		portal2Pos = new Vector3 (portal2.position.x, portal2.position.y + 0.5f, portal2.position.z);
		portal3Pos = new Vector3 (portal3.position.x, portal3.position.y + 0.5f, portal3.position.z);
		time = 123456789;
		sum = 0;
		paused = false;
		hintText.enabled = false;
		speed = 1.5f;
		pause.enabled = false;
		userInput.ActivateInputField ();
		paused = false;
		moving = false;
		rb = null;
		level = Application.loadedLevelName;
	}

	[HideInInspector]
	override public void Update (){

		time -= Time.deltaTime;

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

		if (rb != null) {
			transform.Translate (speed * Vector3.forward * Time.deltaTime);
		}

		if ((Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) && rb == null) {
			BeginMoving ();
		}

	}

	override public void BeginMoving(){
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
		}catch(FormatException e){}

	}

	[HideInInspector]
	override public void OnTriggerEnter (Collider c){

		if (c.gameObject.tag.Equals ("WinZone")) {
			score = (Mathf.FloorToInt(time))/17;
			CheckForBonus ();
			LevelCompleteScore.prevLevel = level;
			Application.LoadLevel ("LevelComplete");
		}

		if (c.gameObject.tag.Equals ("GameOver")) {
			TryAgain.levelName = level;
			Application.LoadLevel ("TryAgain");
		}

		if (c.gameObject.tag.Equals ("Level1LogicGate")) {
			if (convertedNum >= 2) {
				transform.position = portal1Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level2LogicGate")) {
			if (!(convertedNum < 10)) {
				transform.position = portal1Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level3LogicGate")) {
			if (!(convertedNum < 7)) {
				transform.position = portal1Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level4LogicGate1")) {
			if (!(convertedNum < 10)) {
				transform.position = portal2Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level4LogicGate2")) {
			if (convertedNum <= 5) {
				transform.position = portal1Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level5LogicGate1")) {
			if (!(convertedNum > 10)) {
				transform.position = portal2Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level5LogicGate2")) {
			if (convertedNum != 4) {
				transform.position = portal1Pos;
			}
		}
			

		if (c.gameObject.tag.Equals ("Level6LogicGate1")) {
			if (!(convertedNum < 15)) {
				transform.position = portal1Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level6LogicGate2")) {
			if (!(convertedNum > 20)) {
				transform.position = portal2Pos;
			}
		}

		if (c.gameObject.tag.Equals ("Level6LogicGate3")) {
			if (convertedNum <= 9) {
				transform.position = portal3Pos;
			}
		}
			
		if (c.gameObject.tag.Equals ("Level2MathGate")) {
			convertedNum += 5;
		}

		if (c.gameObject.tag.Equals ("Level3MathGate")) {
			convertedNum /= 3;
		}
			
		if (c.gameObject.tag.Equals ("Level5MathGate1")) {
			convertedNum *= 3;
		}

		if (c.gameObject.tag.Equals ("Level5MathGate2")) {
			convertedNum -= 5;
		}

		if (c.gameObject.tag.Equals ("Level6MathGate1")) {
			convertedNum += 7;
		}

		if (c.gameObject.tag.Equals ("Level6MathGate2")) {
			convertedNum /= 2;
		}

		output.text = convertedNum.ToString ();

	}

	[HideInInspector]
	override public void CheckForBonus (){

		if (level.Equals ("Conditionals1")) {
			bonus = 1000;
			getsNumBonus = true;
		}else if (level.Equals ("Conditionals2") && forBonus == 2) {
			bonus = 2000;
			getsNumBonus = true;
		}else if (level.Equals ("Conditionals3") && forBonus % 3 == 0) {
			bonus = 3000;
			getsNumBonus = true;
		}else if (level.Equals ("Conditionals4")  && forBonus == 9) {
			bonus = 4000;
			getsNumBonus = true;
		}else if (level.Equals ("Conditionals5") && forBonus == 2) {
			bonus = 5000;
			getsNumBonus = true;
		}else if (level.Equals ("Conditionals6") && forBonus == 17) {
			bonus = 6000;
			getsNumBonus = true;
		}

		if (Time.timeSinceLevelLoad < 120) {
			getsTimeBonus = true;
		}
	}
}