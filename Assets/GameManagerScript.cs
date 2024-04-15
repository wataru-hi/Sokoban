using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map = { 0, 2, 0, 2, 0, 0, 0, 1, 0, 0, 2, 0, 2, 0, 0, };
    string debugText = "";

    // Start is called before the first frame update
    void Start()
    {
        printArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            int playerIndex = -1;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }
            
           MoveNomber(1, playerIndex, playerIndex + 1);

            printArray();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            int playerIndex = -1;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            MoveNomber(1, playerIndex, playerIndex - 1);

            printArray();
        }


    }
    void printArray()
    {
        debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";

            Debug.Log(debugText);

        }
    }

    bool MoveNomber(int number,int moveFrom, int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length){return false;}

        if (map[moveTo] == 2) 
        {
            int velocity = moveTo - moveFrom;
            bool success = MoveNomber(2, moveTo, moveTo + velocity);

            if (!success) { return false; }
        }

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

}
