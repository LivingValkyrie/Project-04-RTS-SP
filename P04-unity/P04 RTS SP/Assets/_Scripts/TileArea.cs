using UnityEngine;
using System.Collections;

public class TileArea : MonoBehaviour {

    public enum StructureType
    {
        SETTLEMENT,
        ROAD
    }
    [Tooltip("Legacy variable from testing.")]
    public string location;
    [Tooltip("Determines if object is treated like a road or a settlement.")]
    public StructureType structure;
    [Tooltip("Road or Settlement that should be checked/verified for activation.")]
    public GameObject status;
    [Tooltip("Array to see if a settlement or road can be built/extended from current structures.")]
    public GameObject[] activateStatus;
    [Tooltip("Array of Settlements to check if a starting road can be placed")]
    public GameObject[] startupStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isStructureActive()
    {
        return status.activeInHierarchy;
    }

    public bool canStructureActivate()
    {
        bool returnValue = false;

        foreach(GameObject value in activateStatus)
        {
            if(value.activeInHierarchy)
            {
                returnValue = true;
            }
        }

        return returnValue;
    }

    public bool canPlaceStartupRoad()
    {
        bool returnValue = false;

        if (structure == StructureType.ROAD)
        {
            foreach (GameObject value in startupStatus)
            {
                if (value.activeInHierarchy)
                {
                    returnValue = true;
                }
            }
        }

        return returnValue;
    }
}
