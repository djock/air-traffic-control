using UnityEngine;
using System.Collections;
using System;
using Parse;

public class AppManager : MonoBehaviour {


    string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    string[] Numbers = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    private string randomLetters;
    private string randomNumbers;

    public string userId;
    public string randomName;
	public string randomWaypointName;

    public int testType;

    [Header("Public Classes")]
    public UISurvey uiSurvey;
    public UIUserDetails uiUserDetails;
	public TestManager testManager;
    public TargetHelper targetHelper;
	public UIGridHelper uiGridHelper;
    public UITargetHolder uiTargetHolder;

	[Header("Test Managers")]
	public TestManager white;
	public TestManager black;

    [Header("Components")]
    public UILabel testWhite;
    public UILabel testBlack;
    public UILabel userIdLabel;
    


    public static AppManager Instance;

    void Awake()
    {
        Instance = this;
    }


    //Check if User ID is available:
    public void CheckForUserId()
    {
        if (PlayerPrefs.HasKey("user_id"))
        {
            userId = PlayerPrefs.GetString("user_id");
            userIdLabel.text = "" + PlayerPrefs.GetString("user_id");
            Debug.Log("Has ID: " + PlayerPrefs.GetString("user_id"));
        }
        else
        {
            AssignUserId();
        }
    }

    public void CheckForTestType()
    {
        if (PlayerPrefs.HasKey("test_type"))
        {
            if (PlayerPrefs.GetInt("test_type") == 0)
            {
                Debug.Log("Test White previously done => Test Black assigned");
                testType = 1;
                NGUITools.SetActive(testBlack.gameObject, true);
            }
            else if (PlayerPrefs.GetInt("test_type") == 1)
            {
                Debug.Log("Test Black previously done => Test White assigned");
                testType = 0;
                NGUITools.SetActive(testWhite.gameObject, true);
            }
            else
            {
                AssignTestType();
            }
        }
    }

    public void AssignRandomName()
    {
        randomLetters=Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]+Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]+Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
        randomNumbers=Numbers[UnityEngine.Random.Range(0, Numbers.Length)]+Numbers[UnityEngine.Random.Range(0, Numbers.Length)]+Numbers[UnityEngine.Random.Range(0, Numbers.Length)];

        randomName=randomLetters+randomNumbers;
    }

	public void AssignWaypointName()
	{
		randomLetters=Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]+Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]+Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]+Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]+Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
		randomWaypointName = randomLetters;
	}

    //Asign a Random ID to the user:
    public void AssignUserId()
    {
        AssignRandomName();
        userIdLabel.text = "" + randomName;
        Debug.Log("User ID: " + randomName);
            

        PlayerPrefs.SetString("user_id", randomName);
        PlayerPrefs.Save();
          
    }
    //Asign a Random test type to the user:
    public void AssignTestType()
    {
        
        testType = UnityEngine.Random.Range(0, 2);
        Debug.Log(testType);

        switch (testType)
        {
            case 0:

                Debug.Log("Test White assigned");
                PlayerPrefs.SetInt("test_type", testType);
                PlayerPrefs.Save();
                NGUITools.SetActive(testWhite.gameObject, true);
                break;

            case 1:

                Debug.Log("Test Black assigned");
                PlayerPrefs.SetInt("test_type", testType);
                PlayerPrefs.Save();
                NGUITools.SetActive(testBlack.gameObject, true);
                break;
            default:
                Debug.Log("No test was assigned.");
                break;
        }
    }

   
}
