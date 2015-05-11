using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CodeSpawner : MonoBehaviour {
	private int codeLength = 8;
	private int codeSpawnTime = 7; //approx realtime 10 seconds
	//private int codeSpawnInteval = 400;

	private List<GameObject> codeContainer = new List<GameObject> ();
	private Vector2[] codeSpawnPosition = new Vector2[11];

	public GameObject codeCountdown;

	public bool timerStart;
	private float countDownTime;	

	private int currentCode = 0;

	public static CodeSpawner currentCodeSpawner;

	private CodeSpawner (){
	}

	void Awake(){
		currentCodeSpawner = this;
	}

	void Start () {

		//I calculated all of these using world coordinates in the game
		//First Pos is 3.65, -5.92
		int codePosIndex = 0;

		//store the codeSpawnPositions
		float codePosX = -5.92f;
		float codePosY = 3.5f;

		for (int j = 0; j < 11; j++){
			codeSpawnPosition[codePosIndex] = new Vector2(codePosX, codePosY);
			codePosX += 1.0f;
			codePosIndex ++;
		}
	}

	void Update () {
		if(ScoreAndSpeedScript.getScore() >= codeSpawnTime && !timerStart){
			//new codeSpawnTime will be set when in clearCodeContainer
			//start timer for code
			timerStart = true;

			//spawn code in space
			for(int i = 0; i < codeLength; i++){
				int buttonCode = Random.Range (7, 13); //7-13 corrseponds to the poolNumbers in ObjectPoolingScript

				GameObject code = ObjectPoolerScript.current.GetPooledObject(buttonCode);
				codeContainer.Add(code);

				code.transform.position = codeSpawnPosition[i];
				code.SetActive(true);
			}

			codeCountdown.SetActive (true);

			StartCoroutine("failedToPass");
			//can only stop coroutines called with a string, so im calling it with a string instead.
		}
	}

	public bool isTimerStart(){
		return timerStart;
	}

	public int getCurrentCode(){
		return currentCode;
	}

	public int getCodeLength(){
		return codeLength;
	}

	private IEnumerator failedToPass(){
		yield return new WaitForSeconds(3.32f);
		clearCodeContainer ();
	}


	public string getCurrentCodeName(){
		//if he enters a code when everything is green w/o submitting via unlocking it will start all over LOL
		if (currentCode == codeLength) {
			resetCodeContainer();
			return null;
		}

		return codeContainer[currentCode].name;
	}

	public void advanceToNextCode(){
		//turn current code green
		codeContainer [currentCode].GetComponent<CodeSpriteSwap> ().setToGreenSprite ();

		currentCode++;
	}

	public void clearCodeContainer(){
		foreach (GameObject code in codeContainer){
			code.SetActive(false);
		}
		codeContainer.Clear();

		//set new time for code to spawn
		codeSpawnTime = ScoreAndSpeedScript.getScore () + Random.Range (4, 7); 
		//codeSpawnTime must be b4 timerStart
		timerStart = false;
		codeCountdown.SetActive (false);
		currentCode = 0;

		//new code length
		if (codeLength > 5) {
			codeLength --;
		}
	}

	public void resetCodeContainer(){ //for when he types in wrong code
		//change all back to the original sprite
		foreach (GameObject code in codeContainer) {
			code.GetComponent<CodeSpriteSwap> ().setToNormSprite ();
		}
		currentCode = 0;
	}

	public void stopFailedToPass(){
		StopCoroutine ("failedToPass");
	}

	public void resetCodeSpawnTime(){
		//set new time for code to spawn
		codeSpawnTime = ScoreAndSpeedScript.getScore () + Random.Range (4, 7); 
	}

	public void setTimerStart(bool timerStart){
		this.timerStart = timerStart;
	}

}
