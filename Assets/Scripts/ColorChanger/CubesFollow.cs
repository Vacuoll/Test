using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesFollow : MonoBehaviour
{
    private float speed;
    private Vector3 target;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        speed = Random.Range(0.1f, 1f);
        startPos = transform.position;
        endPos = new Vector2(transform.position.x, transform.position.y + 1);
        target = endPos;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.y != startPos.y)
            target.y = startPos.y;
        else
        if (transform.position == target && target.y == startPos.y)
            target.y = endPos.y;
    }
}
