using UnityEngine;
using System.Collections;

public class DeletePrefs : MonoBehaviour {

    void OnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
