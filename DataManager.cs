using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private const string StepDataKey = "StepData";
    
    

    public void SaveWithDate(string currentDate, int steps)
    {
        PlayerPrefs.SetInt(currentDate, steps);

    }

    public int LoadStepsWithDate(string date)
    {
        return PlayerPrefs.GetInt(date, 0);
    }

    public void SaveStepsByHour(string hour,int steps)
    {
        PlayerPrefs.SetInt(hour, steps);
    }

    public int LoadStepsByHour(string hour)
    {
        return PlayerPrefs.GetInt(hour, 0);
    }
    

}
