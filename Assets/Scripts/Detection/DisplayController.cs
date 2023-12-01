using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayController : MonoBehaviour
{
    public TextMeshProUGUI ChordName;
    public TextMeshProUGUI ScaleName;
    public TextMeshProUGUI Degree;

    public ChordDetector chordDetector;
    public ScaleDetector scaleDetector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChordName.text = chordDetector.ChordName;
        ScaleName.text = scaleDetector.scaleName;
        Degree.text = scaleDetector.degreeName;
    }
}
