using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private bool gameEnded = false;



    private void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (PlayerStats.Lives<=0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("GameEnd");
    }
}
