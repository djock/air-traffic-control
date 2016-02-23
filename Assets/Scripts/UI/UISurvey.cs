using UnityEngine;
using System.Collections;
using System;
using Parse;

public class UISurvey : MonoBehaviour {

    [Header("Public")]
    public UILabel errorMessage;

    [Header("Question 1")]
    public UIToggle option1_1;
    public UIToggle option2_1;
    public UIToggle option3_1;
    public UIToggle option4_1;
    public UIToggle option5_1;
    public UIToggle option6_1;
    public UIToggle option7_1;
    public UIToggle option8_1;
    public UIToggle option9_1;
    public UIToggle option10_1;
    public UIToggle option11_1;
    public UIToggle option12_1;
    public UIToggle option13_1;
    public UIToggle option14_1;
    public UIToggle option15_1;
    public UIToggle option16_1;
    public UIToggle option17_1;
    public UIToggle option18_1;
    public UIToggle option19_1;
    public UIToggle option20_1;
    public UIToggle option21_1;

    [Header("Question 2")]
    public UIToggle option1_2;
    public UIToggle option2_2;
    public UIToggle option3_2;
    public UIToggle option4_2;
    public UIToggle option5_2;
    public UIToggle option6_2;
    public UIToggle option7_2;
    public UIToggle option8_2;
    public UIToggle option9_2;
    public UIToggle option10_2;
    public UIToggle option11_2;
    public UIToggle option12_2;
    public UIToggle option13_2;
    public UIToggle option14_2;
    public UIToggle option15_2;
    public UIToggle option16_2;
    public UIToggle option17_2;
    public UIToggle option18_2;
    public UIToggle option19_2;
    public UIToggle option20_2;
    public UIToggle option21_2;

    [Header("Question 3")]
    public UIToggle option1_3;
    public UIToggle option2_3;
    public UIToggle option3_3;
    public UIToggle option4_3;
    public UIToggle option5_3;
    public UIToggle option6_3;
    public UIToggle option7_3;
    public UIToggle option8_3;
    public UIToggle option9_3;
    public UIToggle option10_3;
    public UIToggle option11_3;
    public UIToggle option12_3;
    public UIToggle option13_3;
    public UIToggle option14_3;
    public UIToggle option15_3;
    public UIToggle option16_3;
    public UIToggle option17_3;
    public UIToggle option18_3;
    public UIToggle option19_3;
    public UIToggle option20_3;
    public UIToggle option21_3;

   [Header("Question 4")]
    public UIToggle option1_4;
    public UIToggle option2_4;
    public UIToggle option3_4;
    public UIToggle option4_4;
    public UIToggle option5_4;
    public UIToggle option6_4;
    public UIToggle option7_4;
    public UIToggle option8_4;
    public UIToggle option9_4;
    public UIToggle option10_4;
    public UIToggle option11_4;
    public UIToggle option12_4;
    public UIToggle option13_4;
    public UIToggle option14_4;
    public UIToggle option15_4;
    public UIToggle option16_4;
    public UIToggle option17_4;
    public UIToggle option18_4;
    public UIToggle option19_4;
    public UIToggle option20_4;
    public UIToggle option21_4;

    [Header("Question 5")]
    public UIToggle option1_5;
    public UIToggle option2_5;
    public UIToggle option3_5;
    public UIToggle option4_5;
    public UIToggle option5_5;
    public UIToggle option6_5;
    public UIToggle option7_5;
    public UIToggle option8_5;
    public UIToggle option9_5;
    public UIToggle option10_5;
    public UIToggle option11_5;
    public UIToggle option12_5;
    public UIToggle option13_5;
    public UIToggle option14_5;
    public UIToggle option15_5;
    public UIToggle option16_5;
    public UIToggle option17_5;
    public UIToggle option18_5;
    public UIToggle option19_5;
    public UIToggle option20_5;
    public UIToggle option21_5;

    [Header("Question 6")]
    public UIToggle option1_6;
    public UIToggle option2_6;
    public UIToggle option3_6;
    public UIToggle option4_6;
    public UIToggle option5_6;
    public UIToggle option6_6;
    public UIToggle option7_6;
    public UIToggle option8_6;
    public UIToggle option9_6;
    public UIToggle option10_6;
    public UIToggle option11_6;
    public UIToggle option12_6;
    public UIToggle option13_6;
    public UIToggle option14_6;
    public UIToggle option15_6;
    public UIToggle option16_6;
    public UIToggle option17_6;
    public UIToggle option18_6;
    public UIToggle option19_6;
    public UIToggle option20_6;
    public UIToggle option21_6;
    
    private int mentalDemand;
    private int physicalDemand;
    private int temporalDemand;
    private int performance;
    private int effort;
    private int frustration;

    ParseObject userSurvey = new ParseObject("UserSurvey");

   
    void MentalDemand()
    {
        if (option1_1.value)
        {
            mentalDemand = 1;
        }
        if (option2_1.value)
        {
            mentalDemand = 2;
        }
        if (option3_1.value)
        {
            mentalDemand = 3;
        }
        if (option4_1.value)
        {
            mentalDemand = 4;
        }
        if (option5_1.value)
        {
            mentalDemand = 5;
        }
        if (option6_1.value)
        {
            mentalDemand = 6;
        }
        if (option7_1.value)
        {
            mentalDemand = 7;
        }
        if (option8_1.value)
        {
            mentalDemand = 8;
        }
        if (option9_1.value)
        {
            mentalDemand = 9;
        }
        if (option10_1.value)
        {
            mentalDemand = 10;
        }
        if (option11_1.value)
        {
            mentalDemand = 11;
        }
        if (option12_1.value)
        {
            mentalDemand = 12;
        }
        if (option13_1.value)
        {
            mentalDemand = 13;
        }
        if (option14_1.value)
        {
            mentalDemand = 14;
        }
        if (option15_1.value)
        {
            mentalDemand = 15;
        }
        if (option16_1.value)
        {
            mentalDemand = 16;
        }
        if (option17_1.value)
        {
            mentalDemand = 17;
        }
        if (option18_1.value)
        {
            mentalDemand = 18;
        }
        if (option19_1.value)
        {
            mentalDemand = 19;
        }
        if (option20_1.value)
        {
            mentalDemand = 20;
        }
        if (option21_1.value)
        {
            mentalDemand = 21;
        }
    }

    void PhysicalDemand()
    {
        if (option1_2.value)
        {
            physicalDemand = 1;
        }
        if (option2_2.value)
        {
            physicalDemand = 2;
        }
        if (option3_2.value)
        {
            physicalDemand = 3;
        }
        if (option4_2.value)
        {
            physicalDemand = 4;
        }
        if (option5_2.value)
        {
            physicalDemand = 5;
        }
        if (option6_2.value)
        {
            physicalDemand = 6;
        }
        if (option7_2.value)
        {
            physicalDemand = 7;
        }
        if (option8_2.value)
        {
            physicalDemand = 8;
        }
        if (option9_2.value)
        {
            physicalDemand = 9;
        }
        if (option10_2.value)
        {
            physicalDemand = 10;
        }
        if (option11_2.value)
        {
            physicalDemand = 11;
        }
        if (option12_2.value)
        {
            physicalDemand = 12;
        }
        if (option13_2.value)
        {
            physicalDemand = 13;
        }
        if (option14_2.value)
        {
            physicalDemand = 14;
        }
        if (option15_2.value)
        {
            physicalDemand = 15;
        }
        if (option16_2.value)
        {
            physicalDemand = 16;
        }
        if (option17_2.value)
        {
            physicalDemand = 17;
        }
        if (option18_2.value)
        {
            physicalDemand = 18;
        }
        if (option19_2.value)
        {
            physicalDemand = 19;
        }
        if (option20_2.value)
        {
            physicalDemand = 20;
        }
        if (option21_2.value)
        {
            physicalDemand = 21;
        }
    }

    void TemporalDemand()
    {
        if (option1_3.value)
        {
            temporalDemand = 1;
        }
        if (option2_3.value)
        {
            temporalDemand = 2;
        }
        if (option3_3.value)
        {
            temporalDemand = 3;
        }
        if (option4_3.value)
        {
            temporalDemand = 4;
        }
        if (option5_3.value)
        {
            temporalDemand = 5;
        }
        if (option6_3.value)
        {
            temporalDemand = 6;
        }
        if (option7_3.value)
        {
            temporalDemand = 7;
        }
        if (option8_3.value)
        {
            temporalDemand = 8;
        }
        if (option9_3.value)
        {
            temporalDemand = 9;
        }
        if (option10_3.value)
        {
            temporalDemand = 10;
        }
        if (option11_3.value)
        {
            temporalDemand = 11;
        }
        if (option12_3.value)
        {
            temporalDemand = 12;
        }
        if (option13_3.value)
        {
            temporalDemand = 13;
        }
        if (option14_3.value)
        {
            temporalDemand = 14;
        }
        if (option15_3.value)
        {
            temporalDemand = 15;
        }
        if (option16_3.value)
        {
            temporalDemand = 16;
        }
        if (option17_3.value)
        {
            temporalDemand = 17;
        }
        if (option18_3.value)
        {
            temporalDemand = 18;
        }
        if (option19_3.value)
        {
            temporalDemand = 19;
        }
        if (option20_3.value)
        {
            temporalDemand = 20;
        }
        if (option21_3.value)
        {
            temporalDemand = 21;
        }
    }

    void Performance()
    {
        if (option1_4.value)
        {
            performance = 1;
        }
        if (option2_4.value)
        {
            performance = 2;
        }
        if (option3_4.value)
        {
            performance = 3;
        }
        if (option4_4.value)
        {
            performance = 4;
        }
        if (option5_4.value)
        {
            performance = 5;
        }
        if (option6_4.value)
        {
            performance = 6;
        }
        if (option7_4.value)
        {
            performance = 7;
        }
        if (option8_4.value)
        {
            performance = 8;
        }
        if (option9_4.value)
        {
            performance = 9;
        }
        if (option10_4.value)
        {
            performance = 10;
        }
        if (option11_4.value)
        {
            performance = 11;
        }
        if (option12_4.value)
        {
            performance = 12;
        }
        if (option13_4.value)
        {
            performance = 13;
        }
        if (option14_4.value)
        {
            performance = 14;
        }
        if (option15_4.value)
        {
            performance = 15;
        }
        if (option16_4.value)
        {
            performance = 16;
        }
        if (option17_4.value)
        {
            performance = 17;
        }
        if (option18_4.value)
        {
            performance = 18;
        }
        if (option19_4.value)
        {
            performance = 19;
        }
        if (option20_4.value)
        {
            performance = 20;
        }
        if (option21_4.value)
        {
            performance = 21;
        }
    }

    void Effort()
    {
        if (option1_5.value)
        {
            effort = 1;
        }
        if (option2_5.value)
        {
            effort = 2;
        }
        if (option3_5.value)
        {
            effort = 3;
        }
        if (option4_5.value)
        {
            effort = 4;
        }
        if (option5_5.value)
        {
            effort = 5;
        }
        if (option6_5.value)
        {
            effort = 6;
        }
        if (option7_5.value)
        {
            effort = 7;
        }
        if (option8_5.value)
        {
            effort = 8;
        }
        if (option9_5.value)
        {
            effort = 9;
        }
        if (option10_5.value)
        {
            effort = 10;
        }
        if (option11_5.value)
        {
            effort = 11;
        }
        if (option12_5.value)
        {
            effort = 12;
        }
        if (option13_5.value)
        {
            effort = 13;
        }
        if (option14_5.value)
        {
            effort = 14;
        }
        if (option15_5.value)
        {
            effort = 15;
        }
        if (option16_5.value)
        {
            effort = 16;
        }
        if (option17_5.value)
        {
            effort = 17;
        }
        if (option18_5.value)
        {
            effort = 18;
        }
        if (option19_5.value)
        {
            effort = 19;
        }
        if (option20_5.value)
        {
            effort = 20;
        }
        if (option21_5.value)
        {
            effort = 21;
        }
    }

    void Frustration()
    {
        if (option1_6.value)
        {
            frustration = 1;
        }
        if (option2_6.value)
        {
            frustration = 2;
        }
        if (option3_6.value)
        {
            frustration = 3;
        }
        if (option4_6.value)
        {
            frustration = 4;
        }
        if (option5_6.value)
        {
            frustration = 5;
        }
        if (option6_6.value)
        {
            frustration = 6;
        }
        if (option7_6.value)
        {
            frustration = 7;
        }
        if (option8_6.value)
        {
            frustration = 8;
        }
        if (option9_6.value)
        {
            frustration = 9;
        }
        if (option10_6.value)
        {
            frustration = 10;
        }
        if (option11_6.value)
        {
            frustration = 11;
        }
        if (option12_6.value)
        {
            frustration = 12;
        }
        if (option13_6.value)
        {
            frustration = 13;
        }
        if (option14_6.value)
        {
            frustration = 14;
        }
        if (option15_6.value)
        {
            frustration = 15;
        }
        if (option16_6.value)
        {
            frustration = 16;
        }
        if (option17_6.value)
        {
            frustration = 17;
        }
        if (option18_6.value)
        {
            frustration = 18;
        }
        if (option19_6.value)
        {
            frustration = 19;
        }
        if (option20_6.value)
        {
            frustration = 20;
        }
        if (option21_6.value)
        {
            frustration = 21;
        }
    }

    public void GetSurveyResults()
    {
        MentalDemand();
        PhysicalDemand();
        TemporalDemand();
        Performance();
        Effort();
        Frustration();

        if (mentalDemand == 0 || physicalDemand == 0 || temporalDemand == 0 || performance == 0 || effort == 0 || frustration == 0)
        {
            NGUITools.SetActive(errorMessage.gameObject, true);
        }

        else
        {
            Debug.Log("User ID: " + AppManager.Instance.userId);
            userSurvey["user_id"] = AppManager.Instance.userId;

            Debug.Log("Test type: " + AppManager.Instance.testType);
            userSurvey["test_type"] = AppManager.Instance.testType;

            Debug.Log("Mental Demand: " + mentalDemand);
            userSurvey["mental_demand"] = mentalDemand;

            Debug.Log("Physical Demand: " + physicalDemand);
            userSurvey["physical_demand"] = physicalDemand;

            Debug.Log("Temporal Demand: " + temporalDemand);
            userSurvey["temporal_demand"] = temporalDemand;

            Debug.Log("Performance: " + performance);
            userSurvey["performance"] = performance;

            Debug.Log("Effort: " + effort);
            userSurvey["effort"] = effort;

            Debug.Log("Frustration: " + frustration);
            userSurvey["frustration"] = frustration;

            userSurvey.SaveAsync();
        }
    }
}
