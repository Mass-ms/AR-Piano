using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ChordManager : MonoBehaviour
{
    /*
    public static ChordManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    */

    public ChordManager()
    {
        
    }

    private void Awake()
    {
        LoadJson();
    }

    public List<Chord> chordList = new List<Chord>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var chord in chordList)
        {
            Debug.Log($"ChordName: {chord.ChordName}, Structure: {chord.StrcutureToString()}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadJson()
    {
        var resources = Resources.LoadAll("ChordSet", typeof(TextAsset));

        foreach (TextAsset asset in resources) 
        {
            var chordsRawArray = JsonUtility.FromJson<ChordRawArray>(asset.text);
            
            foreach (ChordRaw chord in chordsRawArray.Chords)
            {
                chordList.Add(new Chord(chord.ChordName, chord.Structure));
            }
        }
    }
}
[Serializable]
public class ChordRaw
{
    public string ChordName;
    public string Structure;
}
[Serializable]
public class ChordRawArray
{
    public List<ChordRaw> Chords;
}

public class Chord
{
    public string ChordName;
    public ushort ChordStructure;

    public Chord(string chordName, ushort structure)
    {
        this.ChordName = chordName;
        this.ChordStructure = structure;
    }

    public Chord(string chordName, string structure) 
    {
        if (string.IsNullOrEmpty(chordName) || string.IsNullOrEmpty(structure))
        {
            throw new ArgumentException("ChordName and Structure cannot be null or empty.");
        }

        this.ChordName = chordName;
        this.ChordStructure = ConvertStrToUshort(structure);
    }

    public ushort ConvertStrToUshort(string structure)
    {
        structure = structure.Replace("0b", "");
        structure = structure.Replace("_", "");
        ushort convertedStructure = Convert.ToUInt16(structure, 2);
        return convertedStructure;
    }

    public string StrcutureToString()
    {
        string binaryString = Convert.ToString(ChordStructure, 2).PadLeft(16, '0'); // 16ビットのバイナリ文字列
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
