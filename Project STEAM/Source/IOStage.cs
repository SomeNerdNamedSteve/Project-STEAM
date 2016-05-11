//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IOStage : MonoBehaviour {

	public static int score;
	public Text directions;
	public Toggle getData, giveData, showData;
	public Toggle intT, booleanT, stringT, charT, floatT;
	public Button compile;
	public Text scoreText, exceptionText;
	public Rigidbody2D sprite;
	public Transform start, otherStart;

	private Vector2 spriteDir;
	private string[] directionsArr;
	private int currStageIterator;
	private bool paused;
	private string[] currStageArr;
	private string currStage;
	private float speed;

	// Use this for initialization
	void Start () {
		exceptionText.enabled = false;
		sprite.GetComponentInParent<Transform> ().position = start.position;
		score = 0;
		directionsArr = new string[10] {
			"We need to display the message of the day!",
			"The iLab wants you to add up some numbers!",
			"Can Chase take a look at that sum?",
			"Sorry could you divide it over the week and send it back to the iLab?",
			"Psst, personal favor from the iLab: what's the answer to this multiple choice question?",
			"The iLab got some pretty big answers.  Can you look at them real quick?",
			"Hey Steven from the iLab wants to know if you're really talking bad about him!",
			"The iLab lost the server password.  What is it again?",
			"The iLab got some numbers, could you check them and tell us if they are right?",
			"I think we have something major!  Tell the world if we think it's true or not!"
		};
		currStageArr = new string[10]
			{"Part1", "Part2", "Part3", "Part4", "Part5", "Part6", "Part7", "Part8", "Part9", "Part10"};

		currStageIterator = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (score < 0) {
			score = 0;
		}
		scoreText.text = score.ToString ();
		if (sprite.transform.position.x == start.position.x) {
			directions.text = directionsArr [currStageIterator];
			currStage = currStageArr [currStageIterator];
		}

		if (speed > 0) {
			DisableUI ();

			if (sprite.transform.position.x > 10) {
				EnableUI ();
				sprite.transform.position = start.position;
				speed = 0;
				directions.text = directionsArr [currStageIterator];
			}

			if (sprite.transform.position.x < -10) {
				EnableUI ();
				sprite.transform.position = start.position;
				speed = 0;
				directions.text = directionsArr [currStageIterator];
			}

		}

		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) {
			CheckForCorrectAnswer ();
		}

		sprite.velocity = (spriteDir * speed * Time.deltaTime);
	}

	public void CheckForCorrectAnswer(){
		if (currStage.Equals (currStageArr [0])) { //level1
			if (showData.isOn && stringT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if(giveData.isOn && stringT.isOn){
				score += 500;
				UpdateStage ();
			} else {
				exceptionText.enabled = true;
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [1])) { //level2
			if (getData.isOn && floatT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if (getData.isOn && intT.isOn) {
				score += 500;
				UpdateStage ();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [2])) { //level3
			if (giveData.isOn && intT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if (giveData.isOn && intT.isOn) {
				score += 1000;
				UpdateStage ();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [3])) { //level4
			if (giveData.isOn && intT.isOn) {
				score += 1000;
				UpdateStage ();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [4])) { //level5
			if (giveData.isOn && charT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if (giveData.isOn && stringT.isOn) {
				score += 500;
				UpdateStage();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [5])) { //level6
			if (getData.isOn && intT.isOn) {
				score += 1000;
				UpdateStage ();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [6])) { //level7
			if (giveData.isOn && booleanT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if (giveData.isOn && stringT.isOn) {
				score += 500;
				UpdateStage();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [7])) { //level8
			if (giveData.isOn && stringT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if ((giveData.isOn && intT.isOn) || (giveData.isOn && floatT.isOn) || (giveData.isOn && charT.isOn)) {
				score += 500;
				UpdateStage();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [8])) { //level9
			if (giveData.isOn && booleanT.isOn) {
				score += 1000;
				UpdateStage ();
			} else if (giveData.isOn && stringT.isOn) {
				score += 500;
				UpdateStage();
			} else {
				score -= 20;
			}
		}else if (currStage.Equals (currStageArr [9])) { //level10
			if (showData.isOn && booleanT.isOn) {
				score += 1000;
				IOComplete.score = score;
				Application.LoadLevel ("IOComplete");
			} else if (showData.isOn && stringT.isOn) {
				score += 500;
				IOComplete.score = score;
				Application.LoadLevel ("IOComplete");
			} else {
				score -= 20;
			}
		}
	}

	public void UpdateStage(){
		exceptionText.enabled = false;
		CueSprite ();
		currStageIterator++;
		directions.text = directionsArr [currStageIterator];
		currStage = currStageArr [currStageIterator];
	}

	private void CueSprite(){

		if (getData.isOn) {
			sprite.transform.localScale = new Vector3 (-1, 1, 1);
			sprite.transform.position = otherStart.position;
			if (sprite.transform.position.x != -10) {
				spriteDir = Vector2.left;
				speed = 200;
			}
		} 

		if(giveData.isOn || showData.isOn){
			sprite.transform.localScale = new Vector3 (1, 1, 1);
			sprite.transform.position = start.position;
			if (sprite.transform.position.x != 10) {
				spriteDir = Vector2.right;
				speed = 200;
			}
		}

	}

	private void DisableUI(){
		directions.text = "";
		compile.enabled = false;
	}
		
	private void EnableUI(){
		directions.text = "";
		compile.enabled = true;
	}

}