using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordDetector : MonoBehaviour
{
    public ChordManager chordManager;
    public string ChordName = "N.C.";
    public string prevChordName = "N.C.";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static event Action OnChordDetected;

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
        OnChordDetected?.Invoke();
        Debug.Log(chordName);
    }
}
