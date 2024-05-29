using UnityEngine;
using UnityEngine.UI;

public class StartSong : MonoBehaviour
{
    bool isPlaying = false;
    bool turnedOffValidTile = false;

    public int tempo;

    public Vector3 initPos = new Vector3(-5, 1500, 0);
   
    private void Update()
    {
        if (isPlaying)
        {
            if (!turnedOffValidTile)
            {
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

                Vector3 worldPos = Camera.main.ScreenToWorldPoint(kid.position);
                //Debug.Log(kid.name + " : " + worldPos);
                if (worldPos.y < 10f && worldPos.y > -10f)
                {
                    kid.gameObject.SetActive(true);
                }
                else
                {
                    kid.gameObject.SetActive(false);
                }
            }
            //250 is scroll extra to account for spacing
            transform.localPosition -= new Vector3(0, (float)((tempo / 60f) * 2.5f * Time.deltaTime), 0);
        }

        else
        {
            if (turnedOffValidTile)
            {
                transform.localPosition = initPos;

                Transform t = transform.GetChild(1);

                for (int i = 0; i < t.childCount; i++)
                {
                    Transform kid = t.GetChild(i);
                    kid.GetComponent<Image>().enabled = true;

                    for (int j = 0; j < kid.childCount; j++)
                    {
                        kid.GetChild(j).GetComponent<BoxCollider2D>().enabled = true;
                    }

                    kid.gameObject.SetActive(true);
                }

                turnedOffValidTile = false;
            }

            //Transform g = transform.GetChild(1);
            //
            //for (int i = 0; i < g.childCount; i++)
            //{
            //    Transform kid = g.GetChild(i);
            //    //do some math from the noteslider to make it so that when in screen bound
            //    //get midpoint in worldspace
            //    //keep track of world position and do math
            //
            //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(kid.position);
            //    //Debug.Log(kid.name + " : " + worldPos);
            //    if (worldPos.y < 2f && worldPos.y > -2f)
            //    {
            //        kid.gameObject.SetActive(true);
            //    }
            //    else
            //    {
            //        kid.gameObject.SetActive(false);
            //    }
            //}
        }
    }

    public void setPlaying(bool playing) { isPlaying = playing; }
}
