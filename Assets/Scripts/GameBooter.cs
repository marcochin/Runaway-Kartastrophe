using UnityEngine;
using System.Collections;

public class GameBooter : MonoBehaviour {

	//public GUIStyle style;


	void Start (){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		//sass = GetComponent<ScoreAndSpeedScript> ();

		//StartCoroutine (enableScoreSpeedAndTouch());
		//Thread enableScripts = new Thread (enableScoreSpeedAndTouch);
		//enableScripts.Start ();
	}

	/*void OnGUI()
	{
		int fps = (int)(1.0f / Time.smoothDeltaTime);
		GUI.Label(new Rect(0, 50, 100, 100), fps.ToString(), style);
		GUI.Label(new Rect(0, 25, 100, 100), f, style);
		if (fps < 40){
			f = fps.ToString();
		}
	}*/

	/*IEnumerator enableScoreSpeedAndTouch(){
		yield return new WaitForSeconds (0.32f);
		sass.enabled = true;
	}*/
}
