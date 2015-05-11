using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerScript : MonoBehaviour {

	public static ObjectPoolerScript current;
	public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, explosion, 
						leftCode, rightCode, upCode, downCode, aCode, bCode;
	
	public int pooledAmount = 8;
	public bool willGrow;
	public GameObject objectSpawner;

	private List<GameObject> pooledEnemy1;
	private List<GameObject> pooledEnemy2;
	private List<GameObject> pooledEnemy3;
	private List<GameObject> pooledEnemy4;
	private List<GameObject> pooledEnemy5;
	private List<GameObject> pooledExplosion;
	private List<GameObject> pooledLeftCode;
	private List<GameObject> pooledRightCode;
	private List<GameObject> pooledUpCode;
	private List<GameObject> pooledDownCode;
	private List<GameObject> pooledACode;
	private List<GameObject> pooledBCode;


	// Use this for initialization

	void Awake(){
		current = this;
	}

	void Start () {
		InstantiateObjectsForPooling ();

		StartCoroutine (startSpawn ()); //start spawning after 2.5s
	}

	IEnumerator startSpawn(){
		yield return new WaitForSeconds (0.32f);
		objectSpawner.SetActive (true);
	}
	
	public GameObject GetPooledObject(int randomEnemy){

		//loop through all objs to find a inactive one
		GameObject enemyToGrow = null;
		List<GameObject> enemyToGrowList = null;

		switch (randomEnemy) {

		//pool enemy1
		case 1:
			for (int i  = 0; i < pooledEnemy1.Count; i++) {
				if(!pooledEnemy1[i].activeInHierarchy){
					return pooledEnemy1[i];
				}
			}

			enemyToGrow = enemy1; //need this or else it wont know which enemy to Grow
			enemyToGrowList = pooledEnemy1; 
			break;
		
		//pool enemy2
		case 2:
			for (int i  = 0; i < pooledEnemy2.Count; i++) {
				if(!pooledEnemy2[i].activeInHierarchy){
					return pooledEnemy2[i];
				}
			}

			enemyToGrow = enemy2;
			enemyToGrowList = pooledEnemy2;
			break;

		//pool enemy3
		case 3:
			for (int i  = 0; i < pooledEnemy3.Count; i++) {
				if(!pooledEnemy3[i].activeInHierarchy){
					return pooledEnemy3[i];
				}
			}

			enemyToGrow = enemy3;
			enemyToGrowList = pooledEnemy3;
			break;

		//pool enemy4
		case 4:
			for (int i  = 0; i < pooledEnemy4.Count; i++) {
				if(!pooledEnemy4[i].activeInHierarchy){
					return pooledEnemy4[i];
				}
			}

			enemyToGrow = enemy4;
			enemyToGrowList = pooledEnemy4;
			break;
		
		//pool enemy5
		case 5:
			for (int i  = 0; i < pooledEnemy5.Count; i++) {
				if(!pooledEnemy5[i].activeInHierarchy){
					return pooledEnemy5[i];
				}
			}

			enemyToGrow = enemy5;
			enemyToGrowList = pooledEnemy5;
			break;
		
		//pool explosion
		case 6: 
			for (int i  = 0; i < pooledExplosion.Count; i++) {
				if(!pooledExplosion[i].activeInHierarchy){
					return pooledExplosion[i];
				}
			}
			
			enemyToGrow = enemy5;
			enemyToGrowList = pooledEnemy5;
			break;

		//pool leftCode
		case 7: 
			for (int i  = 0; i < pooledLeftCode.Count; i++) {
				if(!pooledLeftCode[i].activeInHierarchy){
					return pooledLeftCode[i];
				}
			}
			
			enemyToGrow = leftCode;
			enemyToGrowList = pooledLeftCode;
			break;

		//pool rightCode
		case 8: 
			for (int i  = 0; i < pooledRightCode.Count; i++) {
				if(!pooledRightCode[i].activeInHierarchy){
					return pooledRightCode[i];
				}
			}
			
			enemyToGrow = rightCode;
			enemyToGrowList = pooledRightCode;
			break;

		//pool upCode
		case 9: 
			for (int i  = 0; i < pooledUpCode.Count; i++) {
				if(!pooledUpCode[i].activeInHierarchy){
					return pooledUpCode[i];
				}
			}
			
			enemyToGrow = upCode;
			enemyToGrowList = pooledUpCode;
			break;

		//pool downCode
		case 10: 
			for (int i  = 0; i < pooledDownCode.Count; i++) {
				if(!pooledDownCode[i].activeInHierarchy){
					return pooledDownCode[i];
				}
			}
			
			enemyToGrow = downCode;
			enemyToGrowList = pooledDownCode;
			break;

		//pool aCode
		case 11: 
			for (int i  = 0; i < pooledACode.Count; i++) {
				if(!pooledACode[i].activeInHierarchy){
					return pooledACode[i];
				}
			}
			
			enemyToGrow = aCode;
			enemyToGrowList = pooledACode;
			break;

		//pool bCode
		case 12: 
			for (int i  = 0; i < pooledBCode.Count; i++) {
				if(!pooledBCode[i].activeInHierarchy){
					return pooledBCode[i];
				}
			}
			
			enemyToGrow = bCode;
			enemyToGrowList = pooledBCode;
			break;
		}

		//if no inactive one then create one if willGrow set to true
		if (willGrow) {
			GameObject obj = (GameObject) Instantiate(enemyToGrow);
			enemyToGrowList.Add(obj);
			return obj;
		}

		//else if all fails, return null
		return null;
	}

	void InstantiateObjectsForPooling(){
		pooledEnemy1 = new List<GameObject> ();
		pooledEnemy2 = new List<GameObject> ();
		pooledEnemy3 = new List<GameObject> ();
		pooledEnemy4 = new List<GameObject> ();
		pooledEnemy5 = new List<GameObject> ();
		pooledExplosion = new List<GameObject> ();
		pooledLeftCode = new List<GameObject> ();
		pooledRightCode = new List<GameObject> ();
		pooledUpCode = new List<GameObject> ();
		pooledDownCode = new List<GameObject> ();
		pooledACode = new List<GameObject> ();
		pooledBCode = new List<GameObject> ();

		//loop to add all the pooled objects
		//instantiate enemy1
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(enemy1);
			obj.SetActive(false);
			pooledEnemy1.Add (obj);
		}

		//instantiate enemy2
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(enemy2);
			obj.SetActive(false);
			pooledEnemy2.Add (obj);
		}

		//instantiate enemy3
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(enemy3);
			obj.SetActive(false);
			pooledEnemy3.Add (obj);
		}


		//instantiate enemy4
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(enemy4);
			obj.SetActive(false);
			pooledEnemy4.Add (obj);
		}


		//instantiate enemy5
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(enemy5);
			obj.SetActive(false);
			pooledEnemy5.Add (obj);
		}

		//instantiate explosion
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(explosion);
			obj.SetActive(false);
			pooledExplosion.Add (obj);
		}

		//instantiate leftCode
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(leftCode);
			obj.SetActive(false);
			pooledLeftCode.Add (obj);
		}

		//instantiate rightCode
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(rightCode);
			obj.SetActive(false);
			pooledRightCode.Add (obj);
		}

		//instantiate upCode
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(upCode);
			obj.SetActive(false);
			pooledUpCode.Add (obj);
		}

		//instantiate downCode
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(downCode);
			obj.SetActive(false);
			pooledDownCode.Add (obj);
		}

		//instantiate aCode
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(aCode);
			obj.SetActive(false);
			pooledACode.Add (obj);
		}

		//instantiate bCode
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(bCode);
			obj.SetActive(false);
			pooledBCode.Add (obj);
		}

	}
}
