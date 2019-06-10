using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
        Cursor.visible = true;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
        Cursor.visible = false;
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
