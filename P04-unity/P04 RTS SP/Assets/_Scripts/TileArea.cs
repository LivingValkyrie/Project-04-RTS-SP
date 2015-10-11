using UnityEngine;
using System.Collections;

public class TileArea : MonoBehaviour {

    public enum StructureType
    {
        SETTLEMENT,
        ROAD
    }

    public string location;

    StructureType structure;

    public GameObject status;

    public GameObject[] activateStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
