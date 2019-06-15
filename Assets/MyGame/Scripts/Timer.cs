using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{ 
    private TextMeshProUGUI timerGui;
    [SerializeField] float startTime = 10;
    private float currTimeLeft;
    private ScoreManager scoreManager;
    private string scoreManagerName = "ScoreManager";

    void Start()
    {
        // find GameManager Object
        scoreManager = GameObject.Find(scoreManagerName).GetComponent<ScoreManager>();

        // Set up the reference.
        timerGui = GetComponent<TextMeshProUGUI>();

        StartCoroutine(StartTimer());
    }

    void Update()
    {
        if (currTimeLeft == 0)
        {
            scoreManager.SaveScore();
            scoreManager.LoadScore();
        }
    }

    public IEnumerator StartTimer()
    {
        currTimeLeft = startTime;
        while (currTimeLeft >= 0)
        {
            timerGui.text = "Time: " + currTimeLeft;
            yield return new WaitForSeconds(1.0f);
            currTimeLeft--;
        }
    }
}
