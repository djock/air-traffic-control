using UnityEngine;
using System.Collections;

public class NewUser : MonoBehaviour {

    public UIPanel userDetails;
    //public UIPanel mainMenu;
    //public UISprite main;

    void OnClick()
    {
        AppManager.Instance.AssignUserId();
        PlayerPrefs.SetInt("test_type", 100);
        Debug.Log(PlayerPrefs.GetInt("test_type"));
        
        Debug.Log("==========New User created==========");

        UIWindow.Show(userDetails);
        //StartCoroutine(CreateNewUser());
    }

   /* IEnumerator CreateNewUser()
    {
        yield return new WaitForSeconds(0.5f);
        UIWindow.Hide(mainMenu);
    }*/
}
