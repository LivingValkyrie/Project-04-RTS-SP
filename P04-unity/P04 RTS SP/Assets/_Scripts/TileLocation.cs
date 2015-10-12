using UnityEngine;
using System.Collections;

/*
 * @author Victor Haskins
 * class Tile Location holds overall tile information for instances
 */
public class TileLocation : MonoBehaviour {

    public int location;
    //hold activation number and amount
    public int activationNumber;
    public int resourceAmount;
    //type of resource provided on activation roll
    public MapNodeType resourceType;
    //changes tile depending on resource
    public Material[] resourceMatTypes;
    
    public GameObject[] settlements;

    Transform tile;
    MeshRenderer mesh;

	// Use this for initialization
	void Start () {
        tile = transform.FindChild("Cylinder");
        mesh = tile.GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        mesh.material = resourceMatTypes[(int)resourceType];
	}
}
