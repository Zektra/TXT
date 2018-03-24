using System.Collections;
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
        if(roadCount < 3)
        {
            GameObject clone = Instantiate(_myPrefabs[0]) as GameObject;
            clone.transform.position = new Vector3(60 * roadCount, 0, 0);
        }
        else
        {
            GameObject clone = Instantiate(_myPrefabs[RandomNumber()]) as GameObject;
            clone.transform.position = new Vector3(60 * roadCount, 0, 0);
        }
        roadCount++;
        DestroyerMove = true;
    }

    int RandomNumber()
    {
        System.Random rand = new System.Random();
        return rand.Next(0,_myPrefabs.Length);
    }
}
