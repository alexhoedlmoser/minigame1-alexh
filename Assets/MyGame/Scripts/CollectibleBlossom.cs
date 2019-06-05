using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleBlossom : MonoBehaviour
{

    private string playerTag = "PlayerBee";
    private string bottomTag = "BottomHitbox";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == playerTag)
        {
            ScoreManager.scoreValue += 10;
            Destroy(gameObject, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == bottomTag)
        {
            ScoreManager.scoreValue -= 10;
            Destroy(gameObject, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent" + collision.gameObject.name);
    }

}
