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

    void Awake()
    {
        healthGui = GetComponent<TextMeshProUGUI>();
        healthValue = 3;
        scoreManager = GameObject.Find(scoreManagerName).GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (healthValue < 0)
        {
            healthValue = 0;
        }

        healthGui.text = "Lives: " + healthValue;

        if (healthValue == 0)
        {
            scoreManager.SaveScore();
            scoreManager.LoadScore();
        }
    }
}
