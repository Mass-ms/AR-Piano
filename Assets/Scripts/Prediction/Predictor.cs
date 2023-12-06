using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Predictor : MonoBehaviour
{
    public ChordDetector chordDetector;
    public int transpose = 0;
    public TextMeshPro TMP;

    void Predict()
    {
        TMP.text = PythonUnity.Predict(chordDetector.prevChordName, chordDetector.ChordName, transpose);
    }

    private void OnEnable()
    {
        ChordDetector.OnChordDetected += Predict;
    }
    private void OnDisable()
    {
        ChordDetector.OnChordDetected -= Predict;
    }
}
