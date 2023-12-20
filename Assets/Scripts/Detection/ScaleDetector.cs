using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleDetector : MonoBehaviour
{
    public ScaleManager scaleManager;
    public static event Action OnChordDetected;
    public string scaleName = "";
    public string degreeName = "";
    public ushort chordNote = 0;
    public ushort tensionNote = 0;
    public ushort avoidNote = 0;
    public int emoticonID = 0;
    public bool debug = false;

    private ushort bitMask = 0b_1111_1111_1111_0000;

    public void DetectScale(ushort currentBit)
    {
        foreach (Scale scale in scaleManager.scaleList)
        {
            if ((scale.ChordNote & bitMask) == currentBit)
            {
                scaleName = scale.ScaleName;
                degreeName = scale.DegreeName;
                chordNote = scale.ChordNote;
                tensionNote = scale.TensionNote;
                avoidNote = scale.AvoidNote;
                if (debug)
                {
                    Debug.Log($"Scale: {scale.ScaleName}, Degree:{scale.DegreeName}");
                }
                OnChordDetected?.Invoke();
                emoticonID = (scale.ChordNote & ~bitMask);
                break;
            }
            
        }
        
    }
}
