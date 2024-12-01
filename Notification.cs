using System;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    public TMP_Text notificationText;
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
        if(currentSteps/dailyTarget <= 0.25)
        {
            notificationText.text = "Let's Get Started !";
        }

        if (currentSteps / dailyTarget > 0.25f && currentSteps / dailyTarget <= 0.5f)
        {
            notificationText.text = "Keep Going, You've got this!!";

        }
        if (currentSteps / dailyTarget > 0.5f && currentSteps / dailyTarget < 1.0f)
        {
            notificationText.text = "Almost There, Let's Go!!";
        }
        if(currentSteps / dailyTarget > 1f)
        {
            notificationText.text = "Good Work, Now Let's Take it easy";

        }

    }
}
