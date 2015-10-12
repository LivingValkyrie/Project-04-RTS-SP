using UnityEngine;
using System.Collections;

/*
 * @author Victor Haskins
 * class Tile Area Contains information on a collider instance for the tile instance
 */
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
    //check if the structure tied to the collider is active.
    public bool IsStructureActive()
    {
        return status.activeInHierarchy;
    }
    //check if the structure tied to the collider can be activated
    public bool CanStructureActivate()
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
    //special for the road placement in the beginning, must be beside a settlement
    //not just looking for roads.
    public bool CanPlaceStartupRoad()
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

	//make structure visible.
	void ActivateStructure()
	{
		status.SetActive = true;
	}

	//Try to activate the structure. Material amounts should
	//already be approved.
	public void TryToActivate()
	{
		bool active = IsStructureActive ();

		if (!active) 
		{
			bool canMakeActive = CanStructureActivate();
			if(canMakeActive)
			{
				ActivateStructure();
			}
		}

	}

}
