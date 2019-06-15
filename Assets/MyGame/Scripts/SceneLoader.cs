using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadIntroScene()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(2);
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
