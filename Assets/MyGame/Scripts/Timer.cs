using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{ 
    private TextMeshProUGUI timerGui;
    public float startTime = 10;
    private float currTimeLeft;
    public GameManager gameManager;
    public SceneLoader sceneLoader;

    void Start()
    {
        // find GameManager Object
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Set up the reference.
        timerGui = GetComponent<TextMeshProUGUI>();

        StartCoroutine(StartTimer());

        // Reset timer.
        //timeLeft = 180;
    }

    void Update()
    {
        //timeLeft -= Time.deltaTime;

        if (currTimeLeft == 0)
        {
            gameManager.SaveScore();
            gameManager.LoadScore();
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
