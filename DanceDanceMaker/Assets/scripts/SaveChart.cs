using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveData()
    {
        SongData data = new SongData();

    }
}

[System.Serializable]
public class SongData
{
    public string song_name;
    public string artist_name;


    public string difficulty_name;


    public float tempo;
    public int subdivision;
}
