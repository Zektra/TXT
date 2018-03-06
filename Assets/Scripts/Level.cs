﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

public GameObject[] _myPrefabs;
public int renderDistance;
public int roadCount = 0;
public bool DestroyerMove = false;

    void Start()
    {
        for(int i = 0; i < renderDistance; i++)
        {
            CreatePrefab();
        }
    }

    public void CreatePrefab()
    {
        GameObject clone = Instantiate(_myPrefabs[RandomNumber()]) as GameObject;
        clone.transform.position = new Vector3(100 * roadCount, 0, 0);
        roadCount++;
        DestroyerMove = true;
    }

    int RandomNumber()
    {
        System.Random rand = new System.Random();
        return rand.Next(0,_myPrefabs.Length);
    }
}