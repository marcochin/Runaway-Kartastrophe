using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	private bool isHowToPlayOpen;
	public GameObject howToPlayDialog;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(!isHowToPlayOpen)
				quitGame();
			else
				closeHowToPlay();
		}
	}



	public void quitGame(){
		Application.Quit();
	}

	public void playGame(){
		Application.LoadLevel ("MainLevel");
	}

	public void openHowToPlay(){
		isHowToPlayOpen = true;
		howToPlayDialog.SetActive (true);
	}

	public void closeHowToPlay(){
		isHowToPlayOpen = false;
		howToPlayDialog.SetActive(false);
	}


}
