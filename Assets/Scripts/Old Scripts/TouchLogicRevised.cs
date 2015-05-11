/*/
* Revised By Marco Chin
* Original Script by Devin Curry
* www.Devination.com
* www.youtube.com/user/curryboy001
* Please like and subscribe if you found my tutorials helpful :D
* Google+ Community: https://plus.google.com/communities/108584850180626452949
* Twitter: https://twitter.com/Devination3D
* Facebook Page: https://www.facebook.com/unity3Dtutorialsbydevin
/*/

//this script is enabled by CameraFPS Script

using UnityEngine;
using System.Collections;

public class TouchLogicRevised : MonoBehaviour
{
	public static int currTouch = 0;//so other scripts can know what touch is currently on screen
	[HideInInspector]
	public int touch2Watch = 64;
	public Transform[] button;
	private Texture2D[] upTexture = new Texture2D[7];
	public Texture2D[] downTexture;
	public Transform bobby;
	private int[] fingerIDtoButtonID = new int[7]; //index is fingerid num, value is button id num
	private bool isButtonHit;

	//private CodeSpawner codeSpawner;

	void Awake(){
		//codeSpawner = GetComponent<CodeSpawner>();
	}

	void Start(){
		for (int i = 0; i < button.Length; i++) {
			upTexture[i] = (Texture2D) button[i].guiTexture.texture; 
			// store the original texture so we dont lose reference to it
		}
	}
	void Update()//If your child class uses Update, you must call base.Update(); to get this functionality
	{
		//is there a touch on screen?
		if(Input.touches.Length <= 0)
		{
			OnNoTouches();
		}
		else if (Input.touches.Length > 0 && Input.touches.Length <= 7)//if there is a touch, but no more than 7
		{
			//loop through all the the touches on screen
			foreach(Touch touch in Input.touches)
			{
				currTouch = touch.fingerId;

				//no Button is hit at the beginning
				isButtonHit = false;

				//loop through all of buttons to see if the current finger is touching it
				for(int i = 0; i<button.Length; i++){
					if(button[i].guiTexture != null && (button[i].guiTexture.HitTest(touch.position)))
					{
						isButtonHit = true;

						//if sliding finger around if it tocuhes a button with uptexture then push down
						if(button[i].guiTexture.texture.name.EndsWith("1")
						   && !button[i].name.Equals("ButtonLockUnlock")){
							popPreviousAssociatedButtonUp(touch.fingerId); //pop previous reference
							fingerIDtoButtonID[touch.fingerId] = i; //assign new reference
							button[i].guiTexture.texture = downTexture[i];
						}

						if(button[i].name.Equals("ArrowLeft")){
							bobby.GetComponent<BobbyController>().moveLeft();
						}
						else if (button[i].name.Equals("ArrowRight")){
							bobby.GetComponent<BobbyController>().moveRight();
						}

						//if current touch hits our guitexture, run this code
						if(touch.phase == TouchPhase.Began)
						{
							//add the reference only at touch begin so it wont get overriden by other touch phases
							fingerIDtoButtonID[touch.fingerId] = i; 
							OnTouchBegan(i);
							touch2Watch = currTouch;
						}
						else if(touch.phase == TouchPhase.Ended && !button[i].name.Equals("ButtonLockUnlock"))
						{
							OnTouchEnded(i);
						}
					}
				}

				if(!isButtonHit){ //if finger is on screen but not touching any of the buttons pop button back up
					popPreviousAssociatedButtonUp(touch.fingerId);
				}
			}//end touch forloop
		}//end else
	}//end Update

	//the default functions, define what will happen if the child doesn't override these functions
	void OnNoTouches(){}

	void OnTouchBegan(int i){

		if(button[i].guiTexture.texture.name.Equals("unlock2")){
			button [i].guiTexture.texture = upTexture [i];
		} else{
			button [i].guiTexture.texture = downTexture [i];
		}

		switch (i){
		case 0:
			bobby.GetComponent<BobbyController>().moveUp();
			break;
		case 1:
			bobby.GetComponent<BobbyController>().moveDown();
			break;
		}
	}

	void OnTouchEnded(int i){
		button[i].guiTexture.texture = upTexture[i];
	}

	void popPreviousAssociatedButtonUp(int fingerId){
		int buttonID = fingerIDtoButtonID[fingerId];
		//Debug.Log (button[buttonID].guiTexture.texture.name);
		if(button[buttonID].guiTexture.texture.name.EndsWith("2")
		   && !button[buttonID].guiTexture.texture.name.Equals("unlock2")){
			button[buttonID].guiTexture.texture = upTexture[buttonID];
		}
	}
}