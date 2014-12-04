using UnityEngine;
using System.Collections;

public class TileMouseOver : MonoBehaviour {

	public Color normalColor;
	public Color overColor = Color.green;

	void Start() {
		normalColor = renderer.material.color;
	}

	// Update is called once per frame
	void Update () {
		//Ray ray = new Ray (camera.transform.position, camera.transform.forward);	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitinfo;

		if (collider.Raycast(ray, out hitinfo, Mathf.Infinity)) { 
						renderer.material.color = overColor;
		} else {
			renderer.material.color = normalColor;
		}

	}

	void OnMouseOver() {
		renderer.material.color = overColor;
	}

	void OnMouseExit() {
		renderer.material.color = normalColor;
	}

}
