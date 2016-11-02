﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLength = 10.0f;
	private int amnTilesOnScreen = 7;
	private float safeZone = 15.0f;
	private int lastIndex = 0;

	private List<GameObject> activeTiles; 

	// Use this for initialization
	private void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < amnTilesOnScreen; i++) 
		{
			if(i<2)
				SpawnTile (0);
			else
				SpawnTile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z -safeZone > (spawnZ - amnTilesOnScreen * tileLength)) {
			SpawnTile ();
			DeleteTile ();
		}
	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		if(prefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}

	public void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

	//customize random index
	private int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
			return 0;
		int randomIndex = lastIndex;
		while (randomIndex == lastIndex) 
		{
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}
		lastIndex = randomIndex;
		return randomIndex;
	}
}