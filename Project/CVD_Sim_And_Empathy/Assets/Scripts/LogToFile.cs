using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogToFile : MonoBehaviour
{
    private string filename;
    private TextWriter tw;
    private long startTime;

    void OnEnable()
    {
        filename += "./DataLogs/" + System.DateTime.Now.ToString("dddd dd MMMM yyyy HH mm ss") + ".txt";     
        startTime = GetTimeInMillis();    
    }

    public void DataLog(string logString)
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
