using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMeasures : MonoBehaviour
{
    public Transform NoteScroll;
    private StartSong song;
    // Update is called once per frame

    private void Awake()
    {
        song = NoteScroll.GetComponent<StartSong>();
    }
    //&& NoteScroll.position.y + Input.mouseScrollDelta.y >= song.initPos.y && NoteScroll.position.y + Input.mouseScrollDelta.y <= (-1) * song.initPos.y
    void Update()
    {
        //Debug.Log(Input.mouseScrollDelta);
        if (Input.mouseScrollDelta != Vector2.zero && NoteScroll.position.y + Input.mouseScrollDelta.y <= song.initPos.y && NoteScroll.position.y + Input.mouseScrollDelta.y >= (-1) * song.initPos.y)
        {
            //Debug.Log("Scrolling");
            NoteScroll.position = new Vector3(NoteScroll.position.x, NoteScroll.position.y + (Input.mouseScrollDelta.y / 2), NoteScroll.position.z);
        }
    }
}
