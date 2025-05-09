using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitbarControl : MonoBehaviour
{
    //https://freesound.org/people/thefsoundman/sounds/118513/ hitsound source
    public GameObject[] arrows;

    private bool canInput;

    private void Start()
    {
        canInput = false;
    }

    //add functions into here to detect notes 
    //call from notecheck script
    public void getUp(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");
        }
    }

    public void getDown(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");
        }
    }
    public void getLeft(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");
        }
    }
    public void getRight(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");
        }
    }

    public void setCanInput(bool canInput)
    {
        this.canInput = canInput;
    }
}
