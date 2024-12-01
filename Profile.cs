using UnityEngine;
using TMPro;
public class Profile : MonoBehaviour
{
    public TMP_InputField dailyTarget;
    public TMP_InputField weeklyTarget;
    public TMP_InputField weight;

    public TMP_Text dailyNumber;
    public TMP_Text weeklyNumber;
    public TMP_Text weightNumber;

    public GameObject errorBox;
    public TMP_Text errorText;
    public GameObject inputFields;
    public GameObject numbers;

    private string dailyKey = "Daily Target";
    private string weeklyKey = "Weekly Target";
    private string weightKey = "Weight";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        inputFields.SetActive(false);
        numbers.SetActive(true);
        errorBox.SetActive(false);
        LoadProfileInfo();
    }

    void LoadProfileInfo()
    {
        if(PlayerPrefs.HasKey(dailyKey) && PlayerPrefs.HasKey(weeklyKey) && PlayerPrefs.HasKey(weightKey))
        {
            dailyNumber.text = PlayerPrefs.GetInt(dailyKey, 0).ToString();
            weeklyNumber.text = PlayerPrefs.GetInt(weeklyKey, 0).ToString();
            weightNumber.text = PlayerPrefs.GetInt(weightKey, 0).ToString();
        }
    }


    public void OnSave()
    {
        if(int.TryParse(dailyTarget.text, out int dTarget))
        {
            if (int.TryParse(weeklyTarget.text, out int wTarget))
            {
                if (int.TryParse(weight.text, out int userWeight))
                {
                    PlayerPrefs.SetInt(dailyKey, dTarget);
                    PlayerPrefs.SetInt(weeklyKey, wTarget);
                    PlayerPrefs.SetInt(weightKey, userWeight);
                    inputFields.SetActive(false);
                    numbers.SetActive(true);
                    LoadProfileInfo();
                    errorBox.SetActive(false);
                }
                else
                {
                    errorBox.SetActive(true);
                    errorText.text = "Please Enter Number For weight Target";
                }

            }
            else
            {
                errorBox.SetActive(true);
                errorText.text = "Please Enter Number For Weekly Target";
            }

        }
        else
        {
            errorBox.SetActive(true);
            errorText.text = "Please Enter Number For Daily Target";
        }

        

        

    }

    public void OnEdit()
    {
        inputFields.SetActive(true);
        numbers.SetActive(false);
    }
}
