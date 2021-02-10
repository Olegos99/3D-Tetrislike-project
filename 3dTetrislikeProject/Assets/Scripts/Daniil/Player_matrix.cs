using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_matrix : MonoBehaviour
{
    //объявляем необходимые переменные и метод расстановки
    int cube = 1;
    int form = 1;
    int[,] player_gird = new int[5, 5];
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject[] cubes;
    static void Set_Position(int[,] player_gird, GameObject cube1, GameObject cube2, GameObject cube3, GameObject cube4 )
    {
        int cube = 1;
        for (int str = 0; str != 5; str++)
        {
            for (int stlb = 0; stlb != 5; stlb++)
            {
                if (player_gird[str, stlb] == 1)
                {
                    if (cube == 1)
                    {
                        cube1.transform.position = new Vector3(stlb - 2, 5 - str);
                        cube = 2;
                    }
                    else if (cube == 2)
                    {
                        cube2.transform.position = new Vector3(stlb - 2, 5 - str);
                        cube = 3;
                    }
                    else if (cube == 3)
                    {
                        cube3.transform.position = new Vector3(stlb - 2, 5 - str);
                        cube = 4;
                    }
                    else if (cube == 4)
                    {
                        cube = 1;
                        cube4.transform.position = new Vector3(stlb - 2, 5 - str);
                    }

                }
            }
        }
    }
    //-объявляем необходимые переменные и метод расстановки

    void Start()
    {

        //генератор сетки игрока
        foreach (int k in player_gird)
        {
            player_gird[k, k] = 0;
        }
        player_gird[1, 2] = 1;
        player_gird[2, 1] = 1;
        player_gird[2, 2] = 1;
        player_gird[2, 3] = 1;
        Set_Position(player_gird: player_gird, cube1: cube1, cube2: cube2, cube3: cube3, cube4: cube4);
        //-генератор сетки игрока
    }

    void Update()
    {


        //движение вверх
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bool chek_up = true;
            for (int x = 0; x != 5; x++)
            {
                if (player_gird[0, x] == 1)
                {
                    chek_up = false;
                }
            }
            if (chek_up)
            {
                for (int str = 0; str != 4; str++)
                {
                    for (int stlb = 0; stlb != 5; stlb++)
                    {
                        player_gird[str, stlb] = player_gird[str + 1, stlb];
                    }
                }
                for (int stlb = 0; stlb != 5; stlb++)
                {
                    player_gird[4, stlb] = 0;
                }
                Set_Position(player_gird: player_gird, cube1: cube1, cube2: cube2, cube3: cube3, cube4: cube4);

            }
            
        }

        //-движение вверх
        //движение вниз


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool chek_down = true;
            for (int x = 0; x != 5; x++)
            {
                if (player_gird[4, x] == 1)
                {
                    chek_down = false;
                }
            }
            if (chek_down)
            {
                for (int str = 4; str != 0; str--)
                {
                    for (int stlb = 0; stlb != 5; stlb++)
                    {
                        player_gird[str, stlb] = player_gird[str - 1, stlb];
                    }
                }
                for (int stlb = 0; stlb != 5; stlb++)
                {
                    player_gird[0, stlb] = 0;
                }
                Set_Position(player_gird: player_gird, cube1: cube1, cube2: cube2, cube3: cube3, cube4: cube4);
            }
            
        }
        //-движение вниз
        //движение влево

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bool chek_left = true;
            for (int x = 0; x != 5; x++)
            {
                if (player_gird[x, 0] == 1)
                {
                    chek_left = false;
                }
            }
            if (chek_left)
            {
                for (int stlb = 0; stlb != 4; stlb++)
                {
                    for (int str = 0; str != 5; str++)
                    {
                        player_gird[str, stlb] = player_gird[str, stlb + 1];
                    }
                }
                for (int str = 0; str != 5; str++)
                {
                    player_gird[str, 4] = 0;
                }
                Set_Position(player_gird: player_gird, cube1: cube1, cube2: cube2, cube3: cube3, cube4: cube4);
            }
            
        }

        //-движение влево
        //движение вправо
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bool chek_right = true;
            for (int x = 0; x != 5; x++)
            {
                if (player_gird[x, 4] == 1)
                {
                    chek_right = false;
                }
            }
            if (chek_right)
            {
                for (int stlb = 4; stlb != 0; stlb--)
                {
                    for (int str = 0; str != 5; str++)
                    {
                        player_gird[str, stlb] = player_gird[str, stlb - 1];
                    }
                }
                for (int str = 0; str != 5; str++)
                {
                    player_gird[str, 0] = 0;
                }
                Set_Position(player_gird: player_gird, cube1: cube1, cube2: cube2, cube3: cube3, cube4: cube4);

            }
        }

        //-движение вправо


        //смена формы 

        if (Input.GetKeyDown(KeyCode.E))
        {
            //смена формы 1-2
            if (form == 1)
            {
                form = 2;
                bool chek_1to2 = true;
                for (int str = 0; str != 5; str++)
                {
                    if (player_gird[str, 4] == 1)
                    {
                        chek_1to2 = false;
                    }
                }
                if (chek_1to2 == true)
                {
                    for (int str = 0; str != 5; str++)
                    {
                        for (int stlb = 1; stlb != 4; stlb++)
                        {
                            if (player_gird[str, stlb] == 1 && player_gird[str, stlb - 1] == 0 && player_gird[str, stlb + 1] == 0)
                            {
                                player_gird[str, stlb] = 0;
                                player_gird[str + 1, stlb + 2] = 1;
                            }
                        }
                    }

                }
                if (chek_1to2 == false)
                {
                    for (int str = 0; str != 5; str++)
                    {

                        if (player_gird[str, 3] == 1 && player_gird[str, 2] == 0 && player_gird[str, 4] == 0)
                        {
                            player_gird[str, 3] = 0;
                            player_gird[str + 1, 1] = 1;
                        }

                    }
                }
            }
            //-смена формы 1-2
            //Cмена формы 2-3
            else if (form == 2)
            {
                form = 3;
                bool chek_2to3 = true;
                for (int stlb = 0; stlb != 5; stlb++)
                {
                    if (player_gird[0, stlb] == 1)
                    {
                        chek_2to3 = false;
                    }

                }
                if (chek_2to3 == true)
                {
                    for (int str = 1; str != 5; str++)
                    {
                        for (int stlb = 0; stlb != 2; stlb++)
                        {
                            if (player_gird[str, stlb] == 1 && player_gird[str, stlb + 1] == 1 && player_gird[str, stlb + 2] == 1 && player_gird[str, stlb + 3] == 1)
                            {
                                player_gird[str, stlb] = 0;
                                player_gird[str, stlb + 3] = 0;
                                player_gird[str - 1, stlb + 1] = 1;
                                player_gird[str - 1, stlb + 2] = 1;
                            }
                        }
                    }
                }
                if (chek_2to3 == false)
                {

                    for (int stlb = 0; stlb != 2; stlb++)
                    {
                        if (player_gird[0, stlb] == 1 && player_gird[0, stlb + 1] == 1 && player_gird[0, stlb + 2] == 1 && player_gird[0, stlb + 3] == 1)
                        {
                            player_gird[0, stlb] = 0;
                            player_gird[0, stlb + 3] = 0;
                            player_gird[1, stlb + 1] = 1;
                            player_gird[1, stlb + 2] = 1;
                        }
                    }

                }
            }

            //-смена формы 2-3
            //смена формы 3-4
            else if (form == 3)
            {
                form = 4;
                bool chek_3to4 = true;
                for (int stlb = 0; stlb != 5; stlb++)
                {
                    if (player_gird[0, stlb] == 1)
                    {
                        chek_3to4 = false;
                    }
                }
                if (chek_3to4 == true)
                {
                    for (int str = 1; str != 4; str++)
                    {
                        for (int stlb = 1; stlb != 5; stlb++)
                        {
                            if (player_gird[str, stlb] == 1 && player_gird[str + 1, stlb] == 1 && player_gird[str, stlb - 1] == 1)
                            {
                                player_gird[str, stlb] = 0;
                                player_gird[str - 1, stlb - 1] = 1;
                            }
                        }
                    }
                }
                if (chek_3to4 == false)
                {
                    for (int stlb = 1; stlb != 5; stlb++)
                    {
                        if (player_gird[0, stlb] == 1 && player_gird[0, stlb - 1] == 1 && player_gird[1, stlb] == 1)
                        {
                            player_gird[0, stlb] = 0;
                            player_gird[1, stlb] = 0;
                            player_gird[2, stlb - 1] = 1;
                            player_gird[2, stlb] = 1;
                        }
                    }
                }
            }
            //-смена формы 3-4
            //смена формы 4-1
            else if (form == 4)
            {
                form = 1;
                bool chek_4to1 = true;
                for (int str = 0; str != 5; str++)
                {
                    if (player_gird[str, 0] == 1)
                    {
                        chek_4to1 = false;
                    }
                }
                if (chek_4to1 == true)
                {
                    for (int str = 0; str != 3; str++)
                    {
                        for (int stlb = 1; stlb != 5; stlb++)
                        {
                            if (player_gird[str, stlb] == 1 && player_gird[str + 1, stlb] == 1 && player_gird[str + 2, stlb] == 1)
                            {
                                player_gird[str, stlb] = 0;
                                player_gird[str + 2, stlb - 1] = 1;
                            }
                        }
                    }
                }
                if (chek_4to1 == false)
                {
                    for (int str = 0; str != 3; str++)
                    {
                        if (player_gird[str, 0] == 1 && player_gird[str + 1, 0] == 1 && player_gird[str + 2, 0] == 1)
                        {
                            player_gird[str, 0] = 0;
                            player_gird[str + 1, 0] = 0;
                            player_gird[str + 1, 1] = 1;
                            player_gird[str + 2, 2] = 1;
                        }
                    }
                }
            }
            Set_Position(player_gird: player_gird, cube1: cube1, cube2: cube2, cube3: cube3, cube4: cube4);

            //-смена формы 4-1

        }

        
        
    }
}
