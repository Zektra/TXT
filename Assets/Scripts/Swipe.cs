using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

         
        float start;
        float end;
        float nextActionTime;
        Renderer rend;
	// Use this for initialization
	void Start ()
        {
            resetSwipe();
            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
	}
	
	// Update is called once per frame
	void Update ()
        {
            if (Time.time >= nextActionTime)
            {
                rend.material.SetColor("_SpecColor", Color.red);
                ListenSwipe();
            }
	}

        void ListenSwipe()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                start = Input.mousePosition.x;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                end = Input.mousePosition.x;
            }
            if (end - start > 0 && start != 0 && end != 0)
            {
                rend.material.SetColor("_SpecColor", Color.black);
                resetSwipe();
            }
         }

        void resetSwipe()
        {
            start = 0;
            end = 0;
            nextActionTime = Time.time + Random.Range(1, 5);
        }
}
