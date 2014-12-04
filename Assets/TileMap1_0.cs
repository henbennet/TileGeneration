﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

[RequireComponent(typeof(MeshFilter))] 
[RequireComponent(typeof(MeshRenderer))] 
[RequireComponent(typeof(MeshCollider))] 

public class TileMap1_0 : MonoBehaviour {
	
	//Number of tiles
	public int size_x = 100;
	public int size_z = 50;
	public float tileSize = 1.0f;
	// Use this for initialization
	void Start () {
		BuildMesh ();
	}
	
	public void BuildMesh() {
		
		int numberOfTiles = size_x * size_z;
		int numTris = numberOfTiles * 2;
		
		int vsize_x = size_x + 1;
		int vsize_z = size_z + 1;
		int numVerts = vsize_x * vsize_z;
		
		
		//Generate mesh data
		Vector3[] vertices = new Vector3[numVerts];
		Vector3[] normals = new Vector3[numVerts];
		Vector2[] uv = new Vector2[numVerts];
		int[] triangles = new int[numTris*3];
		
		int z, x;
		for (z=0; z<size_z; z++) {
			for (x=0; x<size_x; x++) {
				vertices[z * vsize_x + x] = new Vector3(x * tileSize, Random.Range(-1f, 1f), z * tileSize);
				normals[z * vsize_x + x] = Vector3.up;
				uv[ z * vsize_x + x ] = new Vector2( (float)x / vsize_x, (float)z / vsize_z );
			}
		}
		
		Debug.Log ("Done Verts!");
		
		for(z=0; z < size_z; z++) {
			for(x=0; x < size_x; x++) {
				int squareIndex = z * size_x + x;
				int triOffset = squareIndex * 6;
				triangles[triOffset + 0] = z * vsize_x + x + 		   0;
				triangles[triOffset + 1] = z * vsize_x + x + vsize_x + 0;
				triangles[triOffset + 2] = z * vsize_x + x + vsize_x + 1;
				
				triangles[triOffset + 3] = z * vsize_x + x + 		   0;
				triangles[triOffset + 4] = z * vsize_x + x + vsize_x + 1;
				triangles[triOffset + 5] = z * vsize_x + x + 		   1;
			}
		}
		
		Debug.Log ("Done Triangles!");
		
		//Create a new mesh and populate it
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;
		
		//Assign mesh to filter/renderer/collider
		MeshFilter mf = GetComponent<MeshFilter> ();
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		MeshCollider mc = GetComponent<MeshCollider> ();
		
		mf.mesh = mesh;
		mc.sharedMesh = mesh;
		Debug.Log ("Done Mesh!");
		
	}
	
	
	void builSingledMesh() {
		//Generate mesh data
		Vector3[] vertices = new Vector3[4];
		int[] triangles = new int[6];
		Vector3[] normals = new Vector3[4];
		Vector2[] uv = new Vector2[4];
		
		
		vertices [0] = new Vector3 (0, 0, 0);
		vertices [1] = new Vector3(1, 0, 0);
		vertices [2] = new Vector3 (0, 0, -1);
		vertices [3] = new Vector3 (1, 0, -1);
		
		triangles [0] = 0;
		triangles [1] = 3;
		triangles [2] = 2;
		triangles [3] = 0;
		triangles [4] = 1;
		triangles [5] = 3;
		
		normals [0] = Vector3.up;
		normals [1] = Vector3.up;
		normals [2] = Vector3.up;
		normals [3] = Vector3.up;
		
		uv [0] = new Vector3 (0, 1);
		uv [1] = new Vector3 (1, 1);
		uv [2] = new Vector3 (0, 0);
		uv [3] = new Vector3 (1, 0);
		
		//Create a new mesh and populate it
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;
		
		//Assign mesh to filter/renderer/collider
		MeshFilter mf = GetComponent<MeshFilter> ();
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		MeshCollider mc = GetComponent<MeshCollider> ();
		mf.mesh = mesh;
		
	}
	
	
	
}
