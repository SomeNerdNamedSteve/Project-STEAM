//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class ForMovement : GeneralMovement {

	public static bool getsNumBonus, getsTimeBonus;
	public static string level;
	public static float time;
	public static int bonus, score;
	public Text output, counterText, hintText, pause, changedOutput;
	public InputField userInput;
	public Transform pos1, pos2, pos3, pos4;
	public Transform playerBottom;
	public TextMesh gateText;
	public GameObject player;
	public Rigidbody rb;

	private string level4Word, level5Word, level6Word;
	private Transform[] turnPositions;
	private string inputStr;
	private bool moving;
	private int convertedNum;
	private int iterate;
	private int forBonus;
	private Vector3 direction;
	private float speed;
	private bool paused;
	private int sum;
	private char[] word = null;
	private string str;
	private StringBuilder sb;
	private char temp;

	// Use this for initialization
	[HideInInspector]
	override public void Start () {
		getsNumBonus = false;
		getsTimeBonus = false;
		sb = new StringBuilder ();
		level = Application.loadedLevelName;
		sum = (Application.loadedLevelName.Equals("Loops3")) ? 1 : 0;
		getsTimeBonus = false;
		time = 123456789;
		transform.position = pos1.position;
		paused = false;
		pause.enabled = false;
		speed = 6;
		direction = Vector3.forward;
		rb = null;
		hintText.enabled = false;
		userInput.ActivateInputField ();
		moving = false;
		turnPositions = new Transform[4];
		turnPositions [0] = pos1;
		turnPositions [1] = pos2;
		turnPositions [2] = pos3;
		turnPositions [3] = pos4;
		level4Word = "MOSI";
		level5Word = "computers";
		str = "";

		if (level.Equals ("Loops4")) {
			word = new char[level4Word.Length];
			for (int i = 0; i < word.Length; i++) {
				word[i] = level4Word[i];
			}
		}
		else if (level.Equals ("Loops5")) {
			word = level5Word.ToCharArray();
			changedOutput.text = level5Word;
		}

	}

	// Update is called once per frame
	[HideInInspector]
	override public void Update () {

		time -= Time.deltaTime;

		if (!moving) {
			rb = null;
		}

		foreach (Transform t in turnPositions) {
			float dist = Vector3.Distance (playerBottom.position, t.position);
			if (dist < 0.35f) {
				if (t.Equals (pos1)) {
					direction = Vector3.forward;
					print (t);
				}
				if (t.Equals (pos2)) {
					direction = Vector3.left;
					print (t);
				}
				if (t.Equals (pos3)) {
					direction = Vector3.back;
					print (t);
				}
				if (t.Equals (pos4)) {
					direction = Vector3.right;
					print (t);
				}
				transform.Translate (speed * direction * Time.deltaTime);
			}
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

		if (rb != null) {
			transform.Translate (speed * direction * Time.deltaTime);
		}
		if (iterate > 0 && iterate == convertedNum) {
			pos2 = null;
		}

		if ((Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) && rb == null) {
			BeginMoving ();
		}

	}

	override public void BeginMoving(){
		try{
			convertedNum = int.Parse(userInput.text);
			if(convertedNum > 0 && convertedNum < 31){
				iterate = 0;
				rb = GetComponent<Rigidbody> ();
				userInput.enabled = false;
				moving = true;
				forBonus = convertedNum;
				print(forBonus);
				gateText.text = "Looping " + convertedNum + " times.";
				output.text = (convertedNum > 0) ? convertedNum.ToString () : "";
			}else{
				throw new FormatException();
			}
		}catch(FormatException e){}

	}

	[HideInInspector]
	override public void OnTriggerEnter(Collider c){
		if (c.gameObject.tag.Equals ("GateCounter")) {

			if (level.Equals ("Loops4") && iterate == convertedNum){
				TryAgain.levelName = level;
				Application.LoadLevel ("TryAgain");
			}

			iterate++;
			counterText.text = iterate.ToString ();
		}

		if (c.gameObject.tag.Equals ("MathGate") || c.gameObject.tag.Equals("WordGate")) {

			if (c.gameObject.tag.Equals ("WordGate"))
			{

				if (level.Equals ("Loops5") && iterate >= word.Length) {
					TryAgain.levelName = level;
					Application.LoadLevel ("TryAgain");
				}

				if (str.Equals(level4Word)) {
					TryAgain.levelName = level;
					Application.LoadLevel ("TryAgain");
				}

			}

			ChangeGateBehaviour ();
		}

		if (c.gameObject.tag.Equals ("WinZone")) {
			if(level.Equals("Loops4") && !str.Equals(level4Word)){
				TryAgain.levelName = level;
				Application.LoadLevel("TryAgain");	
			}else{
				score = (Mathf.FloorToInt(time))/17;
				CheckForBonus();
				LevelCompleteScore.prevLevel = level;
				Application.LoadLevel ("LevelComplete");
			}

			if (level.Equals ("Loops5") && iterate >= level5Word.Length){
				Application.LoadLevel ("TryAgain");
			}

		}
	}

	[HideInInspector]
	public void ChangeGateBehaviour (){

		if (level.Equals ("Loops2")) {
			sum += iterate;
			changedOutput.text = sum.ToString ();
		}
		if (level.Equals ("Loops3")) {
			sum *= iterate;
			changedOutput.text = sum.ToString ();
		}
		if (level.Equals ("Loops4")) {
			for (int i = 0; i < level4Word.Length; i++) {
				if(i == iterate){
					str = str + level4Word[i].ToString();	
				}
			}
			changedOutput.text = str;
		}
		if (level.Equals ("Loops5")) {

			for (int i = 0; i < convertedNum; i++) {
				if (i == iterate) {
					int j = iterate % convertedNum;
					temp = word [j];
					word [j] = word [word.Length-j-1];
					word [word.Length-j-1] = temp;
				}
			}
			print (word);
			changedOutput.text = new string(word);
		}
	}

	[HideInInspector]
	override public void CheckForBonus(){
		if (level.Equals ("Loops1")) {
			bonus = 1000;
			getsNumBonus = true;
		}else if (level.Equals ("Loops2")) {
			if (sum % 2 == 1) {
				bonus = 2000;
				getsNumBonus = true;
			}
		}else if (level.Equals ("Loops3")) {
			if (sum > 10000) {
				bonus = 3000;
				getsNumBonus = true;
			}
		}else if (level.Equals ("Loops4")) {
			if (convertedNum == 4) {
				bonus = 3000;
				getsNumBonus = true;
			}
		}else if (level.Equals ("Loops5")) {

			if (changedOutput.text.Equals ("sretupmoc")) {
				bonus = 4000;
				getsNumBonus = true;
			}
			
		}

		if (Time.timeSinceLevelLoad < 120) {
			getsTimeBonus = true;
		}
	}
}