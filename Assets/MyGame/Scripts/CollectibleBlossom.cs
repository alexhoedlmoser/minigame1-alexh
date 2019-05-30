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
            Destroy(gameObject, 0f);
            ScoreManager.scoreValue += 1;
        }
        else if (collision.gameObject.name == "BottomHitbox")
        {
            Destroy(gameObject, 1f);
            ScoreManager.scoreValue -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent" + collision.gameObject.name);
    }

}
