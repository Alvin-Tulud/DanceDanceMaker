using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCheck : MonoBehaviour
{
    public enum Color
    {
        red = 0, 
        blue,
        yellow
    }

    public Color color;

    bool canhit;
    // Start is called before the first frame update
    private void Awake()
    {
        canhit = false;
    }

    //checks if it is in the area of hitbar to be able to be hit by player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbar"))
        {
            canhit = true;
        }
    }
   
    //check if it exitted the area whre player can hit arrows
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbar"))
        {
            canhit = false;
        }
    }

    public bool getCanHit()
    {
        return canhit;
    }
}
