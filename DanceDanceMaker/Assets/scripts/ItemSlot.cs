using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public GameObject Tile_To_Spawn;
    private LayerMask ArrowLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        AddTile();

        ArrowLayerMask = 1 << 7;
    }

    // Update is called once per frame
    void Update()
    {
        //adds tile if none is present
        RaycastHit2D checkTile = Physics2D.Raycast(transform.position, transform.forward, 0.1f, ArrowLayerMask);

        if (!checkTile)
        {
            AddTile();
        }
    }

    //Used by Draggable's trashbin logic to increase tile count.
    public void AddTile()
    {
        GameObject g = Instantiate(Tile_To_Spawn, transform.position, transform.rotation);
        g.transform.position = Vector3.zero;
        g.GetComponent<NoteCheck>().enabled = false;
        g.transform.SetParent(transform, false);
    }
}

