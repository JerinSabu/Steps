using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hour : MonoBehaviour
{
    public GameManager gameManager;
    private DataManager dataManager;
    public Image[] hourlyBar = new Image[24];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dataManager = gameManager.GetComponent<DataManager>();
        
        for(int i = 0; i < 23; i++)
        {
            hourlyBar[i].fillAmount = (dataManager.LoadStepsByHour(i.ToString()) / 500);


        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
