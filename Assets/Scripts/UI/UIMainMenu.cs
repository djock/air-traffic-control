using UnityEngine;
using System.Collections;

public class UIMainMenu : MonoBehaviour {

    public UILabel userIdLabel;
    public UISprite logInButton;
    public UISprite wrongUserId;

    void OnEnable ()
    {
        Debug.Log( "User input: " + userIdLabel.text);
        Debug.Log("Previous user ID: " + PlayerPrefs.GetString("user_id"));
                
    }

    void Update()
    {
        if (userIdLabel.text == PlayerPrefs.GetString("user_id") && userIdLabel.text.Length == 6)
        {
            NGUITools.SetActive(logInButton.gameObject, true);
        }
    }


}
