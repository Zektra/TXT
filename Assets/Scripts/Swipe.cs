﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

         
        float start, end, nextActionTime;
        Renderer rend;
        int swipeDirection;
        public Texture CallScreen, CallScreen2, ScreenOff;
	// Use this for initialization
	void Start ()
        {
            resetSwipe();
            nextActionTime = Time.time + 30;
            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
	}
	
	// Update is called once per frame
	void Update ()
        {
            if (Time.time >= nextActionTime)
            {
                if(swipeDirection > 50)
                {
                    rend.material.SetTexture("_MainTex", CallScreen);
                    ListenSwipeRight();
                }
                else
                {
                    rend.material.SetTexture("_MainTex", CallScreen2);
                    ListenSwipeLeft();
                }
            }
	}

        void ListenSwipeRight()
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
                rend.material.SetTexture("_MainTex", ScreenOff);
                resetSwipe();
            }
         }

        void ListenSwipeLeft()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                start = Input.mousePosition.x;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                end = Input.mousePosition.x;
            }
            if (end - start < 0 && start != 0 && end != 0)
            {
                rend.material.SetTexture("_MainTex", ScreenOff);
                resetSwipe();
            }
         }

        void resetSwipe()
        {
            start = 0;
            end = 0;
            nextActionTime = Time.time + Random.Range(1, 5);
            setSwipeDirection();
        }

        void setSwipeDirection()
        {
            swipeDirection = Random.Range(1, 100);
        }
}
