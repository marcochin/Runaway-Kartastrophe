using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawnerScript : MonoBehaviour {
	public static ObjectSpawnerScript current;

	private float minSpawnTime = .75f;
	private float maxSpawnTime = .76f;

	//private int triple = 100; //lane probabilities
	private int dubble = 40;
	private int single = 10;
	
	private int enemy5Probability = 10;

	private float spawnPos1 = 10.0f;
	private float spawnPos2 = 12.2f;
	private float spawnPos3 = 14.4f;

	private Vector2 lane1, lane2, lane3, lane4;
	
	private float timeToSpawn = 0f;

	private int maxLanes = 4;
	private List<int> uniqueLanes;
	private List<int> finishedList;

	public GameObject bobby;

	// Use this for initialization


	void Awake () {
		current = this;

		uniqueLanes = new List<int>();
		finishedList = new List<int>();

		float upDownDistance = BobbyController.getUpdownDistance ();

		lane3 = new Vector2 (spawnPos2, bobby.transform.position.y);
		lane2 = new Vector2 (lane3.x, lane3.y + upDownDistance);
		lane1 = new Vector2 (lane3.x, lane2.y + upDownDistance);
		lane4 = new Vector2 (lane3.x, lane3.y - upDownDistance);

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToSpawn) {
			//calculate next spawn time
			timeToSpawn = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
			//timeToSpawn = Time.time + 4.0f;
			//which lanes to spawn?

			float laneSpawn = Random.Range(1, 101);



			if(laneSpawn <= single){
				SpawnLanes(1);
			}
			else if(laneSpawn > single && laneSpawn <= dubble){
				SpawnLanes(2);
			}
			else {
				SpawnLanes(3);
			}

		}
	}

	private void SpawnLanes(int numberOfLanes){
		uniqueLanes.Clear ();
		finishedList.Clear ();

		for (int i = 1; i<= maxLanes; i++){ //adds 1 2 3 4 to the list
			uniqueLanes.Add(i);
		}

		//picks a random num from 1 2 3 4 and then removes it from the pool
		for (int i = 0; i< numberOfLanes; i++) {
			int lane = uniqueLanes[Random.Range(0, uniqueLanes.Count)];
			finishedList.Add(lane); //add number
			uniqueLanes.Remove(lane); //remove number from pool
		}

		for (int i = 0; i< finishedList.Count; i++) {
			int randomEnemy = Random.Range(1, 101);
			if(randomEnemy < enemy5Probability){
				randomEnemy = 5; 
			}
			else{
				randomEnemy = Random.Range(1,5);
			}

			GameObject obj = ObjectPoolerScript.current.GetPooledObject (randomEnemy);

			if (obj == null){
				Debug.Log ("got null enemy");
				return;
			}

			//position object
			//set active true
			switch(finishedList[i]){
			case 1:
				obj.transform.position = lane1;
				break;
			case 2:
				obj.transform.position = lane2;
				break;
			case 3:
				obj.transform.position = lane3;
				break;
			case 4:
				obj.transform.position = lane4;
				break;
			}

			if( numberOfLanes == 2 || numberOfLanes == 3){
				int pos1or2or3 = Random.Range(1,4); //meaning spawn left mid(default) or right

				switch(pos1or2or3){
				case 1:
					obj.transform.position = new Vector2(spawnPos1, obj.transform.position.y);
					break;

				//no need case 2 because that is the original spawn position

				case 3:
					obj.transform.position = new Vector2(spawnPos3, obj.transform.position.y);
					break;
				}
			}

			obj.transform.rotation = bobby.transform.rotation;
			obj.SetActive(true);

		}
	}

	public void setMinSpawnTime(float minSpawnTime){
		this.minSpawnTime = minSpawnTime;
	}

	public void setMaxSpawnTime(float maxSpawnTime){
		this.maxSpawnTime = maxSpawnTime;
	}

	public float getMinSpawnTime(){
		return minSpawnTime;
	}
	
	public float getMaxSpawnTime(){
		return maxSpawnTime;
	}
}
