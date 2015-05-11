using UnityEngine;
using System.Collections;

public class Enemy5CollisionScript : MonoBehaviour {
	private int explosionNumFromPool = 6;
	
	void OnTriggerStay2D(Collider2D other){ 

		if(!other.name.Equals("Bobby")){ //if it crashes to any other car ecept bobby cause he has he own collison script
			//getPooled explosion obj
			GameObject explosion = ObjectPoolerScript.current.GetPooledObject (explosionNumFromPool);
			
			if (explosion == null) {
				Debug.Log ("got null explosion");
				return;
			}

			//adjust the position and rotation
			explosion.transform.position = other.transform.position;
			explosion.transform.rotation = other.transform.rotation;
			transform.gameObject.SetActive (false); //set crasher to false
			other.gameObject.SetActive(false); //set victim to false
			explosion.SetActive (true);
		}
	}
}
