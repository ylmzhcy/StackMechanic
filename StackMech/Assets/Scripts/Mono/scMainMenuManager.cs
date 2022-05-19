using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scMainMenuManager : MonoBehaviour
{
    public void BtnStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnExitGame()
    {
        Application.Quit();
    }
}
