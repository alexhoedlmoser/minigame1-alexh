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
    private ScoreManager scoreManager;
    private string scoreManagerName = "ScoreManager";

    private void Start()
    {
        scoreManager = GameObject.Find(scoreManagerName).GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == playerTag)
        {
            scoreManager.scoreValue += Random.Range(8, 13);
            Destroy(gameObject, 0f);
            playerAnimator = GameObject.Find(playerTag).GetComponent<Animator>();
            playerAnimator.Play(goodAnimationName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == bottomTag)
        {
           scoreManager.scoreValue -= Random.Range(9, 12); ;
            Destroy(gameObject, 0f);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.back * (100 * Time.deltaTime));
    }
}
