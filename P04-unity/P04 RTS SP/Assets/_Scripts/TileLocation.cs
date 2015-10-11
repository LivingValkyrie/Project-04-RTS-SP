using UnityEngine;
using System.Collections;

public class TileLocation : MonoBehaviour {

    public int location;

    public int activationNumber;
    public int resourceAmount;

    public MapNodeType resourceType;

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
