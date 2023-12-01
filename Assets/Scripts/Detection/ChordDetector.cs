using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordDetector : MonoBehaviour
{
    public ChordManager chordManager;
    public string ChordName = "";
    /*
    public static ChordDetector instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectChordName(ushort currentBit)
    {
        string chordName = "N.C.";

        foreach (Chord chord in chordManager.chordList)
        {
            if (chord.ChordStructure == currentBit)
            {
                chordName = chord.ChordName;
                break;
            }
        }
        ChordName = chordName;
        Debug.Log(chordName);
    }
}
