using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLook : MonoBehaviour {

        public Animator anim;
        bool look;

	// Use this for initialization
	void Start () {
            look = true;
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown("s") && look == true)
            {
                anim.Play("LookDown");
                look = false;
            }
            if(Input.GetKeyDown("w") && look == false)
            {
                anim.Play("LookUp");
                look = true;
            }
	}
}
