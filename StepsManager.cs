using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Drawing;
using static UnityEngine.Rendering.DebugUI.Table;

public class StepsManager : MonoBehaviour
{
    
    public TMP_Text totalSteps;
    private ConnectionManager connectionManager;
    public GameObject gameManager;
    private DataManager dataManager;
    public int stepCount = 0;
    private string todaysDate;
    
    public Image circularProgressImage;
    public Image[] weeklyBar = new Image[7];
    public GameObject histroy;
    public GameObject Home;
    public GameObject Profile;
    public TMP_Text weeklySteps;

    public TMP_Text calories;
    public TMP_Text distance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        connectionManager = gameManager.GetComponent<ConnectionManager>();
        dataManager = gameManager.GetComponent<DataManager>();
        DateTime now = DateTime.Now;
        todaysDate = now.Year.ToString() + now.Month.ToString() + now.Day.ToString();
        histroy.SetActive(false);
        Home.SetActive(true);
        Profile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // receiving and saving step count and showing the step count
        
        if(int.TryParse(connectionManager.currentMessage.ToString(), out int result))
        {
            totalSteps.text = connectionManager.currentMessage.ToString();
            stepCount = int.Parse(connectionManager.currentMessage.ToString());
            
            dataManager.SaveWithDate(todaysDate, stepCount);
        }

        else
        {
            
            stepCount = dataManager.LoadStepsWithDate(todaysDate);
            totalSteps.text = stepCount.ToString();


        }



        // saving data every hour
        DateTime now = DateTime.Now;
        if(now.Minute == 59 && now.Second == 59)
        {
            SaveDataPerHour();
        }


        
        UpdateTheCircle();
        UpdateCalories();
        UpdateDistance();
        
    }



    void UpdateTheCircle()
    {
        //converts the step count to float and gets the progress to the actual goal
        float stepsInFloat = stepCount;
        float targetSteps = PlayerPrefs.GetInt("Daily Target");
        float progressSteps = stepsInFloat / targetSteps;
        circularProgressImage.fillAmount = progressSteps;
    }

    void SaveDataPerHour()
    {
        DateTime now = DateTime.Now;
        int previousHour = now.Hour - 1;
        int stepsToReduce = 0;
        for (int i = previousHour; i <= 00; i--)
        {
            stepsToReduce = stepsToReduce + dataManager.LoadStepsByHour(i.ToString());

        }

        int stepsInTheHour = stepCount - stepsToReduce;
        dataManager.SaveStepsByHour(now.Hour.ToString(), stepsInTheHour);

    }

    public void HistoryClicked()
    {
        histroy.SetActive(true);
        Home.SetActive(false);
        Profile.SetActive(false);
        //WeekClicked();


    }

    
    
    public void WeekClicked()
    {
        ShowLast7Days();
        int[] stepsInTheLastWeek = GetStepsOfCurrentWeek();
        int totalStepsInTheWeek = 0;
        for (int i = 0; i < 7; i++)
        {
            totalStepsInTheWeek += stepsInTheLastWeek[i];
        }

        weeklySteps.text = totalStepsInTheWeek.ToString();
    }

    public void HomeClicked()
    {
        histroy.SetActive(false);
        Home.SetActive(true);
        Profile.SetActive(false);

    }
    
    public void ProfileClicked()
    {
        histroy.SetActive(false);
        Home.SetActive(false);
        Profile.SetActive(true);
    }

    public void ShowLast7Days()
    {
        int[] stepsInTheLastWeek = GetStepsOfCurrentWeek();
        float dailyTarget = PlayerPrefs.GetInt("Daily Target");
        for(int i = 0; i < 7 ; i++)
        {
            float weekSteps = stepsInTheLastWeek[i];
            weeklyBar[i].fillAmount = weekSteps / dailyTarget;
        }
    }


    int[] GetStepsOfCurrentWeek()
    {
        int[] stepCounts = new int[7];
        DateTime currentDate = DateTime.Now;
        for (int i = 0; i< 7; i++)
        {
            DateTime targetDate = currentDate.AddDays(-i);
            string dateKey = targetDate.ToString("yyyyMMdd");

            if (PlayerPrefs.HasKey(dateKey))
            {
                stepCounts[i] = dataManager.LoadStepsWithDate(dateKey);
            }
            else
            {
                // Default value for missing data
                stepCounts[i] = 0;
            }


        }
        return stepCounts;


    }

    void UpdateDistance()
    {
        float stepsInFloat = stepCount;
        distance.text = (stepsInFloat * 0.00068475f).ToString().Substring(0,4) + "Km";
    }

    void UpdateCalories()
    {
        float weightInFloat = PlayerPrefs.GetInt("weight", 0);
        float stepsInFloat = stepCount;
        calories.text = (stepsInFloat * 3.5f * weightInFloat * 0.0005f).ToString();
    }
}
