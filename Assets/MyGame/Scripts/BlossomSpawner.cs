﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlossomSpawner : MonoBehaviour
{
    private bool spawn = true;

    public CollectibleBlossom blossomPrefab;
    public GameObject blossomParent;
    public Sprite[] blossomSprites;

    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 5.0f;

    public int xMinPos;
    public int xMaxPos;
    public int yPos;
    public int yMinSpeed;
    public int yMaxSpeed;

    public float blossomMinSize = 0.1f;
    public float blossomMaxSize = 0.5f;

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
