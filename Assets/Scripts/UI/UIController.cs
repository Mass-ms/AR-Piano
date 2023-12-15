using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshPro chord;
    public TextMeshPro degree;
    public TextMeshPro key;
    public TextMeshPro scale;

    public ChordDetector chordDetector;
    public ScaleDetector scaleDetector;
    public ScaleManager scaleManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setChordName(chordDetector.ChordName);
        setDegreeName(scaleDetector.degreeName);
        setKeyName(scaleManager.Key);
        setScaleName(scaleDetector.scaleName);
    }

    void setChordName(string chordName)
    {
        chord.text = chordName;
    }

    void setDegreeName(string degreeName)
    {
        degree.text = degreeName;
    }

    void setKeyName(string keyName)
    {
        key.text = "Key:" + keyName;
    }
    void setScaleName(string scaleName)
    {
        scale.text = scaleName;
    }
}
