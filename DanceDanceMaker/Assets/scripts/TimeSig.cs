using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSig : MonoBehaviour
{
    public GameObject spawnMeasure;
    public Transform Measure_Parent;
    public Transform NoteScroll;
    public List<GameObject> Measure_Children;
    public List<GameObject> Added_Measures;

    public Slider slider;


    float notesbetween;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Measure_Parent.childCount; i++)
        {
            Measure_Children.Add(Measure_Parent.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNoteCount()
    {
        float count = slider.value;

        if (count == 5)
        {
            notesbetween = 6;
        }
        else if (count == 6)
        {
            notesbetween = 8;
        }
        else
        {
            notesbetween = count;
        }

        foreach (GameObject child in Added_Measures)
        {
            Destroy(child);
        }

        Added_Measures.Clear();


        for (int i = 0; i < Measure_Children.Count - 1; i++)//for each measure
        {
            for (int j = 1; j < notesbetween; j++)//subdivide it dont start at 1 cuz its already exist
            {
                //do math to get between space at x increment
                Vector3 currMes = Measure_Children[i].transform.localPosition;
                Vector3 nextMes = Measure_Children[i + 1].transform.localPosition;

                Vector3 SpaceBetween = new Vector3(0, nextMes.y - currMes.y, 0);
                Vector3 subdivision = SpaceBetween / notesbetween;
                Vector3 spawnPos = currMes + (subdivision * j);


                GameObject m = Instantiate(spawnMeasure, spawnPos, transform.rotation);
                m.transform.SetParent(Measure_Parent, false);
                //m.transform.localScale = transform.localScale;
                Added_Measures.Add(m);
            }
        }
    }
}
