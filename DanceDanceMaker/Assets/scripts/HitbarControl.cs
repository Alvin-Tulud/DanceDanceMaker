using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitbarControl : MonoBehaviour
{
    public KeyCode input;


    //https://freesound.org/people/thefsoundman/sounds/118513/ hitsound source
    AudioSource hitsound;
    // Start is called before the first frame update
    private void Awake()
    {
        hitsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input))
        {
            hitsound.Play();
        }
    }
}
