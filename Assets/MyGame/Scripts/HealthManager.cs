using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static int healthValue;
    private ScoreManager scoreManager;
    private string scoreManagerName = "ScoreManager";
    private string heartGoneAnimationStateName = "HeartGone";

    private Animator heart1;
    private string heart1Name = "Heart1";
    private Animator heart2;
    private string heart2Name = "Heart2";
    private Animator heart3;
    private string heart3Name = "Heart3";
    private bool callOnceHeart1 = false;
    private bool callOnceHeart2 = false;
    private bool callOnceHeart3 = false;

    void Awake()
    {
        healthValue = 3;
        scoreManager = GameObject.Find(scoreManagerName).GetComponent<ScoreManager>();
        heart1 = GameObject.Find(heart1Name).GetComponent<Animator>();
        heart2 = GameObject.Find(heart2Name).GetComponent<Animator>();
        heart3 = GameObject.Find(heart3Name).GetComponent<Animator>();
    }

    void Update()
    {
        if(healthValue < 3 & !callOnceHeart3)
        {
            StartCoroutine(DisableHeart3());
            callOnceHeart3 = true;
        }

        if (healthValue < 2 & !callOnceHeart2)
        {
            StartCoroutine(DisableHeart2());
            callOnceHeart2 = true;
        }

        if (healthValue < 1 & !callOnceHeart1)
        {
            StartCoroutine(DisableHeart1());
            callOnceHeart1 = true;
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

    IEnumerator DisableHeart3()
    {
        heart3.Play(heartGoneAnimationStateName);
        yield return new WaitForSeconds(0.5f);
        GameObject heart3Obj = GameObject.Find(heart3Name);
        heart3Obj.SetActive(false);
    }

    IEnumerator DisableHeart2()
    {
        heart2.Play(heartGoneAnimationStateName);
        yield return new WaitForSeconds(0.5f);
        GameObject heart2Obj = GameObject.Find(heart2Name);
        heart2Obj.SetActive(false);
    }

    IEnumerator DisableHeart1()
    {
        heart1.Play(heartGoneAnimationStateName);
        yield return new WaitForSeconds(0.5f);
        GameObject heart1Obj = GameObject.Find(heart1Name);
        heart1Obj.SetActive(false);
    }
}
