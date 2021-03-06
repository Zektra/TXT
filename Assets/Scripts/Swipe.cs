﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

        Score score;
        float start, end, nextActionTime;
        Renderer rend;
        public AudioSource audio;
        int swipeDirection;
        public Texture CallScreen, CallScreen2, ScreenOff;
        bool wrongDirection, mouseDown;
        public AudioClip ringtone;
	// Use this for initialization
	void Start ()
        {
            resetSwipe();
            nextActionTime = Time.time + 30;
            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            score = GameObject.FindObjectOfType(typeof(Score)) as Score;
            wrongDirection = false;
	}
	
	// Update is called once per frame
	void Update ()
        {
            if (Time.time >= nextActionTime)
            {
                if(!audio.isPlaying)
                {
                    audio.clip = ringtone;
                    audio.Play();
                }
                if(swipeDirection > 50)
                {
                    rend.material.SetTexture("_MainTex", CallScreen);
                    if (ListenSwipe() == "right")
                    {
                        rend.material.SetTexture("_MainTex", ScreenOff);
                        resetSwipe();
                        score.ScoreUp();
                        wrongDirection = false;
                    }
                    if (ListenSwipe() == "left" && wrongDirection != true)
                    {
                        score.ScoreDown();
                        wrongDirection = true;
                    }
                }
                else
                {
                    rend.material.SetTexture("_MainTex", CallScreen2);
                    if (ListenSwipe() == "left")
                    {
                        rend.material.SetTexture("_MainTex", ScreenOff);
                        resetSwipe();
                        score.ScoreUp();
                        wrongDirection = false;
                    }
                    if (ListenSwipe() == "right" && wrongDirection != true)
                    {
                        score.ScoreDown();
                        wrongDirection = true;
                    }
                }
            }
	}

        string ListenSwipe()
        {
            if (Input.GetButtonDown("Fire1") && mouseDown != true)
            {
                start = Input.mousePosition.x;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                end = Input.mousePosition.x;
                mouseDown = false;
            }
            if (end > start && start != 0 && end != 0)
            {
                return "right";
            }
            if (end < start && start != 0 && end != 0)
            {
                 return "left";
            }
            return "none";
         }

        void resetSwipe()
        {
            start = 0;
            end = 0;
            nextActionTime = Time.time + Random.Range(5, 10);
            setSwipeDirection();
            if(audio.isPlaying)
            {
                audio.Stop();
            }
        }

        void setSwipeDirection()
        {
            swipeDirection = Random.Range(1, 100);
        }
}
