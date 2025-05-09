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

            RaycastHit2D[] hit;

            hit = Physics2D.CircleCastAll(arrows[2].transform.position, 0.25f, Vector2.zero);

            foreach(RaycastHit2D hit2 in hit)
            {
                if (hit2.transform.CompareTag("Note"))
                {
                    hit2.transform.gameObject.SetActive(false);
                }
            }
        }
    }

    public void getDown(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");

            RaycastHit2D[] hit;

            hit = Physics2D.CircleCastAll(arrows[1].transform.position, 0.25f, Vector2.zero);

            foreach (RaycastHit2D hit2 in hit)
            {
                if (hit2.transform.CompareTag("Note"))
                {
                    hit2.transform.gameObject.SetActive(false);
                }
            }
        }
    }
    public void getLeft(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");

            RaycastHit2D[] hit;

            hit = Physics2D.CircleCastAll(arrows[0].transform.position, 0.25f, Vector2.zero);

            foreach (RaycastHit2D hit2 in hit)
            {
                if (hit2.transform.CompareTag("Note"))
                {
                    hit2.transform.gameObject.SetActive(false);
                }
            }
        }
    }
    public void getRight(InputAction.CallbackContext context)
    {
        if (canInput)
        {
            Debug.Log("you did a thing up");

            RaycastHit2D[] hit;

            hit = Physics2D.CircleCastAll(arrows[3].transform.position, 0.25f, Vector2.zero);

            foreach (RaycastHit2D hit2 in hit)
            {
                if (hit2.transform.CompareTag("Note"))
                {
                    hit2.transform.gameObject.SetActive(false);
                }
            }
        }
    }

    public void setCanInput(bool canInput)
    {
        this.canInput = canInput;
    }
}
