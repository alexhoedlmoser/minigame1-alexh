using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleBlossom : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == "PlayerBee")
        {
            ScoreManager.scoreValue += 1;
            Destroy(gameObject, 0f);
        }
        else if (collision.gameObject.name == "BottomHitbox")
        {
            ScoreManager.scoreValue -= 1;
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent" + collision.gameObject.name);
    }

}
