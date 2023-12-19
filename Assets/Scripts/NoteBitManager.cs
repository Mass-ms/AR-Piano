using System.Collections;
using System;
using UnityEngine;

public class NoteBitManager : MonoBehaviour
{
    public ChordDetector chordDetector;
    public ScaleDetector scaleDetector;
    public bool debug = false;
    private ushort currentBit = 0b_0000_0000_0000_0000;
    private ushort currentMelodyBit = 0b_0000_0000_0000_0000;

    public void initCurrentBit()
    {
        currentBit = 0b_0000_0000_0000_0000;
        Debug.Log(ToString());
    }
    public void initCurrentMelodyBit()
    {
        currentMelodyBit = 0b_0000_0000_0000_0000;
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

    public void setCurrentMelodyBit(ushort NoteNum)
    {
        ushort bit = 0b_1000_0000_0000_0000;

        ushort shift = (ushort)(NoteNum%12);

        bit = (ushort)(bit >> shift);

        currentMelodyBit = (ushort)(currentMelodyBit | bit);
        if (debug)
        {
            Debug.Log(ToString());
        }
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

    public void clearCurrentMelodyBit(ushort NoteNum)
    {
        ushort bit = 0b_1000_0000_0000_0000;

        ushort shift = (ushort)(NoteNum % 12);

        bit = (ushort)(bit >> shift);

        currentMelodyBit = (ushort)(currentMelodyBit & ~bit);
        if (debug)
        {
            Debug.Log(ToString());
        }
    }

    public ushort getCurrentBit()
    { return currentBit; }

    public ushort getCurrentMelodyBit()
    { return currentMelodyBit; }

    override public string ToString()
    {
        string binaryString = Convert.ToString(currentBit, 2).PadLeft(16, '0'); // 16�r�b�g�̃o�C�i��������
        string formattedBinaryString = "0b_" + InsertUnderscores(binaryString);
        return formattedBinaryString;
    }

    static string InsertUnderscores(string binaryString)
    {
        // 4�����ɃA���_�[�X�R�A��}��
        for (int i = binaryString.Length - 4; i > 0; i -= 4)
        {
            binaryString = binaryString.Insert(i, "_");
        }
        return binaryString;
    }

}
