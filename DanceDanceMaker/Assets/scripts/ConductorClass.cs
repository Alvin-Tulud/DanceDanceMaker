using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorClass : MonoBehaviour
{
    AudioSource Song;
    Vector3 offset;
    bool startedmusic;
    bool startscroll;
    public Transform NoteScroll;
    public float tempo;
    // Start is called before the first frame update
    private void Awake()
    {
        Song = GetComponent<AudioSource>();
        startedmusic = false;
        startscroll = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startscroll)
        {
            NoteScroll.localPosition -= new Vector3(0, (float)((tempo / 60f) * 2.5f * Time.deltaTime), 0);
        }
        //if music has started playing
        if (startedmusic)
        {
            //when its done stop and go back to editor mode
            if (!Song.isPlaying)
            {
                NoteScroll.GetComponent<StartSong>().setPlaying(false);
                startedmusic = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<ConductorClass>().enabled && collision.CompareTag("Hitbar"))
        {
            Song.Play();
            startedmusic = true;
        }
    }


    public void playSong()
    {
        Song.Play();
    }

    public void endSond()
    {
        Song.Stop();
    }

    public void Scroll(bool state)
    {
        startscroll = state;
    }
}
