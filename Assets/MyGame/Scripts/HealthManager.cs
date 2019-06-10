using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static int healthValue;
    private TextMeshProUGUI healthGui;
    private GameManager gameManager;

    void Awake()
    {
        // Set up the reference.
        healthGui = GetComponent<TextMeshProUGUI>();

        // Reset health.
        healthValue = 3;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        // Set the displayed text to be the word "Health" followed by the health value.
        healthGui.text = "Lives: " + healthValue;

        if (healthValue == 0)
        {
            gameManager.SaveScore();
            gameManager.LoadScore();
        }
    }
}
