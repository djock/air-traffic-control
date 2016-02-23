using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TestManager : MonoBehaviour
{

	[Header("Variables")]
	public int appTime;
	public float tasksDelay;
	public string selectedTarget;
	public string selectedWaypoint;
	public string selectedInstruction;
	public bool isTaskActive = false;

	[Header("Components")]
	public UIGrid taskGrid;
	public UILabel waypointEastLabel;
	public UILabel waypointSouthLabel;
	public UILabel waypointNorthLabel;
    public GameObject waypointsHolder;
    public GameObject task;
    public UILabel taskLabel;
	public UIPanel testEnd;



	public List<string> targets = new List<string>();
	public List<string> waypoints = new List<string>();
    public List<string> instructions = new List<string>();

    public enum TaskType
    {
        Click,
        Direct,
        Instruct
    }

    public TaskType taskType;

    public enum InstructionType
    {
        Climb,
        Maintain,
        Descend
    }

    public Dictionary<TaskType, List<String>> activeTask = new Dictionary<TaskType, List<string>>();
	
	int timeTaskIsActive;
	string taskTypeName;
	bool taskAssigned;
	
	string randomLetters;
	string randomNumbers;

	bool conflictStatus;

	void OnEnable()
	{
		AppManager.Instance.testManager = this;
		CountAppTime();
		tasksDelay = 15f;

	}

	void Update()
	{
		AddTask();
		if(appTime>300)
		{
			tasksDelay = 10f;
		}

	}

	void AddTask()
	{
		if (!taskAssigned) {
			StartCoroutine("GenerateTask");
		}
	}

	IEnumerator GenerateTask()
	{
        taskAssigned = true;
		yield return new WaitForSeconds(tasksDelay);
		
		SetTaskType();

		NGUITools.AddChild(taskGrid.gameObject, task);

		isTaskActive = true;
		if (isTaskActive) {
			AppManager.Instance.uiGridHelper.CountTaskTime();
		} else {
			Debug.LogError("Timer stopped");
		}
		taskAssigned = false;

	}

	public void SelectRandomTarget()
	{
		var randomSelector = new System.Random();

		int listIndex = randomSelector.Next(targets.Count);
		selectedTarget = targets [listIndex];
	}

	public void SelectRandomWaypoint()
	{
		var randomSelector = new System.Random();

		int listIndex = randomSelector.Next(waypoints.Count);
		selectedWaypoint = waypoints [listIndex];
	}

	public void SetTaskType()
	{

		Array values = Enum.GetValues(typeof(TaskType));
		System.Random random = new System.Random();
		TaskType randomTask = (TaskType)values.GetValue(random.Next(values.Length));

//		randomTask = TaskType.Instruct;
        taskType = randomTask;

        activeTask = new Dictionary<TaskType, List<string>>();


		switch (randomTask) {
			case TaskType.Instruct:

				SelectRandomTarget();
                SelectRandomInstruction();

                //TaskInstructTo();
				taskLabel.text = "Instruct " + selectedTarget + " to " + selectedInstruction;

				List<string> instructParameters = new List<string>();
				instructParameters.Add(selectedTarget);
                instructParameters.Add(selectedInstruction);
				activeTask.Add(taskType, instructParameters);


				break;

			case TaskType.Direct:

                SelectRandomTarget();
				SelectRandomWaypoint();

				taskLabel.text = "Direct " + selectedTarget + " to " + selectedWaypoint;

				List<string> directParameters = new List<string>();
				directParameters.Add(selectedTarget);
				directParameters.Add(selectedWaypoint);
				activeTask.Add(taskType, directParameters);

				break;

			case TaskType.Click:
                SelectRandomTarget();

				taskLabel.text = "Click on " + selectedTarget;

				List<string> clickParameters = new List<string>();
				clickParameters.Add(selectedTarget);
				activeTask.Add(taskType, clickParameters);

				break;

			default:
				Debug.Log("No task was assigned.");
				break;
		}
	}

    void SelectRandomInstruction()
    {
        Array valuesArray = Enum.GetValues(typeof(InstructionType));
        System.Random random = new System.Random();
        InstructionType randomInstruction = (InstructionType)valuesArray.GetValue(random.Next(valuesArray.Length));

        switch (randomInstruction)
        {
            case InstructionType.Climb:
                selectedInstruction = AppManager.Instance.targetHelper.climb.name;
                break;

            case InstructionType.Maintain:
				selectedInstruction = AppManager.Instance.targetHelper.maintain.name;
                break;
            case InstructionType.Descend:
				selectedInstruction = AppManager.Instance.targetHelper.descend.name;
                break;
            default:
                Debug.Log("No specific instruction was specified");
                break;
        }
    }

	public void CountAppTime()
	{
		InvokeRepeating("AppTime", 1f, 1f);
	}
	void AppTime()
	{
		appTime += 1;
		//Debug.Log(appTime);
	}


	
}