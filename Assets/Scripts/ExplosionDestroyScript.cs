using UnityEngine;
using System.Collections;

public class ExplosionDestroyScript : MonoBehaviour {
	
	void OnEnable(){
		StartCoroutine (Destroy ());
	}

	IEnumerator Destroy(){
		yield return new WaitForSeconds (0.32f); //remove explosion sprite after 2.5 seconds
		gameObject.SetActive (false);
	}
}
