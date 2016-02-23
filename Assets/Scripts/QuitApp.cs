using UnityEngine;
using System.Collections;

public class QuitApp : MonoBehaviour {

    void OnClick()
    {
        Application.Quit();
        Debug.Log("App closed");
    }
}
