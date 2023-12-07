using System.Collections;
using System;
using UnityEngine;

public class NoteBitManager : MonoBehaviour
{
    public ChordDetector chordDetector;
    public ScaleDetector scaleDetector;
    public bool debug = false;
    /*
    public static NoteBitManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    */
    // %12
    ushort currentBit = 0b_0000_0000_0000_0000;
    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
       
    }

    public void initCurrentBit()
    {
        currentBit = 0b_0000_0000_0000_0000;
        Debug.Log(ToString());
    }
    public void setCurrentBit(ushort NoteNum)
    {
        ushort bit = 0b_1000_0000_0000_0000;

        ushort shift = (ushort)(NoteNum%12);

        bit = (ushort)(bit >> shift);

        currentBit = (ushort)(currentBit | bit);
        if (debug)
        {
            Debug.Log(ToString());
        }
        chordDetector.DetectChordName(currentBit);
        scaleDetector.DetectScale(currentBit);
    }

    public void clearCurrentBit(ushort NoteNum) 
    {
        ushort bit = 0b_1000_0000_0000_0000;

        ushort shift = (ushort)(NoteNum % 12);

        bit = (ushort)(bit >> shift);

        currentBit = (ushort)(currentBit & ~bit);
        if (debug)
        {
            Debug.Log(ToString());
        }
        chordDetector.DetectChordName(currentBit);
        scaleDetector.DetectScale(currentBit); 
    }

    public ushort getCurrentBit()
    { return currentBit; }

    override public string ToString()
    {
        string binaryString = Convert.ToString(currentBit, 2).PadLeft(16, '0'); // 16ビットのバイナリ文字列
        string formattedBinaryString = "0b_" + InsertUnderscores(binaryString);
        return formattedBinaryString;
    }

    static string InsertUnderscores(string binaryString)
    {
        // 4桁毎にアンダースコアを挿入
        for (int i = binaryString.Length - 4; i > 0; i -= 4)
        {
            binaryString = binaryString.Insert(i, "_");
        }
        return binaryString;
    }

}
