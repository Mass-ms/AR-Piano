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

    Dictionary<int, string> keyDict = new Dictionary<int, string>()
    {
        {0,"C/Am" },
        {1,"Db/Bbm" },
        {2,"D/Bm" },
        {3,"Eb/Cm" },
        {4,"E/C#m" },
        {5,"F/Dm" },
        {6,"Gb/Ebm" },
        {7,"G/Em" },
        {8,"Ab/Fm" },
        {9,"A/F#m" },
        {10,"Bb/Gm" },
        {11,"B/G#m" },
     };



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setChordName(chordDetector.ChordName);
        setDegreeName(scaleDetector.degreeName);
        setKeyName(scaleManager.transpose);
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

    void setKeyName(int keyNum)
    {
        key.text = "Key:" + keyDict[keyNum];
    }
    void setScaleName(string scaleName)
    {
        scale.text = scaleName;
    }
}
