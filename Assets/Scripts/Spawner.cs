using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] unevenPref;
    public GameObject[] evenPref;
    public float startTimeBtwStart;//промежуток между падениями блоков
    public float[] XSpawnPosition;

    private float _timeBtwStart = 0;
 


    void Update()
    {
        int pointer = Random.Range(0, 2);
        
        if (pointer == 1)
        {
            int obj = Random.Range(0, unevenPref.Length);
            if (_timeBtwStart <= 0)
            {
                int rand = Random.Range(0, XSpawnPosition.Length);
                Instantiate(unevenPref[obj], new Vector2(XSpawnPosition[rand], transform.position.y), Quaternion.identity);
                _timeBtwStart = startTimeBtwStart;
            }
            else
            {
                _timeBtwStart -= Time.deltaTime;
            }

        }
        if (pointer == 0)
        {
            int obj = Random.Range(0, evenPref.Length);
            if (_timeBtwStart <= 0)
            {
                int rand = Random.Range(0, XSpawnPosition.Length - 1);
                Instantiate(evenPref[obj], new Vector2(XSpawnPosition[rand] + 0.5f, transform.position.y), Quaternion.identity);
                _timeBtwStart = startTimeBtwStart;
            }
            else
            {
                _timeBtwStart -= Time.deltaTime;
            }

        }

    }
}
