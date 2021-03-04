using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_manager : MonoBehaviour
{
    //*скрипт управляет препятствиями, создаёт и уничтожает их, а так же содержит публичные переменные дистанции между препятствиями и их скорости*
    //задаёт необходимые переменные
    public float obstacles_speed;
    public float obstacles_distance;
    public GameObject obstacle;
    int max_obstacle_number = 1;
    int min_obstacle_number = 1;
    //-задаёт необходимые переменные

    //создаёт первый объект

    void OnEnable()
    {
        Instantiate(obstacle,transform).name = "Obstacle_" + max_obstacle_number; 
        GameObject.Find("Obstacle_" + max_obstacle_number).GetComponent<Obstacle_moving>().speed = obstacles_speed;
    }
    //-создаёт первый объект
    void Update()
    {
        //при наличии триггера создаёт новое препятствие
        if (GameObject.Find("Obstacle_" + max_obstacle_number).transform.position.z <45- obstacles_distance)
        {
            max_obstacle_number++;
            Instantiate(obstacle,transform).name = "Obstacle_" + max_obstacle_number;
            GameObject.Find("Obstacle_" + max_obstacle_number).GetComponent<Obstacle_moving>().speed = obstacles_speed;
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
