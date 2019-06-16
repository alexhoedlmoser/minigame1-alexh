using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int scoreValue;
    private string scoreKey = "Score";
    private string highscoreKey = "Highscore";
    private TextMeshProUGUI scoreGui;
    private string scoreGuiName = "ScoreGUI";
    public TextMeshProUGUI scoreGuiEnd;
    public TextMeshProUGUI highscoreGuiEnd;
    private SceneLoader sceneLoader;
    private int currentSceneIndex;
    private string sceneLoaderName = "SceneLoader";
    
    void Start()
    {
        scoreValue = 0;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 1)
        {
            scoreGui = GameObject.Find(scoreGuiName).GetComponent<TextMeshProUGUI>();
        }

        sceneLoader = GameObject.Find(sceneLoaderName).GetComponent<SceneLoader>();

        highscoreGuiEnd.text = "Your Highscore: " + PlayerPrefs.GetInt(highscoreKey, 0).ToString();
        scoreGuiEnd.text = "Your Score: " + PlayerPrefs.GetInt(scoreKey, 0).ToString();

        PlayerPrefs.Save();
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
        PlayerPrefs.SetInt(scoreKey, scoreValue);

        if (scoreValue > PlayerPrefs.GetInt(highscoreKey, 0))
        {
            PlayerPrefs.SetInt(highscoreKey, scoreValue);
        }

        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        scoreGuiEnd.text = "Your Score: " + PlayerPrefs.GetInt(scoreKey, 0).ToString();
        Debug.Log(PlayerPrefs.GetInt(scoreKey, 0).ToString());
        highscoreGuiEnd.text = "Your Highscore: " + PlayerPrefs.GetInt(highscoreKey, 0).ToString();
        Debug.Log(PlayerPrefs.GetInt(highscoreKey, 0).ToString());

        sceneLoader.LoadEndScene();

        PlayerPrefs.Save();
    }

    public void ResetScores()
    {
        PlayerPrefs.SetInt(highscoreKey, 0);
        PlayerPrefs.SetInt(scoreKey, 0);
        highscoreGuiEnd.text = "Your Highscore: " + PlayerPrefs.GetInt(highscoreKey, 0).ToString();
        scoreGuiEnd.text = "Your Score: " + PlayerPrefs.GetInt(scoreKey, 0).ToString();
    }

}


