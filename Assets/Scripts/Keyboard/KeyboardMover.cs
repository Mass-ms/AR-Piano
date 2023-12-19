using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class KeyboardMover : MonoBehaviour
{
    private GameObject obj;
    //ts = transform scale
    float ts = 1.0f;
    //rs = rotate scale (degree)
    float rs = 30f;
    void Start()
    {
        obj = this;
    }
    void Update()
    {
        var keyboard = KeyboardMover.current;
        if (keyboard != null)
        {
            //x-y 
            if (keyboard.wKey.wasPressedThisFrame)
            {
                obj.transform.potision += ts*obj.transform.potision.forward;
            }
            if (keyboard.aKey.wasPressedThisFrame)
            {
                obj.transform.potision += -ts*obj.transform.potision.right;
            }
            if (keyboard.dKey.wasPressedThisFrame)
            {
                obj.transform.potision += ts*obj.transform.potision.right;
            }
            if (keyboard.sKey.wasPressedThisFrame)
            {
                obj.transform.potision += -ts*obj.transform.potision.forward;
            }
            //z
            if (keyboard.qKey.wasPressedThisFrame)
            {
                obj.transform.potision += ts*obj.transform.potision.up;
            }
            if (keyboard.eKey.wasPressedThisFrame)
            {
                obj.transform.potision += -ts*obj.transform.potision.up;
            }
            //rotation
            if (keyboard.rKey.wasPressedThisFrame)
            {
                obj.transform.Rotate(0f,rs,0f);
            }
            if (keyboard.fKey.wasPressedThisFrame)
            {
                obj.transform.Rotate(rs,0f,0f);
            }
            //scale up/down
            if (keyboard.xKey.wasPressedThisFrame)
            {
                obj.transform.localScale += new vector3(ts,ts,ts);
            }
            if (keyboard.zKey.wasPressedThisFrame)
            {
                obj.transform.localScale -= new vector3(ts,ts,ts);
            }

        }
    }
}