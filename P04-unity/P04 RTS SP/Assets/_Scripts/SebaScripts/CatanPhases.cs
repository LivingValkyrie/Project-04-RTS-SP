using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum Phases
{
	GAMESTART,//One time go.
	ROLL,
	TRADE,//Extra Credit.
	BUILD,
	PROCESS,//For furture use.
	ENDGAME
}


/// <summary>
/// @Author: Andrew Seba
/// @Description: Controls phases of the game.
/// </summary>
public class CatanPhases : MonoBehaviour {

	Text textCurPhase;
	Text textNextPhase;

	Phases phase;
	int turnNumber = 0;
	int curPhaseIndex = 0;

	//This will restart the curPhaseIndex to 0 when you reach this num.
	const int ROTATE = 6;


	//Stops the UpdateText from throwing errors if theres no text gui in the scene.
	[HideInInspector]
	public bool textEnabled = true;

	void Start()
	{
		try
		{
			textCurPhase = GameObject.Find("Text_CurPhase").GetComponent<Text>();
			textNextPhase = GameObject.Find("Text_NextPhase").GetComponent<Text>();
		}
		catch
		{
			textEnabled = false;
		}

		curPhaseIndex = (int)Convert.ChangeType(phase, phase.GetTypeCode());

		UpdateText();
	}

	/// <summary>
	/// @Author: Andrew Seba
	/// Increments the phase to next ENUM;
	/// </summary>
	public void NextPhase()
	{

		curPhaseIndex = (curPhaseIndex + 1) % ROTATE;
		phase = (Phases)curPhaseIndex;

		//A system, to change phase to the appropriate phase

		switch (phase)
		{
			case (Phases.GAMESTART):
				if(turnNumber > 0)
				{
					//skip phase
					SetPhase("ROLL");
					break;
				}
				else
					SetPhase("GAMESTART");

				break;
			case (Phases.ROLL):
				SetPhase("ROLL");
				break;
			case (Phases.TRADE):
				SetPhase("TRADE");
				break;
			case (Phases.BUILD):
				SetPhase("BUILD");
				break;
			case (Phases.PROCESS):
				turnNumber++;
				SetPhase("PROCESS");
				break;
			case (Phases.ENDGAME):
				//if(game is over)
					//move to appropriate game over screen
				//else
					//SetPhase("ROLL");
				break;
		}

		UpdateText();
	}

    /// <summary>
    /// Uses the string parameter to Set phase directly.
    /// </summary>
    /// <param name="pPhase"></param>
	public void SetPhase(string pPhase)
	{
		pPhase = pPhase.ToUpper();
		switch (pPhase)
		{
			case ("GAMESTART"):
				phase = Phases.GAMESTART;
				Debug.Log ("Doing game start things...");
				break;
			case ("ROLL"):
				phase = Phases.ROLL;
				Debug.Log ("Doing roll things...");
				break;
			case ("TRADE"):
				phase = Phases.TRADE;
				Debug.Log ("Doing Trade things...");

				break;
			case ("BUILD"):
				phase = Phases.BUILD;
				Debug.Log ("Doing build things...");

				break;
			case ("PROCESS"):
				phase = Phases.PROCESS;
				break;
			case ("ENDGAME"):
				phase = Phases.ENDGAME;
				break;
		}
		curPhaseIndex = (int)phase.GetTypeCode();
	}


	//Updates text strings.
	public void UpdateText()
	{
		if (textEnabled)
		{
			try
			{
				textCurPhase = GameObject.Find("Text_CurPhase").GetComponent<Text>();
				textNextPhase = GameObject.Find("Text_NextPhase").GetComponent<Text>();
			}
			catch
			{
				textEnabled = false;
				Debug.Log("No text objects found. Probably not in the game scene.");
			}
			textCurPhase.text = "Current Phase: " + phase.ToString();
			textNextPhase.text = "Next Phase: " + ((Phases)((curPhaseIndex + 1) % ROTATE)).ToString();

		}
	}

}
