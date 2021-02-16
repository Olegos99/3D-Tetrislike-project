using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_manager : MonoBehaviour
{
    //задаёт необходимые переменные
    public int obstacles_speed;
    public int obstacles_distance;
    public GameObject obstacle;
    public int max_obstacle_number = 1;
    int min_obstacle_number = 1;
    bool hui = true;
    //-задаёт необходимые переменные

    //создаёт первый объект
    void Start()
    {
        Instantiate(obstacle).name= "Obstacle_" + max_obstacle_number;
        GameObject.Find("Obstacle_" + max_obstacle_number).GetComponent<Obstacle_moving>().speed = obstacles_speed;
    }
    //-создаёт первый объект
    void Update()
    {
        //при наличии триггера создаёт новое препятствие
        if (GameObject.Find("Obstacle_" + max_obstacle_number).transform.position.z<70f- obstacles_distance&&hui)
        {
            hui = false;
            max_obstacle_number++;
            Instantiate(obstacle).name = "Obstacle_" + max_obstacle_number;
            GameObject.Find("Obstacle_" + max_obstacle_number).GetComponent<Obstacle_moving>().speed = obstacles_speed;
            hui = true;
        }
        //-при наличии триггера создаёт новое препятствие

        //при наличии триггера уничтожает старейшее препятствие
        if (GameObject.Find("Obstacle_" + min_obstacle_number).transform.position.z < -20f)
        {
            Destroy(GameObject.Find("Obstacle_" + min_obstacle_number));
            min_obstacle_number++;
        }
        //-при наличии триггера уничтожает старейшее препятствие

    }
}
