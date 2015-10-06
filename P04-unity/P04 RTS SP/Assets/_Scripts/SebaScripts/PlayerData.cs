using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Holds all resource data and player actions.
/// </summary>
public class PlayerData : MonoBehaviour {

    public Phases curPhase;
    public int wood { get; set; }
    public int wool { get; set; }
    public int brick { get; set; }
    public int grain {get; set; }


    [HideInInspector]
    public List<string> playerActions;
    /// <summary>
    /// Adds a string to the player Actions list for saving later
    /// </summary>
    /// <param name="pAction"></param>
    public void AddAction(string pAction)
    {
        /*saving Heuristic (prototype)

        "build","road or settlement","ArrayLocation"   email me when you figure it out*/
        playerActions.Add(pAction);
    }

}
