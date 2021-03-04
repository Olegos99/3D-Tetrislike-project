using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_functioning_manager : MonoBehaviour
{
    //*скрипт позволяет начать игру активировав объекты, закончить игру дезактивировав объекты и запаузить игру дезактивировав скрипты*
    GameObject Main_object_player;
    GameObject Obstacles_manager;
    GameObject TrikyUI;
    bool game_status = false;
    bool paused = false;
    public bool crash = false;


    //на старте задаёт значения переменным объектов и дизактивит их
    void Start()
    {
        Obstacles_manager = GameObject.Find("Obstacles_manager");
        for (int x = Obstacles_manager.transform.childCount; x != 0; x--)
        {
            Destroy(Obstacles_manager.transform.GetChild(x - 1).gameObject);
        }
        Obstacles_manager.SetActive(false);
        Main_object_player = GameObject.Find("Main_object_player");
        Main_object_player.GetComponent<Player_matrix>().enabled = false;
        TrikyUI = GameObject.Find("TrikyUI");
        TrikyUI.GetComponent<Score_counting>().enabled = false;
        TrikyUI.GetComponent<Score_visualisation>().enabled = false;
    }
    //-на старте задаёт значения переменным объектов и дизактивит их


    void Update()
    {
        //функция старта игры
        if (Input.GetKeyDown(KeyCode.O)&&game_status==false)
        {
            Main_object_player.GetComponent<Player_matrix>().enabled = true;
            Obstacles_manager.SetActive(true);
            TrikyUI.GetComponent<Score_counting>().enabled = true;
            TrikyUI.GetComponent<Score_visualisation>().enabled = true;
            game_status = true;
        }
        //-функция старта игры

        //функция паузы
        if (Input.GetKeyDown(KeyCode.P) && game_status != false)
        {
            Main_object_player.GetComponent<Player_matrix>().enabled = paused;
            for (int x = Obstacles_manager.transform.childCount; x != 0; x--)
            {
                Obstacles_manager.transform.GetChild(x - 1).GetComponent<Obstacle_moving>().enabled = paused;
            }
            paused = !paused;
        }
        //-функция паузы

        //функция поражения
        if (crash)
        {
            Main_object_player.GetComponent<Player_matrix>().enabled = false;
            for (int x = Obstacles_manager.transform.childCount; x != 0; x--)
            {
                Destroy(Obstacles_manager.transform.GetChild(x - 1).gameObject);
            }
            Obstacles_manager.SetActive(false);
            TrikyUI.GetComponent<Score_counting>().enabled = false;
            TrikyUI.GetComponent<Score_visualisation>().enabled = false;
            game_status = false;
            crash = false;
        }
        //-функция поражения
    }
}
