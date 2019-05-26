using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleRaindrop : MonoBehaviour
{
    private int lives = 3;
    public TextMeshProUGUI livesGui;

    void Start()
    {
        lives = 3;
        livesGui.text = lives.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == "PlayerBee")
        {
            lives -= 1;
            Debug.Log("lives: " + lives);
            livesGui.text = lives.ToString();
            Destroy(gameObject, 0f);
        }
        else if (collision.gameObject.name == "BottomHitbox")
        {
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent");
    }

}
