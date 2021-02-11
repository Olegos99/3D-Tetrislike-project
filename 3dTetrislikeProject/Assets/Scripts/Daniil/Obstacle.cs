using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //необходимые переменные
    int[,] obstacle_gird = new int[5, 5];
    int form;
    int str;
    int stlb;
    int cube = 1;
    bool if_copied = false;
    bool if_cheked = false;
    public GameObject player;

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
        gameObject.transform.position = new Vector3(0,0, 70f);
        //какая будет форма?
        form = Random.Range(1, 5);
        //какая будет форма?

        //генерация в случае первой формы
        if (form == 1)
        {
            str = Random.Range(1, 5);
            stlb = Random.Range(0, 3);
            obstacle_gird[str, stlb] = 0;
            obstacle_gird[str, stlb+1] = 0;
            obstacle_gird[str, stlb+2] = 0;
            obstacle_gird[str-1, stlb+1] = 0;
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
            obstacle_gird[str-1, stlb + 1] = 0;
            obstacle_gird[str - 1, stlb] = 0;
        }
        //-генерация в случае третьей формы

        //генерация в случае четвёртой формы
        else if (form == 4)
        {
            str = Random.Range(2, 5);
            stlb = Random.Range(0, 4);
            obstacle_gird[str, stlb] = 0;
            obstacle_gird[str-1, stlb] = 0;
            obstacle_gird[str-2, stlb] = 0;
            obstacle_gird[str, stlb + 1] = 0;
        }
        //-генерация в случае четвёртой формы

        //расставляем кубики
        for(int str =0; str!=5; str++) 
        {
            for(int stlb=0; stlb!=5; stlb++)
            {
                if (obstacle_gird[str, stlb] == 1)
                {
                    now_cube = gameObject.transform.Find("Obstacle Cube (" + cube + ")").gameObject;
                    now_cube.transform.position = new Vector3(stlb - 2, 5 - str,70);
                    cube++;
                }
            }
        }
        //-расставляем кубики
    }

    //управляем движением и задаём условия самокопирования, самоуничтожения и проверки на прохождение
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0, -0.1f);
        if (gameObject.transform.position.z < 40 && if_copied==false)
        {
            Instantiate(gameObject);
            if_copied = true;
        }
        if(gameObject.transform.position.z < -5 && gameObject.transform.position.z > -7)
        {
            for (int strr=0; strr!=5; strr++)
            {
                for(int stlbb=0; stlbb!=5; stlbb++)
                {
                    if (obstacle_gird[strr, stlbb] == player.GetComponent<Player_matrix>().player_gird[strr, stlbb])
                    {
                        Debug.Log("fail");
                    }
                }
            }
        }
        if (gameObject.transform.position.z < -7 && if_cheked==false)
        {
            Debug.Log("passed");
            if_cheked = true;
        }
        if (gameObject.transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
    //-управляем движением и задаём условия самокопирования, самоуничтожения и проверки на прохождение

}
