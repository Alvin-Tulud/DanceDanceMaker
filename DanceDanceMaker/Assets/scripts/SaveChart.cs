using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChart : MonoBehaviour
{
    public Transform Measures;

    [SerializeField]
    SongData data = new SongData();
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

        


        string song = JsonUtility.ToJson(data);
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
    public int parentNum;
    public enum Color
    {
        red, 
        blue, 
        yellow
    };

}
