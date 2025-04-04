using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChart : MonoBehaviour
{
    public Transform Measures;

    public SongData writeData = new SongData();
    public SongData readData = new SongData();
    string filepath;

    public List<GameObject> Arrows = new List<GameObject>();

    public TimeSig TimeSig;

    // Start is called before the first frame update
    void Awake()
    {
        filepath = Application.persistentDataPath + "/" + writeData.artist_name + "_" + writeData.song_name + "_" + writeData.difficulty_name + ".json";
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

        write();

        string song = JsonUtility.ToJson(writeData);
        System.IO.File.WriteAllText(filepath, song);
    }

    public void loadData()
    {
        string song = System.IO.File.ReadAllText(filepath);
        readData = JsonUtility.FromJson<SongData>(song);

        read();
    }

    public void write()
    {
        writeData.notes.Clear();

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
                    beat.color = (note.Color)noteSpot.GetChild(0).GetComponent<NoteCheck>().color;

                    writeData.notes.Add(beat);
                }
            }
        }
    }

    public void read()
    {
        //spawn in the subdivision
        TimeSig.slider.value = readData.subdivision;

        //spawn the notes onto the measures
        if (readData.notes.Count != 0)
        {
            //for each measure and while less than notes that are saved
            for (int i = 0; i < Measures.childCount; i++)
            {
                Transform measure = Measures.GetChild(i).transform;

                for (int readNoteIter = 0; readNoteIter < readData.notes.Count; readNoteIter++)
                {
                    //figure out of multiple notes are on same measure
                    if (measure.localPosition == readData.notes[readNoteIter].measurePos)
                    {
                        Transform parent = measure.GetChild(readData.notes[readNoteIter].parentNum);

                        GameObject arrow = Instantiate(Arrows[(int)readData.notes[readNoteIter].color]);

                        arrow.transform.position = Vector3.zero;
                        arrow.GetComponent<NoteCheck>().enabled = false;
                        arrow.transform.SetParent(parent, false);

                        readNoteIter++;
                    }
                }
            }
        }
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
