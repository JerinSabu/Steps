using System;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    public TMP_Text progressPercentage;
    public TMP_Text progressFraction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dailyTarget = PlayerPrefs.GetInt("Daily Target");
        DateTime now = DateTime.Now;
        string todaysDate = now.Year.ToString() + now.Month.ToString() + now.Day.ToString();
        float currentSteps = PlayerPrefs.GetInt(todaysDate);
        progressPercentage.text = (currentSteps/dailyTarget * 100f).ToString().Substring(0,5);

        progressFraction.text = currentSteps.ToString() + "/" + dailyTarget.ToString();
    }
}
