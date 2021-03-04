using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_counting : MonoBehaviour
{
    //*скрипт меняет переменную в скрипте "Score_visualisation" при прохождении препятствия и проверяет, не врезался ли игрок. вешается на тот же объект, что и "Score_visualisation"*
    //задаёт переменные и их значенния
    GameObject max_obstacle;
    GameObject player;
    GameObject Game_functioning_manager;
    int[,] player_gird;
    int[,] max_obstacle_gird;
    int max_obstacle_number = 1;
    void OnEnable()
    {
        max_obstacle =GameObject.Find("Obstacle_" + max_obstacle_number);
        player = GameObject.Find("Main_object_player");
        Game_functioning_manager = GameObject.Find("Game_functioning_manager");
    }
    //-задаёт переменные и их значенния

    //в случае прохождения игроком препятствия назначает в переменную "max_obstacle" следующее препятствие и добавляет очко. В случае поражения меняет переменную в "Game_functioning_manager"
    void Update()
    {
        if (max_obstacle.transform.position.z < -6.5)
        {
            player_gird = player.GetComponent<Player_matrix>().player_gird;
            max_obstacle_gird = max_obstacle.GetComponent<Obstacle_generation>().obstacle_gird;
            for (int str=0; str!=5; str++)
            {
                for(int stlb=0; stlb!=5; stlb++)
                {
                    if (player_gird[str, stlb] == max_obstacle_gird[str, stlb])
                    {
                        Game_functioning_manager.GetComponent<Game_functioning_manager>().crash = true;
                    }
                }
            }
            max_obstacle_number++;
            max_obstacle = GameObject.Find("Obstacle_" + max_obstacle_number);
            gameObject.GetComponent<Score_visualisation>().Add_score=true;
        }
    }
    //-в случае прохождения игроком препятствия назначает в переменную "max_obstacle" следующее препятствие и добавляет очко. В случае поражения меняет переменную в "Game_functioning_manager"
}
