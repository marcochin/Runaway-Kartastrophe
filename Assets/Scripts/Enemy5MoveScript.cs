using UnityEngine;
using System.Collections;

public class Enemy5MoveScript : MonoBehaviour {
	
	//class varaible, if speed changes then all change.
	public static float speed = 2.25f;//.05
	
	// Update is called once per frame

	void Update () {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	public static void resetSpeed(){
		speed = 2.25f;
	}
}
