using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleRaindrop : MonoBehaviour
{
    private string playerTag = "PlayerBee";
    private string bottomTag = "BottomHitbox";
    private Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == playerTag)
        {
            HealthManager.healthValue -= 1;
            Destroy(gameObject, 0f);
            playerAnimator = GameObject.Find(playerTag).GetComponent<Animator>();
            playerAnimator.Play("BeeBad");
        }

        else if (collision.gameObject.name == bottomTag)
        {
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent" + collision.gameObject.name);
    }
}
