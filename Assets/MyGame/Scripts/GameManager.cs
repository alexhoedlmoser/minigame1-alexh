using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public ScoreData scoreData;
    public TextMeshProUGUI scoreGuiEnd;
    public TextMeshProUGUI highscoreGuiEnd;

    public void SaveScore()
    {
        scoreData.value = ScoreManager.scoreValue;

        if (ScoreManager.scoreValue > scoreData.highestValue)
        {
            scoreData.highestValue = ScoreManager.scoreValue;
        }
    }

    public void LoadEnd()
    {
        scoreGuiEnd.text = "Your Score: " + scoreData.value.ToString();
        highscoreGuiEnd.text = "Your Highscore: " + scoreData.highestValue.ToString();

        sceneLoader.LoadEndScene();
    }
}

