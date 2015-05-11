using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoCountdownDeactivate : MonoBehaviour {

	public GameObject buttonControls;

	// Use this for initialization
	void Start () {
		StartCoroutine(DeactivateGoCountdown());
	}

	IEnumerator DeactivateGoCountdown(){
		yield return new WaitForSeconds(0.32f);
		buttonControls.GetComponent<CanvasGroup> ().interactable = true;
	}
}
