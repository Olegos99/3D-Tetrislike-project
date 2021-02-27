using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_visualisation : MonoBehaviour
{
    // *Скрипт отвечает за визуализацию подсчёта очков. Вешается на тот же скрипт, что и "Score_counting"*
    int Total_score = 0;
    int ten=0;
    int hundred = 0;
    public bool Add_score = false;
    public Material On;
    public Material Off;
    GameObject [] cubes=new GameObject[7];

    //Метод, задающей нужной цифре нужную визуализацию
    void Vis_number(int number, int wich_numer)
    {
        GameObject numer = gameObject.transform.Find("8(V002) "+wich_numer).gameObject;
        cubes[0] = numer.transform.Find("Cube.02356789").gameObject;
        cubes[1] = numer.transform.Find("Cube.0235689").gameObject;
        cubes[2] = numer.transform.Find("Cube.0268").gameObject;
        cubes[3] = numer.transform.Find("Cube.013456789").gameObject;
        cubes[4] = numer.transform.Find("Cube.045689").gameObject;
        cubes[5] = numer.transform.Find("Cube.01234789").gameObject;
        cubes[6] = numer.transform.Find("Cube.2345689").gameObject;
        for(int x=0; x!=7; x++)
        {
            if (cubes[x].name.Contains(number.ToString()))
            {
                cubes[x].GetComponent<Renderer>().material = On;
            }
            else 
            {
                cubes[x].GetComponent<Renderer>().material = Off;
            }
        }

    }
    //-Метод, задающей нужной цифре нужную визуализацию

    //Задаёт стартовую визуализацию (все на нолики)
    void Start()
    {
        Vis_number(0, 1);
        Vis_number(0, 2);
        Vis_number(0, 3);
    }
    //-Задаёт стартовую визуализацию (все на нолики)

    //Если получен приказ из скрипта "Score_counting", добавляет очко и вызывает метод "Vis_number" 
    void Update()
    {
        if (Add_score)
        {
            Add_score = false;
            Total_score++;
            ten++;
            hundred++;
            Vis_number(Total_score % 10,1);
            if (ten == 10)
            {
                ten = 0;
                Vis_number((Total_score % 100 - Total_score % 10)/10,2);
            }
            if (hundred == 100)
            {
                hundred = 0;
                Vis_number(Total_score - Total_score % 10 - Total_score % 100,3);
            }
            Debug.Log(Total_score);
        }
    }
    //-Если получен приказ из скрипта "Score_counting", добавляет очко и вызывает метод "Vis_number" 
}
