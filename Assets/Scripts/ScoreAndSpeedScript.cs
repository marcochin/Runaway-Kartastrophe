using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//this script is enabled by CameraFPS Script

public class ScoreAndSpeedScript : MonoBehaviour {
	//public GUIStyle style;
	public GameObject highway;
	public GameObject nightsky;
	private static int score;
	private int defaultScoreIncrement = 1;
	private float timeToUpdateScore = 0f;
	private float scoreUpdateInterval = 0.2f; 

	private float speedIncreaseTime = 2.33f; //default starting time real time 6.25s
	private float speedIncreaseInterval = 2.33f; //interval will be continuosly added to the default starting time 6.25s

	private OffsetScrolling highwayOffset;
	private OffsetScrolling nightSkyOffset;
	private float highwaySpeedIncreaseAmnt = 0.08f; //max 2
	private float nightSkySpeedIncreseAmnt = 0.027f; //no max just relatively slower than highway
	private float maxHighwaySpeed = 2.0f;

	//spawn rate will not change proportionally to enemy speed, it will be increasingly slower
	//private float spawnRatePercentageOffset = 1f;
	//private float spawnRateIntervalChange = 0.005f;

	private float enemySpeedIncreaseAmnt = 2.8f; //max 25
	private float enemy5SpeedIncreaseAmnt = 0.7f;

	public GameObject scoreActual;
	private Text scoreActualText;
	private bool isCountDownOver;


	// Use this for initialization
	void Awake () {
		score = 0;
		highwayOffset = highway.GetComponent<OffsetScrolling> ();
		nightSkyOffset = nightsky.GetComponent<OffsetScrolling> ();

		scoreActualText = scoreActual.GetComponent<Text> ();
		scoreActualText.text = "Score: " + score;
	}
	void Start(){
		StartCoroutine (setIsCountDownOverFalse ());
	}

	void Update(){
		if (isCountDownOver && Time.time > timeToUpdateScore) {
			updateScoreAndSpeed();
		}
	}

	void updateScoreAndSpeed(){
		score += defaultScoreIncrement;
		timeToUpdateScore = Time.time + scoreUpdateInterval;

		//speed increaes every 1000 points
		if (score >= speedIncreaseTime){

			Vector2 currentHighwayRate = highwayOffset.getUvAnimationRate();
			Vector2 currentNightSkyRate = nightSkyOffset.getUvAnimationRate();

			if(currentHighwayRate.x <= maxHighwaySpeed){
				speedIncreaseTime += speedIncreaseInterval;

				//move only in x direction
				highwayOffset.setUvAnimationRate(new Vector2( currentHighwayRate.x + highwaySpeedIncreaseAmnt, 0.0f));
				nightSkyOffset.setUvAnimationRate(new Vector2( currentNightSkyRate.x + nightSkySpeedIncreseAmnt, 0.0f));
				
				//increase enemy speed next and enemy 5 too
				float previousEnemySpeed = EnemyMoveScript.speed;

				EnemyMoveScript.speed += enemySpeedIncreaseAmnt;
				Enemy5MoveScript.speed += enemy5SpeedIncreaseAmnt;

				//Debug.Log(EnemyMoveScript.speed + " " + highwayOffset.getUvAnimationRate().x);


				//evry time you speed up you need to slow down the spawn time just a little so it will give the player a chance
				//to maneauver between cars
				float howManyTimesFaster = EnemyMoveScript.speed/ previousEnemySpeed; // 10/5 = 2, would be two times fasters
				float newMinSpeed = ObjectSpawnerScript.current.getMinSpawnTime()/howManyTimesFaster;
				float newMaxSpeed = ObjectSpawnerScript.current.getMaxSpawnTime()/howManyTimesFaster;

				//spawnRatePercentageOffset -= spawnRateIntervalChange;

				ObjectSpawnerScript.current.setMinSpawnTime(newMinSpeed);
				ObjectSpawnerScript.current.setMaxSpawnTime(newMaxSpeed);
			}
		}

		scoreActualText.text = "Score: " + score; //update score every frame
	}

	public static int getScore(){
		return score;
	}

	public static void addPointsToScore(int points){
		score += points;
	}

	private IEnumerator setIsCountDownOverFalse(){
		yield return new WaitForSeconds (0.32f);
		isCountDownOver = true;
	}

	/*void OnGUI(){

		GUI.Label(new Rect(Screen.width/2, 50, 100, 100), score.ToString(), style);
	}*/
}
