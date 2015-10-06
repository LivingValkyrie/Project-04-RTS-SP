﻿using UnityEngine;
using System.IO;

/// <summary>
/// @Author: Andrew Seba
/// @Description: takes the player and level name and writes it to a file under
/// Assets/save_data/"levelName"/gameinformation.txt
/// 
/// Data Structure
/// --------------
/// userName
/// levelName
/// </summary>
public class InformationSave : MonoBehaviour {

	string userName = null;
	string levelName = null;
	string txtInfoLocation;
	string outputFile = "/gameinformation.txt";

	public string UserName
	{
		set
		{
			userName = value;
		}
		get
		{
			return UserName;
		}
	}

	public string LevelName
	{
		set
		{
			levelName = value;
		}
		get
		{
			return levelName;
		}
	}

	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	/// <summary>
	/// Takes the level name and makes a new folder.
	/// Creates a gameinformation.txt file and writes the user name and level name.
	/// </summary>
	public void _InitFile()
	{
		txtInfoLocation = Application.dataPath + "/save_data/" + levelName;
		StreamWriter writer = null;


		//Check to see if both things have been entered as a safety.
		if (userName != null && levelName != null)
		{
			if (!Directory.Exists(txtInfoLocation))
			{
				Directory.CreateDirectory(
					Application.dataPath + "/save_data/" + levelName);

			}


			//gameinformation.txt
			//UserName
			//LevelName
			using (writer = new StreamWriter(txtInfoLocation + outputFile))
			{
				writer.WriteLine(userName);
				writer.WriteLine(levelName);
				
			}
			writer.Close();
		}
		else
		{
			Debug.Log("Either name or level name haven't been entered." +
				"\nThis is required.");
		}

	}


	public void SaveGame()
	{
		PlayerData playerData = GameObject.Find("GameInformation").GetComponent<PlayerData>();

		StreamWriter writer = null;
		using (writer = new StreamWriter(txtInfoLocation + outputFile))
		{
			writer.WriteLine(userName);
			writer.WriteLine(levelName);

			writer.WriteLine(playerData.curPhase);

			writer.WriteLine(playerData.wood);
			writer.WriteLine(playerData.wool);
			writer.WriteLine(playerData.brick);
			writer.WriteLine(playerData.grain);

			//write actions
			foreach(string action in playerData.playerActions)
			{
				writer.WriteLine(action);
			}
		}
		writer.Close();
	}
}
