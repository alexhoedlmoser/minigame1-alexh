using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlossomSpawner : MonoBehaviour
{
    private bool spawn = true;

    [SerializeField] CollectibleBlossom blossomPrefab;
    [SerializeField] GameObject blossomParent;
    [SerializeField] Sprite[] blossomSprites;

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;

    [SerializeField] int xMinPos;
    [SerializeField] int xMaxPos;
    [SerializeField] int yPos;
    [SerializeField] int yMinSpeed;
    [SerializeField] int yMaxSpeed;

    [SerializeField] float blossomMinSize = 0.1f;
    [SerializeField] float blossomMaxSize = 0.5f;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            CloneBlossom();
        }
    }

    private void CloneBlossom()
    {
        float blossomSize = Random.Range(blossomMinSize, blossomMaxSize);
        int blossomSpriteIndex = Random.Range(0, 5);
        Debug.Log("Index: " + blossomSpriteIndex);

        CollectibleBlossom blossomClone = (CollectibleBlossom)Instantiate(blossomPrefab, transform.position, transform.rotation);
        blossomClone.transform.SetParent(blossomParent.transform);
        blossomClone.transform.localPosition = new Vector3(Random.Range(xMinPos, xMaxPos), yPos, 0f);
        blossomClone.transform.localScale = new Vector3(blossomSize, blossomSize, 0);
        blossomClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(yMaxSpeed, yMinSpeed));
        blossomClone.GetComponent<SpriteRenderer>().sprite = blossomSprites[blossomSpriteIndex];
    }
}
