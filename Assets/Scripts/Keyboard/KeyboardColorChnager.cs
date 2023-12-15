using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardColorChnager : MonoBehaviour
{
    public GameObject[] objectsToColor; // 12 objects to change color
    public Color colorChord = new Color(0,255,0,94) ; // Color when bit is 1
    public Color colorTension = new Color(255, 255, 0, 94);
    public Color colorAvoid = new Color(255, 0, 0, 94);
    public Color colorOff = new Color(255,255,255,94); // Color when bit is 0
    public Color colorMelody = new Color(0,0,255,94);
    public ScaleDetector detector;
    public NoteBitManager noteBitManager;

    private void Start()
    {
        ChangeColorsBasedOnBits(0,0,0);
    }
    private void Update()
    {
        ChangeColorsBasedOnBits(detector.chordNote, detector.tensionNote, detector.avoidNote, noteBitManager.getCurrentMelodyBit());
    }

    // Use this method to change the colors based on a 16-bit integer
    public void ChangeColorsBasedOnBits(ushort chord,ushort tension,ushort avoid, ushort melody)
    {
        // Check if there are exactly 12 objects
        if (objectsToColor.Length != 12)
        {
            Debug.LogError("The objectsToColor array must contain exactly 12 elements.");
            return;
        }

        // Loop through each bit in the integer
        for (int i = 0; i < 12; i++)
        {
            // Create a mask to isolate bit i
            ushort mask = (ushort)(0b_1000_0000_0000_0000 >> i);

            // Check if the bit is 1 or 0 and change color accordingly
            bool isChord = (chord & mask) != 0;
            bool isTension = (tension & mask) != 0;
            bool isAvoid = (avoid & mask) != 0;
            bool isMelody = (avoid & mask) != 0;

            Color colorToApply = colorOff;
            if(isChord)
            {
                colorToApply = colorChord;
            }
            if (isTension)
            {
                colorToApply = colorTension;
            }
            if (isAvoid)
            {
                colorToApply = colorAvoid;
            }
            if (isMelody)
            {
                colorToApply = colorMelody;
            }

            // Assume the GameObject has a Renderer component
            Renderer renderer = objectsToColor[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                // Apply color to the renderer's material
                renderer.material.color = colorToApply;
            }
            else
            {
                Debug.LogError("No Renderer component found on the object " + objectsToColor[i].name);
            }
        }
    }
}
