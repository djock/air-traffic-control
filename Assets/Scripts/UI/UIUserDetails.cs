using UnityEngine;
using System.Collections;
using System;
using Parse;

public class UIUserDetails : MonoBehaviour {



    private string ageValue;
    private string nationalityValue;
    private string gender = "";
    private string goodSight = "";
    private int rested;

    [Header("Panels")]
    public UIPanel informationPanel;
    public UIPanel preTestPanel;
    public UIPanel endScreen;

    [Header("Components")]

    public UILabel dateLabel;
    public UIInput age;
    public UIInput nationality;

    [Header("Gender Toggle")]
    public UIToggle genderMale;
    public UIToggle genderFemale;

    [Header("Sight Toggle")]
    public UIToggle goodSightYes;
    public UIToggle goodSightNo;

    [Header("Energy Toggle")]
    public UIToggle option1;
    public UIToggle option2;
    public UIToggle option3;
    public UIToggle option4;
    public UIToggle option5;
    public UIToggle option6;
    public UIToggle option7;
    public UIToggle option8;
    public UIToggle option9;
    public UIToggle option10;


    [Header("Public Elements")]
    public UIToggle hasAgreed;

    public UILabel errorMessage;

    //ParseObject userDetails = new ParseObject("UserDetails");

    void OnEnable()
    {

        AppManager.Instance.CheckForUserId();
        AppManager.Instance.CheckForTestType();
        GetDate();
    }
    void GetDate()
    {
		DateTime today = DateTime.Today;
//		userDetails["date"] = today;
        //Debug.LogWarning(today.ToString("dd MMM yyyy"));
        dateLabel.text = "" + today.ToString("ddd, dd MMM yyyy");
    }

    public void GetUserDetails()
    {

		ParseObject userDetails = new ParseObject("UserDetails");

        ageValue = age.GetComponent<UIInput>().value;
        nationalityValue = nationality.GetComponent<UIInput>().value;

		DateTime today = DateTime.Today;


        GetGender();
        GetSightInfo();
        HowRested();

        if (ageValue == "" || nationalityValue == "" || gender == "" || goodSight == "" || !hasAgreed.value || rested == 0)
        {
            NGUITools.SetActive(errorMessage.gameObject, true);
        }
        else
        {
            if (goodSight == "no")
            {
                UIWindow.Show(endScreen);
            }
            else
            {
                Debug.LogWarning("======================================");
                Debug.Log("User ID: " + AppManager.Instance.userId);
                userDetails["user_id"] = AppManager.Instance.userId;

                Debug.Log("Test type: " + AppManager.Instance.testType);
                userDetails["test_type"] = AppManager.Instance.testType;

                Debug.Log("Age: " + ageValue);
                userDetails["age"] = ageValue;

				userDetails["date"] = today;

                Debug.Log("Gender: " + gender);
                userDetails["gender"] = gender;

                Debug.Log("Nationality: " + nationalityValue);
                userDetails["nationality"] = nationalityValue;

                Debug.Log("Has good sight: " + goodSight);
                userDetails["good_sight"] = goodSight;

                Debug.Log("User rated his energy: " + rested);
                userDetails["how_rested"] = rested;
                Debug.LogWarning("======================================");

                if (informationPanel.isActiveAndEnabled)
                {
                    NGUITools.SetActive(informationPanel.gameObject, false);
                }

                UIWindow.Show(preTestPanel);
                userDetails.SaveAsync();
            }
        }
    }

    void GetGender()
    {
        if (genderFemale.value)
        {
            gender = "female";
        }
        else if (genderMale.value)
        {
            gender = "male";
        }
    }

    void GetSightInfo()
    {
        if (goodSightYes.value)
        {
            goodSight = "yes";
        }
        else if (goodSightNo.value)
        {
            goodSight = "no";
        }
    }
    void HowRested()
    {
        if (option1.value)
        {
            rested = 1;
        }
        if (option2.value)
        {
            rested = 2;
        }
        if (option3.value)
        {
            rested = 3;
        }
        if (option4.value)
        {
            rested = 4;
        }
        if (option5.value)
        {
            rested = 5;
        }
        if (option6.value)
        {
            rested = 6;
        }
        if (option7.value)
        {
            rested = 7;
        }
        if (option8.value)
        {
            rested = 8;
        }
        if (option9.value)
        {
            rested = 9;
        }
        if (option10.value)
        {
            rested = 10;
        }

    }

}
