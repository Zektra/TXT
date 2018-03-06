using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour {

        public Level _Level;

        void Start()
        {
             _Level = GameObject.FindObjectOfType(typeof(Level)) as Level;
        }

	void OnTriggerEnter(Collider other)
        {
             _Level.CreatePrefab();
        }
}
