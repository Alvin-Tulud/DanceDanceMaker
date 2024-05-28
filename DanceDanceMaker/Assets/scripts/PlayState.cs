using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour
{
    public StartSong NoteScroll;
    public TestStart TestButton;


    // Update is called once per frame
    void Update()
    {
        if (TestButton.getClicked())
        {
            NoteScroll.setPlaying(true);
        }
        else
        {
            NoteScroll.setPlaying(false);
        }
    }
}
