using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleBlossom : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreGui;

    void Start()
    {
        scoreGui.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == "PlayerBee")
        {
            score += 1;
            Debug.Log("score: " + score);
            scoreGui.text = score.ToString();
            Destroy(gameObject, 0f);
        }
        else if (collision.gameObject.name == "BottomHitbox")
        {
            score -= 1;
            Debug.Log("score: " + score);
            scoreGui.text = score.ToString();
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent");
    }

}
