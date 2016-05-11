
//Programmer: Steven Burgess
//Project: Project: STEAM

//these are known as library imports
//These are to show which 
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;


//this begins the movement and everything in the math class
/*
 * For this class,
 * The name is MathMovement, the same as the file
 * the ":" is a symbol meaning that this class is taking from whatever class name is on the right
 * In this case, it is taking from GeneralMovement
 * And if you look at GeneralMovement, you will see it takes from MonoBehaviour
 * MonoBehaviour allows this script to work with unity along with the library imports from above
 * So by default, this script also accesses MonoBehaviour.
*/
public class MathMovement : GeneralMovement {


	//petting public variables to be used and set in the Unity Editor
	public static int numRetries;
	public Rigidbody rb;
	public Text pause, mathProblem;
	public InputField userInput;
	public Transform start, end;
	public Transform moveForward;
	public Transform startPosition;


	//private variables that are only going to be used in the class,
	//and nothing else needs to access them
	private bool paused;
	private Vector3 nextLevel;

	//Addition arrays for level1
	private string [] add = new string[]{"3+14","3+2","3+5","3+12","3+17","3+24","3+26","3+25","3+19","3+16",
										"15+8","15+15","15+7","15+3","15+6","15+2","15+9","15+1","15+12","15+4",
										"12+7","12+6","12+12","12+8","12+4","12+10","12+17","12+9","12+13","12+2",
										"6+4","6+6","6+18","6+1","6+9","6+12","6+24","6+19","6+15","6+7",
										"10+15","10+20","10+2","10+7","10+10","10+3","10+19","10+16","10+4","10+14",
										"17+12","17+5","17+8","17+3","17+11","17+4","17+2","17+6","17+9","17+1",
										"5+6","5+5","5+13","5+1","5+14","5+23","5+21","5+18","5+2","5+3",
										"13+13","13+6","13+8","13+3","13+7","13+4","13+16","13+9","13+2","13+5",
										"2+2","2+3","2+1","2+6","2+18","2+5","2+9","2+8","2+16","2+25",
										"8+3","8+5","8+9","8+1","8+21","8+18","8+8","8+4","8+14","8+10",};	
	private int[] addAnswer = new int[]{17,5,8,15,20,27,29,28,22,19,
										23,30,22,18,21,17,24,16,27,19,
										19,18,24,20,16,22,29,21,25,14,
										10,12,24,7,15,18,30,25,21,13,
										25,30,12,17,20,13,29,26,14,24,
										29,22,25,20,28,21,19,23,28,18,
										11,10,18,6,19,28,26,23,7,8,
										26,19,21,16,20,17,29,22,15,18,
										4,5,3,8,20,7,11,10,18,27,
										11,13,17,9,29,26,16,12,22,18};



	//Subtraction arrays for level2
	private string[] subtract = new string[]{"24-4","24-15","24-5","24-7","24-20","24-10","24-16","24-8","24-23","24-0",
											"18-17","18-5","18-15","18-14","18-3","18-4","18-10","18-6","18-16","18-1",
											"50-20","50-30","50-29","50-40","50-46","50-28","50-32","50-36","50-45","50-24",
											"100-99","100-75","100-83","100-82","100-92","100-86","100-72","100-78","100-95","100-76",
											"23-12","23-15","23-22","23-4","23-14","23-3","23-21","23-5","23-16","23-7",
											"42-16","42-12","42-15","42-30","42-40","42-37","42-18","42-24","42-19","42-26",
											"82-63","47-19","8-6","4-3","16-5","48-40","12-9","63-36","82-69","16-8",
											"30-18","30-12","30-5","30-9","6-5","6-3","4-1","10-8","3-2","17-5",
											"17-12","19-12","14-3","14-10","14-8","14-6","14-7","14-13","14-12","14-1",
											"47-36","47-18","52-40","68-60","50-27","27-18","19-18","76-52","49-32","56-40"};
	private int[] subtractAnswer = new int[]{20,9,19,17,4,14,8,16,1,24,
											1,13,3,4,15,14,8,12,2,17,
											30,50,21,10,4,22,18,14,5,26,
											1,25,17,18,8,14,28,22,5,24,
											11,8,1,19,9,20,2,18,7,16,
											26,30,27,12,2,5,25,18,23,16,
											19,28,2,1,11,8,3,27,13,8,
											12,18,25,21,1,3,3,2,1,12,
											5,7,11,4,6,8,7,1,13,
											9,29,12,8,23,9,1,24,17,16};
		
	//multiplication arrays for level3
	private string[] multiply = new string[]{"15*1","15*2","14*1","14*2","13*1","13*2","12*1","12*2","11*1","11*2",
											"10*1","10*2","10*3","9*1","9*2","9*3","8*1","8*2","8*3","7*1",
											"7*2","7*3","7*4","6*1","6*2","6*3","6*4","6*5","5*1","5*2",
											"5*3","5*4","5*5","5*6","4*1","4*2","4*3","4*4","4*5","4*6",
											"4*7","3*1","3*2","3*3","3*4","3*5","3*6","3*7","3*8","3*9",
											"3*10","2*1","2*2","2*3","2*4","2*5","2*6","2*7","2*8","2*9",
											"2*10","2*11","2*12","2*13","2*14","2*15","1*30","1*29","1*28","1*27",
											"1*26","1*25","1*24","1*23","1*22","1*21","1*20","1*19","1*18","1*17",
											"1*16","1*15","1*14","1*13","1*12","1*11","1*10","1*9","1*8","1*7",
											"1*6","1*5","1*4","1*3","1*2","1*1","16*1","23*1","25*1","18*1"};
	private int[] multiplyAnswer = new int[]{15,30,14,28,13,26,12,24,11,22,
											10,20,30,9,18,27,8,16,24,7,
											14,24,28,6,12,18,24,30,5,10,
											15,20,25,30,4,8,12,16,20,24,
											28,3,6,9,12,15,18,21,24,27,
											30,2,4,6,8,10,12,14,16,18,
											20,22,24,26,28,30,30,29,28,27,
											26,25,24,23,22,21,20,19,18,17,
											16,15,14,13,12,11,10,9,8,7,
											6,5,4,3,2,1,16,123,25,18};

	//Division arrays for level 4
	private string[] divide = new string[]{"60/2","60/10","60/60","60/20","60/30",
		"90/30","90/10","90/15","90/5","90/45",
		"100/5","100/20","100/100","100/25","100/10",
		"80/40","80/20","80/8","80/10","80/4",
		"20/4","20/5","20/2","20/10","20/1",
		"40/8","40/5","40/10","40/4","40/2",
		"63/21","63/63","63/9","63/7","21/3",
		"21/7","15/1","15/5","15/3","15/15",
		"8/4","8/2","8/8","8/1","18/18",
		"18/1","18/9","18/2","18/6","18/3",
		"32/16","32/8","32/4","32/2","32/32",
		"9/9","9/3","9/1","17/17","23/1",
		"25/5","25/1","25/25","65/5","25/1",
		"250/250","250/10","250/25","250/125","250/50",
		"22/11","22/22","22/1","22/2","7/1",
		"24/6","24/4","24/2","24/12","24/24",
		"42/6","42/7","42/21","42/42","3/3",
		"50/5","50/10","50/25","50/50","51/3",
		"64/8","64/64","64/32","64/16","64/4",
		"35/35","35/7","35/5","70/5","67/67",};
	private int[] divideAnswer =  new int[]{30,6,1,3,2,
		3,9,6,18,2,
		20,5,1,4,10,
		2,4,10,8,20,
		5,4,10,2,20,
		5,8,4,10,20,
		3,1,7,9,7,
		3,15,3,5,1,
		2,4,1,8,1,
		18,2,9,3,6,
		2,4,8,16,1,
		1,3,9,1,23,
		5,25,1,13,25,
		1,25,10,2,5,
		2,1,22,11,7,
		4,6,12,2,1,
		7,6,2,1,1,
		10,5,2,1,17,
		8,1,2,4,16,
		1,5,7,14,1};

	//modulus array for level 5
	private string[] modulus = new string[]{"65%3","4%3","2%3","98%3","8%3","64%3","88%3","47%3","59%3","23%3",
											"123%5","41%5","96%5","74%5","4%5","21%5","59%5","547%5","122%5","63%5",
											"17%10","951%10","66%10","1982%10","47%10","12%10","9%10","58%10","27%10","43%10",
											"65%20","75%20","82%20","13%20","8%20","159%20","852%20","654%20","102%20","542%20",
											"26%25","24%25","47%25","122%25","67%25","36%25","42%25","321%25","998%25","55%25",
											"84%30","64%30","189%30","315%30","75%30","486%30","47%30","29%30","16%30","97%30",
											"41%40","58%40","75%40","32%40","19%40","62%40","79%40","42%40","56%40","82%40",
											"56%50","31%50","25%50","414%50","615%50","645%50","648%50","894%50","164%50","895%50",
											"15%75","84%75","110%75","61%75","83%75","76%75","157%75","170%75","98%75","178%75",
											"175%100","654%100","1684%100","6546%100","64%100","1994%100","1985%100","8143%100","1284%100","4982%100",};	
	private int[] modulusAnswer = new int[]{2,1,2,2,2,1,1,2,2,2,
											3,1,1,4,4,1,4,2,2,3,
											7,1,6,2,7,2,7,8,7,3,
											5,15,2,13,8,19,12,14,2,2,
											1,24,22,22,17,11,17,21,23,5,
											24,4,9,15,15,6,17,29,16,7,
											1,18,35,32,19,22,39,2,16,2,
											6,31,25,14,15,45,48,44,14,45,
											15,9,35,61,8,1,7,20,23,28,
											75,54,84,46,64,94,85,43,84,82};

	//algebraic equations for level6
	private string[] algebra = new string[]{"x+10=27","x+4=5","x-3=15","x+12=21","11+x=39","x+2=4","6+x=10","x+19=22","x+5=17","6+x=30",
									  		"x+5=11","x+11=28","13+x=16","2+x=6","9+x=11","15=x+7","10+x=25","x+6=12","14+x=32","16+x=25",
											"x-3=2","x-2=9","9-x=0","42-x=36","x-7=3","16-x=4","x-24=62","99-x=25","84-x=-7","42-x=-4",
											"12-x=2*3","x-62=14+9","125-x=70-5","5+8=56-x","7-6=42-x","100-x=9*7","14*5=90-x","16*2=40-x","52-12=60-x","98-90=x-3",
											"6x=36","2*x=32","19=19*x","45=x*3","62=x*2","81=x*9","45=x*9","10x=40","50=x*2","600=10*x",
											"14x=6*7","15*4=2*x","x*9=3*3*3","5*4=2*x","14*8=x*4","58*2=x*4","95-5=15*x","6*5=x*3","78*1=13*x","56*2=x*4",
											"25/x=5","x/12=7","42/x=7","16/x=8","900/x=90","x/13=3","x/23=4","16/x=4","23/x=1","58/x=58",
											"18/x=2*3","19+2=x/2","15/x=10/2","12-5=49/x","x/12=3*2","87-80=x/2","15+7=x/2","52-2=250/x","6*5=60/x","31-5=78/x",
											"(x/4)+2=6","-6+(x/4)=-5","-4=(x/20)-5","3x+6=4x+1","(x+9)/3=8","-9x+1=-80","-6=(x/2)-10","-15=4x+5","10-6x=-104","8x+7=31",
											"-9x-13=-103","-10=10(x-9)","(x+5)/-16=-1","7(9+k)=84","8+(b/-4)=5","-243=-9(10+x)","-8(3-x)=32","(x/-3)-11=-20","8x=10x-36","x/3=x-2"};
	private int[] algebraAnswer = new int[]{17,1,18,9,28,2,4,3,12,24,
											6,17,3,4,2,8,15,6,18,9,
											5,11,9,6,10,12,86,74,91,46,
											6,85,60,43,41,37,20,8,20,11,
											6,16,1,15,31,9,5,4,25,6,
											3,30,3,10,28,29,6,10,6,28,
											5,84,6,2,10,39,92,4,23,1,
											3,42,3,7,72,40,44,5,2,3,
											16,4,20,5,15,9,8,5,19,3,
											10,8,11,3,12,17,7,27,18,3};

	//making more variables to be used in the file
	private string[] questions;
	private int[] answers;
	private string level;
	private int convertedNum;
	private static float force = 430;
	private bool l1Return, l2Return, l3Return, l4Return, l5Return, l6Return;
	private Vector3 jumpDir = new Vector3(0,force * 1.2f, force); /*every Vector3 has an x(left, right) 
																						a y(up and down), 
																						and a z(forward and back)*/

	// Use this for initialization
	[HideInInspector]//this hides the function from the Unity Editor

	/*
	 * A note on the words here:
	 * Override: In the GeneralMovement class this file inherits from, there is a word "abstract"
	 * "abstract" just means that there is nothing to say for the functions in the file
	 * override takes that function heading and puts stuff in it specifically for this class
	 * public: it can be seen by other classes if need be.  Also in Unity, it is a good practice to make the
	 * methods that are specific to MonoBehaviour(Start, Update, FixedUpdate, OnCollisionEnter, etc) to use public.
	 * Only use private for what you only want to manipulate
	 * void: it doesn't return any specific values and just performs an action
	*/
	override public void Start () {
		//in the start function, I am declaring variables to everything as needed
		numRetries = 0;
		mathProblem.text = "";
		l1Return = false;
		l2Return = false;
		l3Return = false;
		l4Return = false;
		l5Return = false;
		userInput.ActivateInputField ();//this activates a user input text field
		level = Application.loadedLevelName;//this gets the name of the level currently loaded
		rb = GetComponent<Rigidbody> ();//this get the components of the RigidBody class
		paused = false;
		pause.enabled = false;
	}
	
	// Update is called once per frame
	[HideInInspector]
	//this function will update once per frame
	//e.g: if there are 60 frames per second for this game
	//this function is called 60 times in 1 second
	override public void Update () {


		//this series of if statements will set the questions and answers array equal to
		//the level (so addition's level has the addition arrays, subtraction has subtraction, and so on)
		if(level.Equals("Math1")){
			questions = add;
			answers = addAnswer;
		}

		if(level.Equals("Math2")){
			questions = subtract;
			answers = subtractAnswer;
		}

		if(level.Equals("Math3")){
			questions = multiply;
			answers = multiplyAnswer;
		}

		if(level.Equals("Math4")){
			questions = divide;
			answers = divideAnswer;
		}

		if(level.Equals("Math5")){
			questions = modulus;
			answers = modulusAnswer;
		}

		if(level.Equals("Math6")){
			questions = algebra;
			answers = algebraAnswer;
		}

		//this indicates a pause function to see if the user pressed escape to pause
		if(Input.GetKeyDown(KeyCode.Escape)){
			paused = !paused;//if they did, the pause is changed

			//if paused is true, then the game is paused
			//and there is text showing that the game is paused
			if (paused == true) {
				pause.enabled = true;
				Time.timeScale = 0;
			}

			//if paused is false, then the game is played as normal
			if (paused == false) {
				pause.enabled = false;
				Time.timeScale = 1;
			}
		}

		//if the user pressed enter on the keyboard
		//then the user will be able to use this just like the compile button
		if (Input.GetKeyUp (KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter)) {
			BeginMoving ();
		}
	}

	[HideInInspector]

	//this checks all and any collisions
	override public void OnTriggerEnter(Collider c){

		//if the player hits the red and green area below
		if (c.gameObject.tag.Equals ("BackToStart")) {

			//the number of retries goes up by 1
			//and the respective boolean values goes from false to true
			numRetries++;
			if (level.Equals ("Math1")) {
				l1Return = true;
			} else if (level.Equals ("Math2")) {
				l2Return = true;
			} else if (level.Equals ("Math3")) {
				l3Return = true;
			} else if (level.Equals ("Math4")) {
				l4Return = true;
			} else if (level.Equals ("Math5")) {
				l5Return = true;
			} else if (level.Equals ("Math6")) {
				l6Return = true;
			}
			//and finally the player goes back to the start of the level
			transform.position = startPosition.position;
		}


		//if the player lands on the space to end the level
		//the code checks for the bonus and goes to a new level
		if (c.gameObject.tag.Equals ("EndOfLevel")) {
			CheckForBonus();
			LevelCompleteScore.prevLevel = level;
			Application.LoadLevel ("LevelComplete");
		}
	}


	//This function check for general collisions
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag.Equals ("Platform")) {//If the gameObject the player hits is labeled as a platform

			//move to this position
			Transform temp = c.gameObject.transform;

			//just in case 
			if (transform.position.z != temp.position.z) {
				Vector3 moveToHere = new Vector3 (temp.position.x, transform.position.y, temp.position.z);
				transform.position = moveToHere;
			}

			ShowQuestion ();
			userInput.ActivateInputField ();
		}
	}


	//here the player will be able to move based on input
	override public void BeginMoving(){

		try{
			//the number is converted from a String to an Integer
			convertedNum = int.Parse(userInput.text);
			//if the number is between 1 and 100
			if(convertedNum > 0 && convertedNum < 101){
				//the code will check for a correct answer
				CheckForCorrectAnswer();
			}else{
				//otherwise, an exception is thrown
				throw new FormatException();
			}
		}catch(FormatException e){/*Nothing happening here if the number is not between 1 and 100,
									but later in the code, the player will have their text box reset*/}
	
	}

	[HideInInspector]
	//this function checks for bonuses
	override public void CheckForBonus(){

		//this series of if statements checks to see what level it is
		if (level.Equals ("Math1")) {
			if (!l1Return) {
				MathLevelScoreManager.level1Perfect = true;//if the boolean value is false, 
															//the player did the level perfectly
			} else {
				MathLevelScoreManager.level1Perfect = false;//otherwise, they did not
			}
		} else if (level.Equals ("Math2")) {
			if (!l2Return) {
				MathLevelScoreManager.level2Perfect = true;
			} else {
				MathLevelScoreManager.level2Perfect = false;
			}
		} else if (level.Equals ("Math3")) {
			if (!l3Return) {
				MathLevelScoreManager.level3Perfect = true;
			} else {
				MathLevelScoreManager.level3Perfect = false;
			}
		} else if (level.Equals ("Math4")) {
			if (!l4Return) {
				MathLevelScoreManager.level4Perfect = true;
			} else {
				MathLevelScoreManager.level4Perfect = false;
			}
		} else if (level.Equals ("Math5")) {
			if (!l5Return) {
				MathLevelScoreManager.level5Perfect = true;
			} else {
				MathLevelScoreManager.level5Perfect = false;
			}
		} else if (level.Equals ("Math6")) {
			if (!l6Return) {
				MathLevelScoreManager.level6Perfect = true;
			} else {
				MathLevelScoreManager.level6Perfect = false;
			}
		}
	}

	//this function looks for the correct answer when the user
	//inputs a number
	void CheckForCorrectAnswer(){
		int i;
		//checks the array of questions to find out which question was given
		for (i = 0; i < questions.Length; i++) {
			if (mathProblem.text.Equals (questions[i])){

				//if the answer given is the one correlated with the question
				if(convertedNum == answers[i]){
					//jump to the next block
					rb.AddForce (jumpDir);
				}else{

					//otherwise, check to see if the answer is larger or smaller
					if (convertedNum > answers [i]) {
						rb.AddForce (jumpDir * 1.25f);//if it is larger, overshoot the platform
					} else {
						rb.AddForce (jumpDir * 0.75f);//if it is smaller, undershoot the platform
					}
				}
				mathProblem.text = "";//reset the text field
			}
		}
		
	}


	//this function shows a new question every time on call
	void ShowQuestion(){
		int currQuestion = UnityEngine.Random.Range (0, questions.Length - 1);
		mathProblem.text = questions [currQuestion];
	}
}