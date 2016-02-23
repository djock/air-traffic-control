using UnityEngine;
using System.Collections;
using Parse;

public class UIGridHelper : MonoBehaviour {

	public bool taskIsPassed = false;
	public bool taskIsFailed = false;
	public float taskTime = 0;
	public UIGrid taskGrid;
    public int taskTimeToComplete;

    private string userId;
    private int testType;
    private string taskType;

    

    void Start()
    {
        taskTimeToComplete = 10;

        userId = PlayerPrefs.GetString("user_id");
        testType = AppManager.Instance.testType;
    }
	void Update () {
		while (transform.childCount > 1){
            RemoveOldTask();
        }

        if (taskTime > taskTimeToComplete)
        {
            TaskNotCompletedInTime();
        }
    }

	public void CountTaskTime()
	{
		if (AppManager.Instance.testManager.isTaskActive) {
			InvokeRepeating("TaskTime", 0.1f, 0.1f);
            
        } else {
			taskTime = 0;
		}
        
    }

    public void TaskFail()
	{
		ParseObject userTasks = new ParseObject("UserTasks");

		userId = AppManager.Instance.userId;

		if (transform.childCount >0) {
			NGUITools.Destroy(transform.GetChild(0).gameObject);
		}

		AppManager.Instance.testManager.isTaskActive = false;
		taskIsFailed = true;

        Debug.LogError("User " + userId + " Test: " + testType + " Task " + AppManager.Instance.testManager.taskType + " was " + taskIsPassed + " and it took " + taskTime + " seconds");

        userTasks["user_id"] = userId;
        userTasks["test_type"] = testType;
        userTasks["task_type"] = AppManager.Instance.testManager.taskType.ToString();
        userTasks["task_status"] = taskIsPassed;
        userTasks["time"] = taskTime;

		userTasks.SaveAsync();

        CancelInvoke("TaskTime");
		taskGrid.Reposition();
		taskTime = 0;
	}

	public void TaskPass()
	{
		ParseObject userTasks = new ParseObject("UserTasks");

		userId = AppManager.Instance.userId;

		if (transform.childCount >0) {
			NGUITools.Destroy(transform.GetChild(0).gameObject);
		}

		AppManager.Instance.testManager.isTaskActive = false;
		taskIsPassed = true;

		Debug.LogError("User " + userId + " Test: " + testType + " Task " + AppManager.Instance.testManager.taskType + " was " + taskIsPassed + " and it took " + taskTime + " seconds");

        userTasks["user_id"] = userId;
        userTasks["test_type"] = testType;
        userTasks["task_type"] = AppManager.Instance.testManager.taskType.ToString();
        userTasks["task_status"] = taskIsPassed;
        userTasks["time"] = taskTime;

		userTasks.SaveAsync();

        CancelInvoke("TaskTime");
		taskGrid.Reposition();
		taskTime = 0;
	}

	void TaskTime()
	{
		taskTime += 0.1f;
	}

    void TaskNotCompletedInTime()
    {
		ParseObject userTasks = new ParseObject("UserTasks");

		userId = AppManager.Instance.userId;

		if (transform.childCount >0) {
        	NGUITools.Destroy(transform.GetChild(0).gameObject);
		}
        AppManager.Instance.testManager.isTaskActive = false;
        taskIsPassed = false;

        Debug.LogError("Task was not completed in time");

        userTasks["user_id"] = userId;
        userTasks["test_type"] = testType;
        userTasks["task_type"] = AppManager.Instance.testManager.taskType.ToString();
        userTasks["task_status"] = "expired";
        userTasks["time"] = taskTime;

        userTasks.SaveAsync();

        CancelInvoke("TaskTime");
        taskGrid.Reposition();
        taskTime = 0;
    }

    void RemoveOldTask()
    {
        NGUITools.Destroy(transform.GetChild(0).gameObject);
    }

}
