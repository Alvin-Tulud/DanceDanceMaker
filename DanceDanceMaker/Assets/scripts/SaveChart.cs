using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SaveChart : MonoBehaviour
{
    public Transform Measures;

    public SongData data = new SongData();
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
        //assign artist name and song name
        //assign difficulty name
        //get tempo and subdivision


        //iterate through measures
            //within each measure
                //check each note spot
                    //if theres a child
                        //assign parent name
                        //check notecheck enum value and assign enum value

        data.notes.Clear();

        //for each measure
        for (int i = 0; i < Measures.childCount; i++)
        {
            Transform measure = Measures.GetChild(i).transform;

            //look at each note spot
            for (int j = 0; j < measure.childCount; j++)
            {
                Transform noteSpot = measure.GetChild(j).transform;

                //it theres a note
                if (noteSpot.childCount != 0)
                {
                    note beat = new note();

                    beat.measurePos = measure.transform.localPosition;
                    beat.parentNum = j;
                    beat.color = (note.Color) noteSpot.GetChild(0).GetComponent<NoteCheck>().color;

                    data.notes.Add(beat);
                }
            }
        }


        string song = JsonUtility.ToJson(data);
        Debug.Log(Application.persistentDataPath + "/" + data.artist_name + "_" + data.song_name + ".json");
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + data.artist_name + "_" + data.song_name + ".json", song);
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


    public List<note> notes;
}

[System.Serializable]
public class note
{
    public Vector3 measurePos;
    public int parentNum;
    public enum Color
    {
        red = 0, 
        blue, 
        yellow
    };

    public Color color;
}
