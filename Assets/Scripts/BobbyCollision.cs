using UnityEngine;
using System.Collections;

public class BobbyCollision : MonoBehaviour {
	private float halfBobbyWidth;
	private int explosionNumFromPool = 6;
	private static Animator anim;

	// Use this for initialization

	private BobbyCollision(){
	}

	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D other){ 

		//if not in blinking(colliding) animation, bobby is eligible to collide
		if (anim.GetBool ("isColliding") == false) {
			//Enemy5 will explode if you touch but it wont harm you. Suppose to protect you
			if(!other.name.Equals("Enemy5(Clone)")){
				BobbyHealth.current.subtractOneHealth();

				//start coroutine to set isColliding back to false
				if(gameObject.activeInHierarchy)
					StartCoroutine (startCollisionAnimation ());
			}

			//getPooled explosion obj
			GameObject explosion = ObjectPoolerScript.current.GetPooledObject (explosionNumFromPool);
			
			if (explosion == null) {
				Debug.Log ("got null explosion");
				return;
			}
	
			//adjust the position and rotation
			explosion.transform.position = other.transform.position;
			explosion.transform.rotation = transform.rotation;
			other.gameObject.SetActive (false);
			explosion.SetActive (true);
		}
	}

	public static IEnumerator startCollisionAnimation(){
		anim.SetBool ("isColliding", true);
		yield return new WaitForSeconds (0.338f); 
		anim.SetBool ("isColliding", false);
	}
}
