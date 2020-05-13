using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void PlayGame()     
    {
        SceneManager.LoadScene("GAME");
    }

    public void OptionsMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
