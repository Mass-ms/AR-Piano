using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshPro key;
    public TextMeshPro chord;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setKeyName(string keyName)
    {
        key.text = keyName;
    }

    void setChordName(string chordName)
    {
        chord.text = chordName;
    }
}
