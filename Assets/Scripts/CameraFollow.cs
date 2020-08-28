using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    private Transform player;

    void Start ()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update () 
    {
        if(player)
        {
            Vector3 target;
            target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
      
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
