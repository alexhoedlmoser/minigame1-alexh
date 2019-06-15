using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] GameObject clickEffect;
    [SerializeField] GameObject trailEffect;
    private float timeBtwSpawn = 0.01f;

	void Start () {
        Cursor.visible = false;
	}
	
	void Update () {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(clickEffect, transform.position, Quaternion.identity);
        }

        if(timeBtwSpawn <= 0)
        {
            Instantiate(trailEffect, cursorPos, Quaternion.identity);
            timeBtwSpawn = 0.01f;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
	}
}
