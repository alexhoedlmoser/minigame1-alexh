using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropSpawner : MonoBehaviour
{
    private bool spawn = true;

    [SerializeField] CollectibleRaindrop raindropPrefab;
    [SerializeField] GameObject raindropParent;

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;

    [SerializeField] int xMinPos;
    [SerializeField] int xMaxPos;
    [SerializeField] int yPos;
    [SerializeField] int yMinSpeed;
    [SerializeField] int yMaxSpeed;

    [SerializeField] float raindropMinSize = 0.1f;
    [SerializeField] float raindropMaxSize = 0.5f;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            CloneRaindrop();
        }
    }

    private void CloneRaindrop()
    {
        float raindropSize = Random.Range(raindropMinSize, raindropMaxSize);

        CollectibleRaindrop raindropClone = (CollectibleRaindrop)Instantiate(raindropPrefab, transform.position, transform.rotation);
        raindropClone.transform.SetParent(raindropParent.transform);
        raindropClone.transform.localPosition = new Vector3(Random.Range(xMinPos, xMaxPos), yPos, 0f);
        raindropClone.transform.localScale = new Vector3(raindropSize, raindropSize, 0);
        raindropClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(yMaxSpeed, yMinSpeed));
    }
}
