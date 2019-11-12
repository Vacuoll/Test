using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static int height = 10;
    public static int width = 20;

    public Vector3 impulse = new Vector3(5, 0, 0);

    private static Transform[,] grid = new Transform[width, height];

    /* void OnCollisionStay2D(Collision2D collision)
     {
         for (int i = 0; i < width; i++)
             for (int j = 0; j < height; j++)
             {
                 if (collision.collider.CompareTag("Blocks"))
                 {
                     if (CanMove(i,j) == 1)
                     {
                         Debug.Log("1");
                         grid[i, j + 1] = grid[i, j];
                         grid[i, j] = null;
                         grid[i, j].transform.position += new Vector3(1, 0, 0);
                     }
                     else if(CanMove(i, j) == -1)
                     {
                         Debug.Log("-1");
                         grid[i, j - 1] = grid[i, j];
                         grid[i, j] = null;
                         grid[i, j].transform.position += new Vector3(-1, 0, 0);
                     }

                 }
             }

     }

     int CanMove(int i, int j)
     {

         int check = 0;

         if ((grid[i, j] != null && grid[i, j + 1] != null) || (grid[i, j] != null && grid[i, j - 1] != null))
             check = 0;
         else if (grid[i, j] != null && grid[i, j + 1] == null)
             check = 1;
         else if (grid[i, j] != null && grid[i, j - 1] == null)
             check = -1;

         return check;
     }*/
    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
            gameObject.transform.position += new Vector3(-1, 0, 0);
    }
}
