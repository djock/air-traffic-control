using UnityEngine;
using System.Collections;

public class SubmitDetails : MonoBehaviour {

	public UIPanel preTest;

    void OnClick()
    {
        AppManager.Instance.uiUserDetails.GetUserDetails();
		UIWindow.Show(preTest);
    }
}
