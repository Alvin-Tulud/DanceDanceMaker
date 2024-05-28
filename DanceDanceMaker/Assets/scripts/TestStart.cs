using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStart : MonoBehaviour
{
    bool isClicked = false;

    public GameObject EditorObj;

    private void Update()
    {
        
    }

    public void setClicked()
    {
        if (isClicked)
        {
            isClicked = false;
        }
        else
        {
            isClicked = true;
        }

        EditorObj.SetActive(!isClicked);
    }

    public bool getClicked() { return  isClicked; }
}
