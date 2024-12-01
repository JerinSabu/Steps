using UnityEngine;
using TMPro;
using System.Collections;


public class Simulator : MonoBehaviour
{
    private int totalSteps = 0;
    private int steps = 0;
    public TMP_Text displaySteps;
    public TMP_Text displayTotalSteps;
    public GameObject gameManager;
    private ConnectionManager connectionManager;

    IEnumerator StepSimulator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            steps = Random.Range(1, 5); // Random steps per update
            totalSteps += steps; //total steps
            displaySteps.text = steps.ToString();  // steps generated is diplayed for testing
            displayTotalSteps.text = totalSteps.ToString(); //total steps is displayed for testing
            connectionManager.SendChatMessage(totalSteps.ToString()); //totals steps is posted the connected channel
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        connectionManager = gameManager.GetComponent<ConnectionManager>();
        StartCoroutine(StepSimulator());
    }



    
}
