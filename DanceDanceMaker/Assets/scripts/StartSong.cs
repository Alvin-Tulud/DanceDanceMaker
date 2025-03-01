using UnityEngine;
using UnityEngine.UI;

public class StartSong : MonoBehaviour
{
    bool isPlaying = false;
    bool turnedOffValidTile = false;


    public Vector3 initPos = new Vector3(-5, 1500, 0);
   
    private void Update()
    {
        if (isPlaying)
        {
            //allow player to hit buttons during play
            sethitbar(true);

            //optimization turning off colliders
            if (!turnedOffValidTile)
            {
                ConductorClass music = GameObject.FindGameObjectWithTag("SongOffset").GetComponent<ConductorClass>();

                music.enabled = true;
                music.Scroll(true);


                transform.localPosition = initPos;

                Transform t = transform.GetChild(1);

                for (int i = 0; i < t.childCount; i++)
                {
                    Transform kid = t.GetChild(i);

                    if (kid.name.Equals("measure(Clone)"))//turn off sub divison bars durting play
                    {
                        kid.GetComponent<Image>().enabled = false;
                    }

                    for (int j = 0; j < kid.childCount; j++)
                    {
                        kid.GetChild(j).GetComponent<BoxCollider2D>().enabled = false;

                        if (kid.GetChild(j).childCount != 0)
                        {
                            Transform note = kid.GetChild(j).GetChild(0);

                            note.GetComponent<Draggable>().playerMovable = false;

                            note.GetComponent<NoteCheck>().enabled = true;
                        }
                    }

                    kid.gameObject.SetActive(false);
                }

                turnedOffValidTile = true;
            }


            measurePooling();
        }

        else
        {
            sethitbar(false);

            //turn editor stuff back on when playing done
            if (turnedOffValidTile)
            {
                ConductorClass music = GameObject.FindGameObjectWithTag("SongOffset").GetComponent<ConductorClass>();

                music.endSond();
                music.enabled = false;
                music.Scroll(false);


                transform.localPosition = initPos;

                Transform t = transform.GetChild(1);

                for (int i = 0; i < t.childCount; i++)
                {
                    Transform kid = t.GetChild(i);
                    kid.GetComponent<Image>().enabled = true;

                    for (int j = 0; j < kid.childCount; j++)
                    {
                        kid.GetChild(j).GetComponent<BoxCollider2D>().enabled = true;

                        if (kid.GetChild(j).childCount != 0)
                        {
                            Transform note = kid.GetChild(j).GetChild(0);

                            note.gameObject.SetActive(true);

                            note.GetComponent<Draggable>().playerMovable = true;

                            note.GetComponent<NoteCheck>().enabled = false;
                        }
                    }

                    kid.gameObject.SetActive(true);
                }

                turnedOffValidTile = false;
            }


            measurePooling();
        }
    }

    public void setPlaying(bool playing) { isPlaying = playing; }

    void sethitbar(bool state)
    {
        GameObject[] hitbar = GameObject.FindGameObjectsWithTag("Hitbar");

        foreach (GameObject go in hitbar)
        {
            go.GetComponent<HitbarControl>().enabled = state;
        }
    }

    void measurePooling()
    {
        //optimization object pooling
        Transform g = transform.GetChild(1);

        for (int i = 0; i < g.childCount; i++)
        {
            Transform kid = g.GetChild(i);
            //do some math from the noteslider to make it so that when in screen bound
            //get midpoint in worldspace
            //keep track of world position and do math

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(kid.position);
            //Debug.Log(kid.name + " : " + worldPos);
            if (worldPos.y < -4.8f && worldPos.y > -5.3f)
            {
                kid.gameObject.SetActive(true);
            }
            else
            {
                kid.gameObject.SetActive(false);
            }
        }
    }
}
