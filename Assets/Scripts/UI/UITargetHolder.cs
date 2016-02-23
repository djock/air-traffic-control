using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UITargetHolder : MonoBehaviour
{
	[Header("Planes")]
	public GameObject[] targetsArray = new GameObject[36];

    int currentIndex = 3;
	bool isRunning;

	int airplaneSpeed;

	bool hasClickedInteractStep1;

	GameObject airplaneGo = null;
	
	void Start()
	{
		airplaneSpeed = 90;
	}

	void Update()
	{
        SetTargetActive();
    }

	void SetTargetActive()
	{
		if (!isRunning) {
			StartCoroutine("LookForNextTarget");
		}
	}

	IEnumerator LookForNextTarget()
	{
		isRunning = true;
		yield return new WaitForSeconds(30f);
        
		targetsArray [currentIndex].SetActive(true);
		currentIndex++;

		if (currentIndex >= targetsArray.Length) {
			currentIndex = 0;
		}
		isRunning = false;
	}

    public void HandleClick()
    {
        var activeButton = UIButton.current;

        var activeTask = AppManager.Instance.testManager.activeTask.Keys.Last();
        var activeTaskParams = AppManager.Instance.testManager.activeTask.Values.Last();

        switch (activeTask)
        {
            case TestManager.TaskType.Click:

                var targetName = activeTaskParams[0];

                if (activeButton.name == targetName)
                {
					AppManager.Instance.uiGridHelper.TaskPass();
					AppManager.Instance.uiGridHelper.taskIsPassed = false;
                }
                else
                {
					AppManager.Instance.uiGridHelper.TaskFail();
					AppManager.Instance.uiGridHelper.taskIsFailed = false;

                }
                break;

			case TestManager.TaskType.Direct:
				var activeTargetName = activeTaskParams [0];
				var newTargetName = activeTaskParams [1];

				if ((activeTargetName == activeButton.name) && !hasClickedInteractStep1) {
					hasClickedInteractStep1 = true;
					airplaneGo = activeButton.gameObject;
				} 

				else if (hasClickedInteractStep1 && (activeButton.name != newTargetName)) {
					AppManager.Instance.uiGridHelper.TaskFail();
					AppManager.Instance.uiGridHelper.taskIsFailed = false;

					hasClickedInteractStep1 = false;
					airplaneGo = null;
				}

				if ((activeTargetName != activeButton.name) && !hasClickedInteractStep1) {
					AppManager.Instance.uiGridHelper.TaskFail();
					AppManager.Instance.uiGridHelper.taskIsFailed = false;

					hasClickedInteractStep1 = false;
					airplaneGo = null;
				}

				else if (hasClickedInteractStep1 && (activeButton.name == newTargetName)) {

					var newPosition = activeButton.transform.position;
					var hashTable = new Hashtable();

					hashTable.Add("position", newPosition);
					hashTable.Add("time", airplaneSpeed);
					hashTable.Add("easetype", iTween.EaseType.linear);
					hashTable.Add("moveToPath", false);

					iTween.MoveTo(airplaneGo.gameObject, hashTable);

					AppManager.Instance.uiGridHelper.TaskPass();
					AppManager.Instance.uiGridHelper.taskIsPassed = false;

					hasClickedInteractStep1 = false;
					airplaneGo = null;
				}
                break;

			case TestManager.TaskType.Instruct:
				var selectedTargetName = activeTaskParams [0];
				var selectedInstructionName = activeTaskParams [1];
                   
				if ((selectedTargetName == activeButton.name) && !hasClickedInteractStep1) {
					Debug.LogError("Selected the correct airplane!");
					airplaneGo = activeButton.gameObject;

					foreach (Transform child in airplaneGo.transform) {
						if (child.name == "Instruct") {
							child.gameObject.SetActive(true);
						}
					}

					hasClickedInteractStep1 = true;
                    
				} else if (hasClickedInteractStep1 && (activeButton.name != selectedInstructionName)) {
					Debug.LogError("Wrong Instruction selected");

					foreach (Transform child in airplaneGo.transform) {
						if (child.name == "Instruct") {
							child.gameObject.SetActive(false);
						}
					}

					AppManager.Instance.uiGridHelper.TaskFail();
					AppManager.Instance.uiGridHelper.taskIsFailed = false;

                    hasClickedInteractStep1 = false;
					airplaneGo = null;
				}
				if ((selectedTargetName != activeButton.name) && !hasClickedInteractStep1) {
					Debug.LogError("Selected the wrong airplane!");

					AppManager.Instance.uiGridHelper.TaskFail();
					AppManager.Instance.uiGridHelper.taskIsFailed = false;

					hasClickedInteractStep1 = false;
					airplaneGo = null;
				}

                else if (hasClickedInteractStep1 && (activeButton.name == selectedInstructionName))
                {
                    Debug.LogError("Correct Instruction selected!!!");

					foreach (Transform child in airplaneGo.transform) {
						if (child.name == "Instruct") {
							child.gameObject.SetActive(false);
						}
					}

					AppManager.Instance.uiGridHelper.TaskPass();
					AppManager.Instance.uiGridHelper.taskIsPassed = false;

                    hasClickedInteractStep1 = false;
					airplaneGo = null;
                }
                
                break;

            default:
                Debug.LogError("Missing");
                break;
        }


        Debug.LogError("Clicked on: " + activeButton.gameObject.name);
    }
}
