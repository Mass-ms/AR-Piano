using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBuffer : MonoBehaviour
{
    private noteStatus[] m_notes;
    [SerializeField] short noteRange = 88;
    void Start()
    {
        
    }

    void Awake()
    {
        InitializeNotes();
    }

    private void InitializeNotes()
    {
        m_notes = new noteStatus[noteRange];
        for (short i = 0; i < noteRange; i++)
        {
            m_notes[i] = new noteStatus(i);
        }
    }

    public void changeStatus(short noteNumber)
    {
        foreach (var note in m_notes)
        {
            if (note.getNoteNumber() == noteNumber)
            {
                note.changeStatus();
            }
        }
    }
}

class noteStatus
{
    private bool IsOn;
    private short NoteNumber;

    public noteStatus(short noteNumber)
    {
        IsOn = false;
        this.NoteNumber = noteNumber; 
    }

    public short getNoteNumber()
    {
        return NoteNumber;
    }

    public void changeStatus()
    {
        IsOn = !IsOn;
    }
}
