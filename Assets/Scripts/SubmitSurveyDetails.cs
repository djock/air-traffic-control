using UnityEngine;
using System.Collections;

public class SubmitSurveyDetails : MonoBehaviour {

    public UIPanel endScreen;

    void OnClick()
    {
        AppManager.Instance.uiSurvey.GetSurveyResults();
        UIWindow.Show(endScreen);
    }
   
}
