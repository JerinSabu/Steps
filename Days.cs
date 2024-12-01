using System;
using TMPro;
using UnityEngine;

public class Days : MonoBehaviour
{
    
    public TMP_Text dayOne;
    public TMP_Text dayTwo;
    public TMP_Text dayThree;
    public TMP_Text dayFour;
    public TMP_Text dayFive;
    public TMP_Text daySix;
    public TMP_Text daySeven;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DateTime now = DateTime.Now;
        
        dayOne.text = now.AddDays(-6).DayOfWeek.ToString().Substring(0,3).ToUpper();
        dayTwo.text = now.AddDays(-5).DayOfWeek.ToString().Substring(0, 3).ToUpper();
        dayThree.text = now.AddDays(-4).DayOfWeek.ToString().Substring(0, 3).ToUpper();
        dayFour.text = now.AddDays(-3).DayOfWeek.ToString().Substring(0, 3).ToUpper();
        dayFive.text = now.AddDays(-2).DayOfWeek.ToString().Substring(0, 3).ToUpper();
        daySix.text = now.AddDays(-1).DayOfWeek.ToString().Substring(0, 3).ToUpper();
        daySeven.text = now.DayOfWeek.ToString().Substring(0, 3).ToUpper();


        
        
    }

   
}
