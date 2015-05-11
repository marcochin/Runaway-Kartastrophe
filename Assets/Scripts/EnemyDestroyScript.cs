using UnityEngine;
using System.Collections;

public class EnemyDestroyScript : MonoBehaviour {
	
	private Vector3 fullScreen;
	private float halfEnemyWidth;

	void Start(){
		getResolutionInWorldUnits ();

		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> (); //grab the sprite renderer of gameobj
		halfEnemyWidth = sRenderer.sprite.bounds.size.x/2; //gives us width of element no matter how we size it.
	}

	void Update(){
		if (transform.position.x + (halfEnemyWidth * transform.localScale.x) < -fullScreen.x) {
			gameObject.SetActive (false);
		}
	}

	private void getResolutionInWorldUnits(){
		fullScreen = BobbyController.getFullScreen ();
	}


	/*old method
	void OnEnable(){
		StartCoroutine (Destroy ());
	}

	IEnumerator Destroy(){
		yield return new WaitForSeconds (10.0f);
		gameObject.SetActive (false);
	}

	void onDisable(){
		CancelInvoke ();
	}*/
}
