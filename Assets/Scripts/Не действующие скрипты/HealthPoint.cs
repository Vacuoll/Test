using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public GameObject[] Health;
    public float startTimeBtwStart;//промежуток между падениями блоков
    public int[] XHealthPosition;
    private float _timeBtwStart = 0;


    void Update()
    {

        if (_timeBtwStart <= 0)
        {
            int randobj = Random.Range(0, Health.Length);
            int rand = Random.Range(0, XHealthPosition.Length);
            Instantiate(Health[randobj], new Vector3(XHealthPosition[rand], transform.position.y), Quaternion.identity);
            _timeBtwStart = startTimeBtwStart;
        }
        else
        {
            _timeBtwStart -= Time.deltaTime;
        }
    }
}
