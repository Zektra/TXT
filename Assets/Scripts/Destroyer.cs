using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

        public Level _Level;

        void Start()
        {
             _Level = GameObject.FindObjectOfType(typeof(Level)) as Level;
        }

        void Update()
        {
            if(_Level.DestroyerMove)
            {
                transform.Translate(100, 0, 0);
                _Level.DestroyerMove = false;
            }
        }

	void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.transform.parent)
            {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
}
