using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleBlossom : MonoBehaviour
{
    private string playerTag = "PlayerBee";
    private string bottomTag = "BottomHitbox";
    private Animator playerAnimator;
    private string goodAnimationName = "BeeGood";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == playerTag)
        {
            ScoreManager.scoreValue += Random.Range(8, 13);
            Destroy(gameObject, 0f);
            playerAnimator = GameObject.Find(playerTag).GetComponent<Animator>();
            playerAnimator.Play(goodAnimationName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == bottomTag)
        {
            ScoreManager.scoreValue -= Random.Range(9, 12); ;
            Destroy(gameObject, 0f);
        }
    }
}
