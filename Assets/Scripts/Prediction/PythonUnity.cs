using System.Diagnostics;
using System.IO;
using UnityEngine;

public class PythonUnity
{
    [SerializeField]
    readonly private static string pyExePath = @"C:\Users\Masato Takagi\AppData\Local\Programs\Python\Python310\python.exe";
    [SerializeField]
    readonly private static string pyCodePath = @"G:\repo\AR_Piano\Assets\Scripts\Prediction\triGram.py";
    // Start is called before the first frame update
    public static string Predict(string arg1, string arg2, int arg3)
    {
        ProcessStartInfo psi = new ProcessStartInfo(pyExePath)
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            Arguments = $"\"{pyCodePath}\" \"{arg1}\" \"{arg2}\"\"{arg3}\""
        };

        Process process = Process.Start(psi);

        StreamReader streamReader = process.StandardOutput;
        StreamReader errorReader = process.StandardError; // �W���G���[�ǂݎ��p
        string output = streamReader.ReadToEnd(); // ReadToEnd�ɕύX
        string error = errorReader.ReadToEnd(); // �G���[���b�Z�[�W�̓ǂݎ��

        streamReader.Close();
        errorReader.Close(); // �G���[���[�_�[���N���[�Y
        process.WaitForExit();
        process.Close();

        // �G���[�̊m�F�ƃ��O�o��
        if (!string.IsNullOrEmpty(error))
        {
            UnityEngine.Debug.LogError("Python Error: " + error);
        }
        return output;
    }
}
