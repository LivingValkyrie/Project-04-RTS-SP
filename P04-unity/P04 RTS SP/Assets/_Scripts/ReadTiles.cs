using UnityEngine;
using System.Collections;

public class ReadTiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			//Debug.Log ("Pressed left mouse button.");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit tileHit;

			if(Physics.Raycast(ray,out tileHit)){
				if(tileHit.collider.tag == "Tile"){
					//hit.collider.gameObject now refers to the 
					//cube under the mouse cursor if present
					Debug.Log("Tile clicked on.");
				}

				if(tileHit.collider.tag == "Side"){
					TileArea areaScript = tileHit.collider.GetComponent<TileArea>();

					Debug.Log("Side. Clicked on " + areaScript.location);
				}

				if(tileHit.collider.tag == "Corner"){
					TileArea areaScript = tileHit.collider.GetComponent<TileArea>();

					Debug.Log ("Corner. Clicked on " + areaScript.location);
				}
			}
		}
	}
}
