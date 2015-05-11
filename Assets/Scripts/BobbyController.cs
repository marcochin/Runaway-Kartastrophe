using UnityEngine;
using System.Collections;

public class BobbyController : MonoBehaviour {

	private static float updownDistance = 1.38f;
	private static Vector3 fullScreen;
	private static float halfBobbyWidth;
	private int currentLane = 3;
	public float moveSpeed = 10.0f;
	//public GUIStyle style;

	void Start(){
		getResolutionInWorldUnits ();
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> (); //grab the sprite renderer of gameobj
		halfBobbyWidth = sRenderer.sprite.bounds.size.x/2; //gives us width of element no matter how we size it.
	}

	private void getResolutionInWorldUnits(){
		float bobbyDistFromCam;
		//converts the fullscreen size in pixels (on our device) into world units (in the game world).	
		bobbyDistFromCam = transform.position.z - Camera.main.transform.position.z; 		
		fullScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, bobbyDistFromCam));
	}

	/*void OnGUI() //for debugging
	{
		GUI.Label(new Rect(0, 0, 500, 100), transform.position.x + " " + fullScreen.x + " " + halfBobbyWidth, style);
	}*/


	//------------------------------------------------------------
	//Touch Logic Script on the Main Camera will call these in its update function
	public void moveUp(){
		if (currentLane != 1) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + updownDistance);
			currentLane--;
		}
	}

	public void moveDown(){
		if (currentLane != 4) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - updownDistance);
			currentLane++;
		}
	}

	public void moveLeft(){
		if (transform.position.x > (-fullScreen.x + (halfBobbyWidth * transform.localScale.x))) {
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		}
	}

	public void moveRight(){
		if (transform.position.x < (fullScreen.x - (halfBobbyWidth*  transform.localScale.x))) {
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		}
	}

	//------------------------------------------------------------



	public static float getUpdownDistance(){
		return updownDistance;
	}

	public static Vector3 getFullScreen(){
		return fullScreen;
	}

	public static float getHalfBobbyWidth(){
		return halfBobbyWidth;
	}
}
