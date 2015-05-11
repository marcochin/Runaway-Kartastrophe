using UnityEngine;
using System.Collections;

public class ArrowTouchScript : MonoBehaviour {
	private bool isTouch;
	public GameObject Bobby;
	private BobbyController bc;

	// Use this for initialization
	void Awake () {
		bc = Bobby.GetComponent<BobbyController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTouch == true) {
			if(gameObject.name.Equals("ArrowLeft")){
				bc.moveLeft();
			}
			else if(gameObject.name.Equals("ArrowRight")){
				bc.moveRight();
			}
		}
	}

	public void setisTouch(bool isTouch){
		this.isTouch = isTouch;
	}
}
