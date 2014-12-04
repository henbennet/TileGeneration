using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {
	public Color normalColor = Color.red;
	public Color overColor = Color.green;
	public Transform selectionCube;


	TileMap tileMap;
	Vector3 currentTileCoord;

	// Use this for initialization
	void Start () {
		tileMap = GetComponent<TileMap>();
	}
	
	// Update is called once per frame
	void Update () {
		//Ray ray = new Ray (camera.transform.position, camera.transform.forward);	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitinfo;
		
		if (collider.Raycast(ray, out hitinfo, Mathf.Infinity)) { 
			Debug.Log (/*transform.worldToLocalMatrix * */hitinfo.point - transform.position);
			int x = Mathf.FloorToInt(hitinfo.point.x / tileMap.tileSize);
			int z = Mathf.FloorToInt(hitinfo.point.z / tileMap.tileSize);

			Debug.Log("Tile: " + x + ", " + z);
			currentTileCoord.x = x;
			currentTileCoord.z = z;
			selectionCube.transform.position = currentTileCoord * tileMap.tileSize;
		}

		if (Input.GetMouseButtonDown (0)) {

		}

	}
}
