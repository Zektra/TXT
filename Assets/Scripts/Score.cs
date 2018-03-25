using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

        int score, swipe, penalty;
        public Text countText;
        public GameObject Car;
        private WheelDrive _WheelDrive;

	// Use this for initialization
	void Start ()
        {
            score = 0;
            penalty = 0;
            _WheelDrive = Car.GetComponent<WheelDrive>();
	}
	
	// Update is called once per frame
	void Update ()
        {
            score = (int)GameObject.Find("FamilyCar").transform.position.x / 60 + swipe - penalty;
            countText.text = "Score: " + score.ToString();    
	}

        public void ScoreUp()
        {
            swipe+= 5;
        }
        
        public void ScoreDown()
        {
            penalty-= 5;
            // Punishment to be fixed
            Car.GetComponent<Rigidbody>().AddForce(Vector3.left * 100000);
        }
}
