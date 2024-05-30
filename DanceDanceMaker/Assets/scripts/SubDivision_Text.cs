using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubDivision_Text : MonoBehaviour
{
    public Slider Time_Signature;
    public TextMeshProUGUI subdivision;

    // Start is called before the first frame update
    void Start()
    {
        subdivision.text = "Subdivision: 1/1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText()
    {
        float count = Time_Signature.value;

        if (count == 5)
        {
            subdivision.text = "Subdivision: 1/6";
        }
        else if (count == 6)
        {
            subdivision.text = "Subdivision: 1/8";
        }
        else
        {
            subdivision.text = "Subdivision: 1/" + count;
        }
    }
}
