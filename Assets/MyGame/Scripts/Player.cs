using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string AXISHORIZONTAL = "Horizontal";
    private float moveSpeed = 3.0f;

    private bool spriteSwap = true;
    public Sprite[] beeSprites;
    public float boundaryLeft;
    public float boundaryRight;

    private void Start()
    {
        StartCoroutine(SpriteSwapper());
    }

    IEnumerator SpriteSwapper()
    {
        while (spriteSwap)
        {
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().sprite = beeSprites[0];

            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().sprite = beeSprites[1];
        }
    }

    private void Move()
    {
            var deltaX = Input.GetAxis(AXISHORIZONTAL) * Time.deltaTime * moveSpeed;
            var newPosX = Mathf.Clamp(transform.position.x + deltaX, boundaryLeft, boundaryRight);

            transform.position = new Vector2(newPosX, transform.position.y);
    }

    void Update ()
    {
        Move();
    }
}
