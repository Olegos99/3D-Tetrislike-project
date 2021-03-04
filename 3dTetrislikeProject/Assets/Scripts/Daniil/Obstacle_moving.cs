using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_moving : MonoBehaviour
{
    //*скрипт управляет движением отдельного препятствия*
    public float speed;
    //задаёт стартовую позицию
    void Start()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, 45);
    }
    //-задаёт стартовую позицию

    //управляет движением
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0, -0.1f*speed);
        if (speed < 5 && gameObject.transform.position.z < -7)
        {
            speed+=0.3f;
        }
    }
    //-управляет движением
}
