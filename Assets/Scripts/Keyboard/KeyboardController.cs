using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] keyboardComponent;
    [SerializeField] private bool[] keyboardHighlight;
    [SerializeField] int startKeyNumber;

    void Start()
    {
        Transform transform = this.transform;
        for (int i = 0; i < keyboardComponent.Length; i++) 
        {
            keyboardComponent[i].transform.Translate(Vector3.forward * i);
        }

        keyboardHighlight = new bool[keyboardComponent.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < keyboardComponent.Length;i++)
        {
            if (keyboardHighlight[i])
            {
                keyboardComponent[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.blue);
            }
            else
            {
                keyboardComponent[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.white);
            }
        }
    }

    void setHighlight(int keyNum)
    {
        keyboardHighlight[keyNum] = true;
    }
}
