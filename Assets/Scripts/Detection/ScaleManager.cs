using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static Transposer;

public class ScaleManager : MonoBehaviour
{
    public List<Scale> scaleList = new List<Scale>();
    public int transpose = 0;
    public bool isSharp = true;
    public string Key;
    private string[,] keylist = { { "C/Am", "Db/Bbm", "D/Bm", "Eb/Cm", "Fb/Dbm", "F/Dm", "Gb/Ebm", "G/Em", "Ab/Fm", "Bbb/Gbm", "Bb/Gm", "Cb/Abm" }, { "C/Am", "C#/A#m", "D/Bm", "D#/B#m", "E/C#m", "F/Dm", "F#/D#m", "G/Em", "G#/E#m", "A/F#m", "A#/F*m", "B/G#m" } };
 
    // Start is called before the first frame update

    void Start()
    {
        foreach (var scale in scaleList)
        {
            //Debug.Log($"ScaleName: {scale.ScaleName}, DegreeName: {scale.DegreeName}");
            //Debug.Log($"ChordNote: {ToString(scale.ChordNote)}, TensionNote: {ToString(scale.TensionNote)}, AvoidNote: {ToString(scale.AvoidNote)}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.upArrowKey.wasPressedThisFrame) {
                transpose = (transpose+1)%12;
                Key = keylist[isSharp ? 1 : 0, transpose];
                LoadJson(transpose);
            }
            if (keyboard.downArrowKey.wasPressedThisFrame)
            {
                transpose = transpose > 0 ? (transpose - 1) % 12 : (transpose + 11) % 12;
                Key = keylist[isSharp ? 1 : 0, transpose];
                LoadJson(transpose);
            }
            if (keyboard.rightShiftKey.wasPressedThisFrame)
            {
                isSharp = !isSharp;
                Key = keylist[isSharp ? 1 : 0, transpose];
            }
        }
    }
    
    private void Awake()
    {
        LoadJson(transpose);
        Key = keylist[Convert.ToInt32(isSharp), transpose];
    }
    


    private void LoadJson(int transpose)
    {
        scaleList.Clear();
        var resouces = Resources.LoadAll("KeySet/Maj", typeof(TextAsset));
        ScaleNote  scaleNote = new ScaleNote();
        byte k = 0;
        foreach (TextAsset asset in resouces)
        {
            var KeyRaw = JsonUtility.FromJson<KeyRaw>(asset.text);
            
            byte n = 0;
            foreach (ScaleRaw  scale in  KeyRaw.Scales)
            {
                ushort chordNote = Transpose(ConvertStrToUshort(scale.ChordNote), transpose);
                ushort tensionNote = Transpose(ConvertStrToUshort(scale.TensionNote), transpose);
                ushort avoidNote = Transpose(ConvertStrToUshort(scale.AvoidNote), transpose);
                scaleList.Add(new Scale(scaleNote.noteList[k,transpose,n]+scale.ScaleName, scale.DegreeName, chordNote, tensionNote, avoidNote));
                n++;
            }
            k++;
        }
    }

    public ushort ConvertStrToUshort(string structure)
    {
        structure = structure.Replace("0b", "");
        structure = structure.Replace("_", "");
        ushort convertedStructure = Convert.ToUInt16(structure, 2);
        return convertedStructure;
    }

    public string ToString(ushort notes)
    {
        string binaryString = Convert.ToString(notes, 2).PadLeft(16, '0'); // 16ビットのバイナリ文字列
        string formattedBinaryString = "0b_" + InsertUnderscores(binaryString);
        return formattedBinaryString;
    }

    public string InsertUnderscores(string binaryString)
    {
        // 4桁毎にアンダースコアを挿入
        for (int i = binaryString.Length - 4; i > 0; i -= 4)
        {
            binaryString = binaryString.Insert(i, "_");
        }
        return binaryString;
    }
}


[Serializable]
public class ScaleRaw
{
    public string ScaleName;
    public string DegreeName;
    public string ChordNote;
    public string TensionNote;
    public string AvoidNote;
}
[Serializable]
public class KeyRaw
{
    public string Id;
    public string KeyName;
    public List<ScaleRaw> Scales;
}


public class Key
{
    readonly byte Id;
    readonly string KeyName;
    readonly List<Scale> Scales;
}

public class Scale
{
    public readonly string ScaleName;
    public readonly string DegreeName;
    public readonly ushort ChordNote;
    public readonly ushort TensionNote;
    public readonly ushort AvoidNote;

    public Scale(string scaleName, string degreeName, ushort chordNote, ushort tension, ushort avoid)
    {
        if (string.IsNullOrEmpty(scaleName) || string.IsNullOrEmpty(degreeName))
        {
            throw new ArgumentException("ScaleName and Scale Info cannot be null or empty.");
        }
        this.ScaleName = scaleName;
        this.DegreeName = degreeName;
        this.ChordNote = chordNote;
        this.TensionNote = tension;
        this.AvoidNote = avoid;
    }

    public Scale(string scaleName, string degreeName, string chordNote, string tension, string avoid)
    {
        if (string.IsNullOrEmpty(scaleName) || string.IsNullOrEmpty(chordNote) || string.IsNullOrEmpty(tension) || string.IsNullOrEmpty(avoid))
        {
            throw new ArgumentException("ScaleName and Scale Info cannot be null or empty.");
        }
        this.ScaleName = scaleName;
        this.DegreeName = degreeName;
        this.ChordNote = ConvertStrToUshort(chordNote);
        this.TensionNote = ConvertStrToUshort(tension);
        this.AvoidNote = ConvertStrToUshort(avoid);
    }

    public ushort ConvertStrToUshort(string structure)
    {
        structure = structure.Replace("0b", "");
        structure = structure.Replace("_", "");
        ushort convertedStructure = Convert.ToUInt16(structure, 2);
        return convertedStructure;
    }

}


