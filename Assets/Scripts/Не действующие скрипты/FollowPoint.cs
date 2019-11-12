using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public float speed = 1; //скорость. скорость вращения
    public float distanse;
    //private Vector3 target = new Vector3(0, 1.68f, 0);

    private Vector3 startPos;
    private Vector3 target;
    private Vector3 endPos; 
     void Start()
    {
        startPos = gameObject.transform.position;
        endPos = new Vector3(startPos.x, startPos.y + distanse, startPos.z);
        target = startPos;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.y == startPos.y)
            target.y = endPos.y;
        else
            if (transform.position == target && target.y == endPos.y)
            target.y = startPos.y;

    }
}
