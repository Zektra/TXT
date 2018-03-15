using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour {

	bool isHit = false;

        public Level _Level;

        void Start()
        {
             _Level = GameObject.FindObjectOfType(typeof(Level)) as Level;
        }

	void OnTriggerEnter(Collider other)
        {
            if(!isHit)
            {
                _Level.CreatePrefab();
                isHit = true;
            }
        }
}
