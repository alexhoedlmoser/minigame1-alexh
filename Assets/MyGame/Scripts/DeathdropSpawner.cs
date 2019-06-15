using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathdropSpawner : MonoBehaviour
{
    private bool spawn = true;

    [SerializeField] CollectibleDeathdrop deathdropPrefab;
    [SerializeField] GameObject deathdropParent;

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;

    [SerializeField] int xMinPos;
    [SerializeField] int xMaxPos;
    [SerializeField] int yPos;
    [SerializeField] int yMinSpeed;
    [SerializeField] int yMaxSpeed;

    [SerializeField] float deathdropMinSize = 0.1f;
    [SerializeField] float deathdropMaxSize = 0.5f;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            CloneDeathdrop();
        }
    }

    private void CloneDeathdrop()
    {
        float deathdropSize = Random.Range(deathdropMinSize, deathdropMaxSize);

        CollectibleDeathdrop deathdropClone = (CollectibleDeathdrop)Instantiate(deathdropPrefab, transform.position, transform.rotation);
        deathdropClone.transform.SetParent(deathdropParent.transform);
        deathdropClone.transform.localPosition = new Vector3(Random.Range(xMinPos, xMaxPos), yPos, 0f);
        deathdropClone.transform.localScale = new Vector3(deathdropSize, deathdropSize, 0);
        deathdropClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(yMaxSpeed, yMinSpeed));
    }
}
