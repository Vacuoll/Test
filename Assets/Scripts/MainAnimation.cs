using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimation : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector2 targetPoint;

    private void Update()
    {
        targetPoint = new Vector2(transform.position.x, transform.position.y + 35);
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed);
    }
}
