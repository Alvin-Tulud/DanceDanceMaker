using UnityEngine;
using UnityEngine.UI;

public class StartSong : MonoBehaviour
{
    bool isPlaying = false;
    bool turnedOffValidTile = false;

    public int tempo;

   
    private void Update()
    {
        if (isPlaying)
        {
            if (!turnedOffValidTile)
            {
                Transform t = transform.GetChild(1);

                for (int i = 0; i < t.childCount; i++)
                {
                    Transform kid = t.GetChild(i);
                    kid.GetComponent<Image>().enabled = false;

                    for (int j = 0; j < kid.childCount; j++)
                    {
                        kid.GetChild(j).GetComponent<BoxCollider2D>().enabled = false;
                    }

                    kid.gameObject.SetActive(false);
                }

                turnedOffValidTile = true;
            }

            Transform g = transform.GetChild(1);

            for (int i = 0; i < g.childCount; i++)
            {
                Transform kid = g.GetChild(i);
                //do some math from the noteslider to make it so that when in screen bound
                //get midpoint in worldspace
                //keep track of world position and do math
            }

            transform.localPosition -= new Vector3(0, (float)(tempo * 2.5 * Time.deltaTime), 0);
        }

        else
        {
            if (turnedOffValidTile)
            {
                Transform g = transform.GetChild(1);

                for (int i = 0; i < g.childCount; i++)
                {
                    Transform kid = g.GetChild(i);
                    kid.GetComponent<Image>().enabled = true;

                    for (int j = 0; j < kid.childCount; j++)
                    {
                        kid.GetChild(j).GetComponent<BoxCollider2D>().enabled = true;
                    }

                    kid.gameObject.SetActive(true);
                }

                turnedOffValidTile = false;
            }

            transform.localPosition = new Vector3(-500, 150000, 0);
        }
    }

    public void setPlaying(bool playing) { isPlaying = playing; }
}