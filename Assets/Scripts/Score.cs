using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

        int score, swipe, penalty;
        public Text countText;

	// Use this for initialization
	void Start ()
        {
            score = 0;
            penalty = 0;
	}
	
	// Update is called once per frame
	void Update ()
        {
            score = (int)GameObject.Find("FamilyCar").transform.position.x / 1000 + swipe - penalty;
            countText.text = "Score: " + score.ToString();    
	}

        public void ScoreUp()
        {
            swipe++;
        }
        
        public void ScoreDown()
        {
            penalty++;
        }
}
