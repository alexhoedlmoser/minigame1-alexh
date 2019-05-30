using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static int healthValue;
    private TextMeshProUGUI healthGui;
    private SceneLoader sceneLoader;

    void Awake()
    {
        // Set up the reference.
        healthGui = GetComponent<TextMeshProUGUI>();

        // Reset health.
        healthValue = 5;

        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    void Update()
    {
        // Set the displayed text to be the word "Health" followed by the health value.
        healthGui.text = "Lives: " + healthValue;

        if (healthValue == 0)
        {
            sceneLoader.LoadEndScene();
        }
    }
}
