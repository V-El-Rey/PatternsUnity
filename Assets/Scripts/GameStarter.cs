using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStarter 
{
    public static void StartGame()
    {
        GameObject.FindGameObjectWithTag("UI").SetActive(false);
        GameObject.FindObjectOfType<GameController>().GetComponent<GameController>().enabled = true;
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
