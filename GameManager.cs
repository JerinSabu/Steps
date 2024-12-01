using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject introConvas;
    public GameObject simulatorCanvas;
    public GameObject mainCanvas;
    public bool simulator = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void GoToSimulator()
    {
        introConvas.SetActive(false);
        simulatorCanvas.SetActive(true);
        simulator = true;
    }

    public void GoToApp()
    {
        simulator = false;
        introConvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    
}
