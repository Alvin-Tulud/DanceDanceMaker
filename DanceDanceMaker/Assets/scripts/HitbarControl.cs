using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitbarControl : MonoBehaviour
{
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

    }

    //add functions into here to detect notes 
    //call from notecheck script
    public void getDirection(InputAction.CallbackContext context)
    {
        hitsound.Play();
        Debug.Log("you did a thing " + context.ReadValue<Vector2>());
    }
}
