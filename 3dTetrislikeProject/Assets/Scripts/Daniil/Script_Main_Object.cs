using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Main_Object : MonoBehaviour
{
    int position = 1;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;

    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (position != 4)
            {
                position++;
            }
            else
            {
                position = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (position != 1)
            {
                position--;
            }
            else
            {
                position = 4;
            }
        }
        

        if (position == 1)
        {
            cube1.SetActive(true);
            cube2.SetActive(false);
            cube3.SetActive(false);
            cube4.SetActive(false);
        }
        else if (position == 2)
        {
            cube1.SetActive(false);
            cube2.SetActive(true);
            cube3.SetActive(false);
            cube4.SetActive(false);
        }
        else if (position == 3)
        {
            cube1.SetActive(false);
            cube2.SetActive(false);
            cube3.SetActive(true);
            cube4.SetActive(false);
        }
        else if (position == 4)
        {
            cube1.SetActive(false);
            cube2.SetActive(false);
            cube3.SetActive(false);
            cube4.SetActive(true);
        }

    




      
    }
}
