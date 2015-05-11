using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {

	//class varaible, if speed changes then all change.
	public static float speed = 11.25f;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	public static void resetSpeed(){
		speed = 11.25f;
	}
}
