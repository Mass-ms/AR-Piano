using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class KeyboardMover : MonoBehaviour
{
    private GameObject obj;
    private Transform _transform;
    //ts = transform scale
    [SerializeField]
    float ts = 1.0f;
    //rs = rotate scale (degree)
    [SerializeField]
    float rs = 30f;

    void Start()
    {
        obj = this.gameObject;
        _transform = transform;
    }
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            //x-y 
            if (keyboard.wKey.wasPressedThisFrame)
            {
                obj.transform.position += ts*_transform.forward;
            }
            if (keyboard.aKey.wasPressedThisFrame)
            {
                obj.transform.position += -ts*_transform.right;
            }
            if (keyboard.dKey.wasPressedThisFrame)
            {
                obj.transform.position += ts*_transform.right;
            }
            if (keyboard.sKey.wasPressedThisFrame)
            {
                obj.transform.position += -ts*_transform.forward;
            }
            //z
            if (keyboard.qKey.wasPressedThisFrame)
            {
                obj.transform.position += ts*_transform.up;
            }
            if (keyboard.eKey.wasPressedThisFrame)
            {
                obj.transform.position += -ts*_transform.up;
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
                obj.transform.localScale += new Vector3(ts,ts,ts);
            }
            if (keyboard.zKey.wasPressedThisFrame)
            {
                obj.transform.localScale -= new Vector3(ts,ts,ts);
            }

        }
    }
}