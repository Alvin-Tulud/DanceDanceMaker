using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretch : MonoBehaviour
{
    private Transform arrowChildPos;
    private Transform arrowParentPos;
    private Transform linePos;

    private BoxCollider2D lineCollider;
    private LineRenderer line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrowChildPos = transform;
        arrowParentPos = transform.parent;
        linePos = transform.parent.GetChild(0);

        lineCollider = transform.parent.GetChild(0).GetComponent<BoxCollider2D>();
        line = transform.parent.GetChild(0).GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempSet = new Vector3(arrowParentPos.position.x, (arrowParentPos.position.y + arrowChildPos.position.y) / 2, 0);
        Debug.Log(arrowParentPos.position + " " + arrowChildPos.position);
        linePos.position = tempSet;

        Debug.Log(tempSet);
        
        line.SetPosition(0, arrowParentPos.position);
        Vector3 tempSetLine = new Vector3(arrowParentPos.position.x, arrowChildPos.position.y, 0);
        line.SetPosition(1, tempSetLine);

        lineCollider.size = new Vector2(1, arrowChildPos.position.y - arrowParentPos.position.y);
    }
}
