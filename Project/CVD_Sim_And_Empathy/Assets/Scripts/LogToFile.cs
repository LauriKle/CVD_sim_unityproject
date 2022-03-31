using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogToFile : MonoBehaviour
{
    private string filename;
    TextWriter tw;

   
    void Start()
    {
        filename += "./Logs/" + System.DateTime.Now + ".txt";
        tw = new StreamWriter(filename, true);
        Debug.Log("Log opened " + System.DateTime.Now);
        tw.WriteLine("Hello");
    }

    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        tw.WriteLine();
        tw.Close();
        Debug.Log("Log Closed");
    }
 
    void WriteToLog(string str)
    {
        tw.WriteLine(str);
    }
}
