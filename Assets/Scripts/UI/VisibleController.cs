using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class VisibleController : MonoBehaviour
{
    [SerializeField]
    private Renderer keyboardAR;
    [SerializeField]
    private Renderer chordName;
    [SerializeField]
    private Renderer scaleName;
    [SerializeField]
    private Renderer chordPredictor;
    [SerializeField]
    private Renderer emoticon;


    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.digit0Key.wasPressedThisFrame) 
            {
                keyboardAR.enabled = false;
                chordName.enabled = false;
                scaleName.enabled = false;
                chordPredictor.enabled = false;
            }
            if (keyboard.digit1Key.wasPressedThisFrame)
            {
                keyboardAR.enabled = !keyboardAR.enabled;
            }
            if (keyboard.digit2Key.wasPressedThisFrame)
            {
                chordName.enabled = !chordName.enabled;
            }
            if (keyboard.digit3Key.wasPressedThisFrame)
            {
                scaleName.enabled = !scaleName.enabled;
            }
            if (keyboard.digit4Key.wasPressedThisFrame)
            {
                chordPredictor.enabled = !chordPredictor.enabled;
            }
            if (keyboard.digit5Key.wasPressedThisFrame)
            {
                emoticon.enabled = !emoticon.enabled;
            }
        }
    }

}