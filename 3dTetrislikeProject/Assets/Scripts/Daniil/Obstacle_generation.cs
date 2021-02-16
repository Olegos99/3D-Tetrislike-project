using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_generation : MonoBehaviour
{
    //необходимые переменные
    int[,] obstacle_gird = new int[5, 5];
    int form;
    int str;
    int stlb;
    int cube = 1;
    GameObject now_cube;
    //-необходимые переменные

    void Start()
    {
        for (int strr = 0; strr != 5; strr++)
        {
            for (int stlbb = 0; stlbb != 5; stlbb++)
            {
                obstacle_gird[strr, stlbb] = 1;
            }
        }
        //какая будет форма?
        form = Random.Range(1, 5);
        //какая будет форма?

        //генерация в случае первой формы
        if (form == 1)
        {
            str = Random.Range(1, 5);
            stlb = Random.Range(0, 3);
            obstacle_gird[str, stlb] = 0;
            obstacle_gird[str, stlb + 1] = 0;
            obstacle_gird[str, stlb + 2] = 0;
            obstacle_gird[str - 1, stlb + 1] = 0;
        }
        //-генерация в случае первой формы

        //генерация в случае второй формы
        else if (form == 2)
        {
            str = Random.Range(0, 5);
            stlb = Random.Range(0, 2);
            obstacle_gird[str, stlb] = 0;
            obstacle_gird[str, stlb + 1] = 0;
            obstacle_gird[str, stlb + 2] = 0;
            obstacle_gird[str, stlb + 3] = 0;
        }
        //-генерация в случае второй формы

        //генерация в случае третьей формы
        else if (form == 3)
        {
            str = Random.Range(1, 5);
            stlb = Random.Range(0, 4);
            obstacle_gird[str, stlb] = 0;
            obstacle_gird[str, stlb + 1] = 0;
            obstacle_gird[str - 1, stlb + 1] = 0;
            obstacle_gird[str - 1, stlb] = 0;
        }
        //-генерация в случае третьей формы

        //генерация в случае четвёртой формы
        else if (form == 4)
        {
            str = Random.Range(2, 5);
            stlb = Random.Range(0, 4);
            obstacle_gird[str, stlb] = 0;
            obstacle_gird[str - 1, stlb] = 0;
            obstacle_gird[str - 2, stlb] = 0;
            obstacle_gird[str, stlb + 1] = 0;
        }
        //-генерация в случае четвёртой формы

        //расставляем кубики
        for (int str = 0; str != 5; str++)
        {
            for (int stlb = 0; stlb != 5; stlb++)
            {
                if (obstacle_gird[str, stlb] == 1)
                {
                    now_cube = gameObject.transform.Find("Obstacle Cube (" + cube + ")").gameObject;
                    now_cube.transform.position = new Vector3(stlb - 2, 5 - str, 70);
                    cube++;
                }
            }
        }
        //-расставляем кубики
    }
}
