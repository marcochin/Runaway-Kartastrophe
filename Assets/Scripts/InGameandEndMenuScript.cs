using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameandEndMenuScript : MonoBehaviour {
	public static InGameandEndMenuScript current;

	public GameObject inGameMenuDialog, endGameMenuDialog, howToPlayDialog;
	public GameObject go321;
	public GameObject bobby;

	public GameObject yourScore, highScore, endGameYourScore, endGameHighScore;	
	private Text yourScoreText, highScoreText, endGameYourScoreText, endGameHighScoreText;
	private SpriteRenderer go321SpriteRenderer;


	public GameObject[] uiDisable;
	public GameObject menuButtonDisable;
	//public GameObject gameControlCanvas;

	private Stack dialogBackStack;


	void Awake(){
		current = this;
		dialogBackStack = new Stack ();
		yourScoreText = yourScore.GetComponent<Text> ();
		highScoreText = highScore.GetComponent<Text> ();
		endGameYourScoreText = endGameYourScore.GetComponent<Text> ();
		endGameHighScoreText = endGameHighScore.GetComponent<Text> ();

		go321SpriteRenderer = go321.GetComponent<SpriteRenderer> ();

		//load highScore on Awake
		highScoreText.text = "HighScore: " + HighScoreLoaderSaver.current.loadHighScore ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(dialogBackStack.Count == 0){ //if no dialog
				quitGame();
			}
			else{ //if there is a dialog popup
				GameObject pop = (GameObject)dialogBackStack.Pop();
				pop.SetActive(false);
				if(dialogBackStack.Count == 0){ //unpause if go back to the game
					unpause();
				}
			}
		}
	}

	public void openInGameMenu(){

		if (dialogBackStack.Count == 0) {
			dialogBackStack.Push (inGameMenuDialog);
			inGameMenuDialog.SetActive (true);

			//disable ui
			foreach(GameObject go in uiDisable){
				go.SetActive(false);
			}

			//makes the go321 countdown move to background
			go321SpriteRenderer.sortingOrder = -1;

			yourScoreText.text = "Your Score: " + ScoreAndSpeedScript.getScore();

			//pause game
			Time.timeScale = 0;



		} else{
			closeInGameMenu();
		}
	}

	public void closeInGameMenu(){
		dialogBackStack.Pop();
		inGameMenuDialog.SetActive (false);
		//unpause game
		unpause ();
	}

	public void openEndGameMenu(){
		int highScore;

		//disable ui
		foreach(GameObject go in uiDisable){
			go.SetActive(false);
		}

		//check if score is high score
		highScore = HighScoreLoaderSaver.current.loadHighScore ();
		if (highScore < ScoreAndSpeedScript.getScore ()) {
			HighScoreLoaderSaver.current.saveHighScore();
			highScore = ScoreAndSpeedScript.getScore (); //ste highscore to new score
		}
		endGameHighScoreText.text = "High Score: " + highScore;
		endGameYourScoreText.text = "Your Score: " + ScoreAndSpeedScript.getScore();

		endGameMenuDialog.SetActive (true);

		//set menu button to false
		menuButtonDisable.SetActive (false);

		//set bobby to false, do not pause game
		bobby.SetActive (false);
	}

	public void openHowToPlay(){
		dialogBackStack.Push (howToPlayDialog);
		howToPlayDialog.SetActive (true);
	}
	
	public void closeHowToPlay(){
		dialogBackStack.Pop();
		howToPlayDialog.SetActive(false);
	}

	public void quitGame(){
		Application.Quit();
	}

	public void restartGame(){
		Time.timeScale = 1;
		
		Enemy5MoveScript.resetSpeed();
		EnemyMoveScript.resetSpeed();
		Application.LoadLevel("MainLevel"); //should display game over menu instead first
	}

	private void unpause(){
		foreach(GameObject go in uiDisable){
			go.SetActive(true);
		}
		go321SpriteRenderer.sortingOrder = 1;

		dialogBackStack.Clear();
		
		//unpause game
		Time.timeScale = 1;
	}

	public void loadMainMenu(){
		Time.timeScale = 1;

		Application.LoadLevel ("Menu");
	}
}
