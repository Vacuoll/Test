using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Transform poolParent;
    private int currentPoolElement = 0;

    public GameObject pref;
    public int count = 30;

    private Vector2 targetPoint;

    private float updateTime = 0.5f;
    void Start()
    {
        poolParent = transform;
        
        for (int i = 0; i < count; i++)
            Instantiate(pref, transform.position, transform.rotation, poolParent);
    }
    
    void Update()
    {
        updateTime -= Time.deltaTime;
        if (updateTime < 0)
        {
            GameObject obj = poolParent.GetChild(currentPoolElement).gameObject;
            obj.SetActive(true);
            obj.transform.position = new Vector3(Random.Range(0f,60f), 0,10);
        
            currentPoolElement++;
            if (currentPoolElement > poolParent.childCount - 1)
                currentPoolElement = 0;
            
            updateTime = 0.5f;
        }
    }
}
