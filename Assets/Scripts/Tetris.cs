using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    public static int height = 10;
    public static int width = 20;

    private float fallSpeed = 5f;
    public Vector3 impulse = new Vector3(5,0,0);

    private static Transform[,] grid = new Transform[width, height];

    void Update()
    {
            transform.position += new Vector3(0, -fallSpeed * Time.fixedDeltaTime, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -fallSpeed * Time.fixedDeltaTime, 0);
                AddToGrid();
                CheckForLines();
            }
    }

    /*void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && ValidMove())
            gameObject.transform.position += new Vector3(-1, 0, 0);
    }*/
    void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;

    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {

        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }


}
