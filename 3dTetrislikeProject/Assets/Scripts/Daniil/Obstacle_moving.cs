using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_moving : MonoBehaviour
{
    public int speed;

    //задаёт стартовую позицию
    void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, 70f);
    }
    //-задаёт стартовую позицию

    //управляет движением
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0, -0.1f*speed);
        if (speed!=5&&gameObject.transform.position.z < -7)
        {
            speed = 5;
        }
    }
    //-управляет движением
}
