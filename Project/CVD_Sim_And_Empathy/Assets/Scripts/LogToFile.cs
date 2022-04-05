using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogToFile : MonoBehaviour
{
    private string filename;
    private TextWriter tw;
    public bool isOn = false;
    private bool logEnabled = false;
    private long startTime;

    void OnEnable()
    {
        filename += "./DataLogs/" + System.DateTime.Now.ToString("dddd dd MMMM yyyy HH mm ss") + ".txt";
        if (isOn)
        {
            Application.logMessageReceived += Log;
            startTime = GetTimeInMillis();
            Debug.Log("Log Enable");
            logEnabled = true;
        }
    }

    void OnDisable()
    {
        if (logEnabled)
        {
            Debug.Log("Log Disable");
            Application.logMessageReceived -= Log;
            logEnabled = false;
        }
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        tw = new StreamWriter(filename, true);
        tw.WriteLine((GetTimeInMillis() - startTime).ToString() + "," + logString);
        tw.Close();
    }

    public long GetTimeInMillis()
    {
        System.DateTime now = System.DateTime.Now;
        return ((((now.Hour * 60) + now.Minute) * 60) + now.Second ) * 1000 + now.Millisecond;
    }
}
