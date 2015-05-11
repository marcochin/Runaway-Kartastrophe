using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScoreLoaderSaver : MonoBehaviour {

	public static HighScoreLoaderSaver current;

	void Awake(){
		current = this;
	}

	public int loadHighScore(){
		if (File.Exists (Application.persistentDataPath + "/playerHighScore.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/playerHighScore.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();

			return data.highScore;
		}
		else{
			return 0;
		}
	}

	public void saveHighScore(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerHighScore.dat");
		PlayerData data = new PlayerData ();
		data.highScore = ScoreAndSpeedScript.getScore (); //reads score in playerData

		bf.Serialize (file, data);
		file.Close ();
	}

	[Serializable] //means it is eligible to be turned into a string of 1's and 0's so it can be stored in a file and reconstructed later on
	class PlayerData{
		public int highScore;
	}
}
