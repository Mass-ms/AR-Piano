using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class PythonUnity : MonoBehaviour
{
    [SerializeField]
    readonly private static string pyExePath = null;
    [SerializeField]
    readonly private static string pyCodePath = null;
    // Start is called before the first frame update
    static string Predict(string arg1, string arg2)
    {
        ProcessStartInfo psi = new ProcessStartInfo(pyExePath)
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = pyCodePath + " " + arg1 + arg2
        };

        Process process = Process.Start(psi);

        StreamReader streamReader = process.StandardOutput;
        string output = streamReader.ReadLine();

        streamReader.Close();
        process.WaitForExit();
        process.Close();

        return output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
