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
        StreamReader errorReader = process.StandardError; // 標準エラー読み取り用
        string output = streamReader.ReadToEnd(); // ReadToEndに変更
        string error = errorReader.ReadToEnd(); // エラーメッセージの読み取り

        streamReader.Close();
        errorReader.Close(); // エラーリーダーをクローズ
        process.WaitForExit();
        process.Close();

        // エラーの確認とログ出力
        if (!string.IsNullOrEmpty(error))
        {
            UnityEngine.Debug.LogError("Python Error: " + error);
        }
        return output;
    }
}
