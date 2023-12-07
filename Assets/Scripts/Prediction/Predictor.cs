using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Predictor : MonoBehaviour
{
    public ScaleDetector scaleDetector;
    public ChordDetector chordDetector;
    public int transpose = 0;
    public TextMeshPro TMP;
    public bool debug = false;
    public string prevChordName = "N.C.";
    public string currentChordName = "N.C.";

    void Predict()
    {
        currentChordName = chordDetector.ChordName;
        TMP.text = PythonUnity.Predict(prevChordName, currentChordName, transpose);
        if (debug)
        {
            Debug.Log(PythonUnity.Predict(prevChordName, currentChordName, transpose));
        }
        if (currentChordName != prevChordName)
        {
            prevChordName = currentChordName;
        }
    }

    private void OnEnable()
    {
        ScaleDetector.OnChordDetected += Predict;
    }
    private void OnDisable()
    {
        ScaleDetector.OnChordDetected -= Predict;
    }
}
