using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public void doExitGame()
    {
        Application.Quit();
    }
    public void PlayPressed()
    {
        SceneManager.LoadScene("1");
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("Main_menu");
        Debug.Log("SHIT");
    }
}
