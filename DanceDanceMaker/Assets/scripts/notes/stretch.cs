using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretch : MonoBehaviour
{
    public Transform arrowChildPos;
    public Transform arrowParentPos;
    public Transform linePos;

    private bool setOnce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrowChildPos = transform;
        arrowParentPos = transform.parent;
        linePos = transform.parent.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (setOnce)
        {
            Vector3 tempSet = new Vector3(0, (arrowParentPos.localPosition.y + arrowChildPos.localPosition.y) / 2, 0);
            Debug.Log(arrowParentPos.localPosition + " " + arrowChildPos.localPosition);
            linePos.localPosition = tempSet;

            Debug.Log(tempSet);

            linePos.localScale = new Vector3(1, Mathf.Abs(arrowChildPos.localPosition.y - arrowParentPos.localPosition.y), 0);
        }
        else if (transform.parent.gameObject.layer == 6)
        {
            Vector3 tempSet = new Vector3(arrowParentPos.position.x, (arrowParentPos.position.y + arrowChildPos.position.y) / 2, 0);
            Debug.Log(arrowParentPos.position + " " + arrowChildPos.position);
            linePos.position = tempSet;

            Debug.Log(tempSet);

            linePos.localScale = new Vector3(1, Mathf.Abs(arrowChildPos.position.y - arrowParentPos.position.y), 0);
        }
    }
}
