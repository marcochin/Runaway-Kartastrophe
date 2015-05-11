using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BobbyHealth : MonoBehaviour {
	public static BobbyHealth current;

	private int health;

	public GameObject lives;
	private Text livesText;
	
	void Awake(){
		health = 3;
		current = this;
		
		livesText = lives.GetComponent<Text> ();
		livesText.text = "Lives: " + health.ToString ();
	}

	public void subtractOneHealth(){ //function dont need to be static if whole class is static...but whatever
		health --;
		livesText.text = "Lives: " + health.ToString ();

		//if he collides and health is 1 it is game over!
		if (health == 0) {
			//he dead mang
			InGameandEndMenuScript.current.openEndGameMenu();
		}
	}

	public int getHealth(){
		return health;
	}
	
	public void setHealth(int newHealth){
		health = newHealth;
		livesText.text = "Lives: " + health.ToString ();
	}


	
}
