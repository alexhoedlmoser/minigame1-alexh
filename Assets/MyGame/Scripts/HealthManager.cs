using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static int healthValue;
    private TextMeshProUGUI healthGui;
    private ScoreManager scoreManager;
    private string scoreManagerName = "ScoreManager";

    private GameObject heart1;
    private string heart1Name = "Heart1";
    private GameObject heart2;
    private string heart2Name = "Heart2";
    private GameObject heart3;
    private string heart3Name = "Heart3";

    void Awake()
    {
        healthGui = GetComponent<TextMeshProUGUI>();
        healthValue = 3;
        scoreManager = GameObject.Find(scoreManagerName).GetComponent<ScoreManager>();
        heart1 = GameObject.Find(heart1Name);
        heart2 = GameObject.Find(heart2Name);
        heart3 = GameObject.Find(heart3Name);
    }

    void Update()
    {
        if(healthValue < 3)
        {
            heart3.SetActive(false);
        }

        if (healthValue < 2)
        {
            heart2.SetActive(false);
            heart3.SetActive(false);
        }

        if (healthValue < 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }

        if (healthValue < 0)
        {
            healthValue = 0;
        }

        //healthGui.text = "Lives: " + healthValue;

        if (healthValue == 0)
        {
            scoreManager.SaveScore();
            scoreManager.LoadScore();
        }
    }
}
