using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCheck : MonoBehaviour
{
    bool canhit;
    KeyCode hitKey;
    // Start is called before the first frame update
    private void Awake()
    {
        canhit = false;
        hitKey = KeyCode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (canhit)
        {
            if (Input.GetKeyDown(hitKey))
            {
                Debug.Log("hit: " + hitKey.ToString());
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbar"))
        {
            canhit = true;
            hitKey = collision.GetComponent<HitbarControl>().input;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbar"))
        {
            canhit = false;
            hitKey = KeyCode.None;
        }
    }
}
