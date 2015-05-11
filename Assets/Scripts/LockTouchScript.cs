using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LockTouchScript : MonoBehaviour {

	private Sprite lockButton;
	public Sprite unlockButton;
	private bool locked;

	private Image image;
	private Text text;

	public static LockTouchScript currentLockScript;

	// Use this for initialization
	void Awake () {
		image = GetComponent<Image> ();
		text = GetComponentInChildren<Text> ();
		lockButton = image.sprite;
		currentLockScript = this;
	}

	public bool isLocked(){
		return locked;
	}

	public void lockUnlock(){
		//swap between lock and unlcok sprite images

		if (!locked) {
			text.text = "UNLOCK";
			image.sprite = unlockButton;
			locked = true;
		} else {
			locked = false;
			text.text = "LOCK";
			image.sprite = lockButton;


			//submit the code by unlocking
			if(CodeSpawner.currentCodeSpawner.getCurrentCode() == CodeSpawner.currentCodeSpawner.getCodeLength()){
				CodeSpawner.currentCodeSpawner.clearCodeContainer();
				CodeSpawner.currentCodeSpawner.stopFailedToPass();
				//give him health
				BobbyHealth.current.setHealth(BobbyHealth.current.getHealth() + 1);
				//give him 100 points
				CodeSpawner.currentCodeSpawner.setTimerStart(true); //set timer to true to prevent the default codeSpawn from triggering from adding 100 points
				ScoreAndSpeedScript.addPointsToScore(100);
				CodeSpawner.currentCodeSpawner.resetCodeSpawnTime();//set a new timer relative to the newly added 100 points
				CodeSpawner.currentCodeSpawner.setTimerStart(false);
				//slow down highway nightsky cars
			}
		}
	}
}
