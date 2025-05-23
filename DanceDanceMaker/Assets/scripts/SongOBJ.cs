using UnityEngine;


[CreateAssetMenu(fileName = "SongOBJ", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SongOBJ : ScriptableObject
{
    public AudioClip song;
    public float bpm;
    public Vector3 songposition;
}
