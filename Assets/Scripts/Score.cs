using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    private int score = 0;
    public Text text;
    public GameObject PanelLose;


private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            score++;
            text.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
