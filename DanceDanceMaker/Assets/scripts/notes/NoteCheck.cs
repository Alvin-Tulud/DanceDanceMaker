using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCheck : MonoBehaviour
{
    public enum Color
    {
        red = 0, 
        blue,
        yellow,
        held,
        heldOther
    }

    public Color color;

    public int ID;

    bool canhit;

    public GameObject otherNote;
    // Start is called before the first frame update
    private void Start()
    {
        if (otherNote == null)
        {
            ID = NoteID.noteID;
            //Debug.Log(ID + " " + gameObject.name);
            NoteID.noteID++;
            //Debug.Log(NoteID.noteID + " " + gameObject.name);
        }
        else
        {
            otherNote.GetComponent<NoteCheck>().ID = ID;
        }
    }

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
