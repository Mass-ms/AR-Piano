using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordDetector : MonoBehaviour
{
    public ChordManager chordManager;
    public string ChordName = "N.C.";
    public bool debug = false;

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
        if (debug)
        {
            Debug.Log(chordName);
        }
    }
}
