using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Speed : MonoBehaviour
{
    public float speed = 0;
    public float speedOld = 0;
    public float nextActionTime;
    Vector3 lastPosition = Vector3.zero;

    void Start()
    {
        nextActionTime = Time.time + 10;
    }

    void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        if(speed > speedOld && Time.time > nextActionTime)
        {
            speedOld = speed;
        }
        if(speedOld - 0.09 > speed)
        {
            Application.LoadLevel("GameOver");
        }
    }

}