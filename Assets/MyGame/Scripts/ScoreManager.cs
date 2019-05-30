using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue;
    private TextMeshProUGUI scoreGui;

    void Awake()
    {
        // Set up the reference.
        scoreGui = GetComponent<TextMeshProUGUI>();

        // Reset score.
        scoreValue = 0;
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        scoreGui.text = "Score: " + scoreValue;
    }
}
