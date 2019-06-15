using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue;
    [SerializeField] ScoreData scoreData;
    private TextMeshProUGUI scoreGui;
    [SerializeField] TextMeshProUGUI scoreGuiEnd;
    [SerializeField] TextMeshProUGUI highscoreGuiEnd;
    private SceneLoader sceneLoader;
    private int currentSceneIndex;
    private string sceneLoaderName = "SceneLoader";
    private string scoreGuiName = "ScoreGUI";

    void Awake()
    {
        scoreValue = 0;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 1)
        {
            scoreGui = GameObject.Find(scoreGuiName).GetComponent<TextMeshProUGUI>();
        }

        sceneLoader = GameObject.Find(sceneLoaderName).GetComponent<SceneLoader>();
    }

    void Update()
    {
        if (scoreValue < 0)
        {
            scoreValue = 0;
        }

        if (currentSceneIndex == 1)
        {
            scoreGui.text = "Score: " + scoreValue;
        }
    }

    public void SaveScore()
    {
        scoreData.value = scoreValue;

        if (scoreValue > scoreData.highestValue)
        {
            scoreData.highestValue = scoreValue;
        }
    }

    public void LoadScore()
    {
        scoreGuiEnd.text = "Your Score: " + scoreData.value.ToString();
        highscoreGuiEnd.text = "Your Highscore: " + scoreData.highestValue.ToString();

        sceneLoader.LoadEndScene();
    }
}
