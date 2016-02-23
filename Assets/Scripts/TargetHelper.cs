using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class TargetHelper : MonoBehaviour {

	bool collisionWithAirplane = false;
	bool collisionWithBorder = false;
	
	public float conflictTime;
	public float realConflictTime;
	
	bool taskStatus;
	bool spaceHasBeenPressedBorder;
	bool spaceHassBeenPressedAirplane;
	
	string userId;
	int testType;

    public UILabel targetNameLabel;

    [Header("Instructions")]
	public GameObject instruct;
    public GameObject climb;
    public GameObject maintain;
    public GameObject descend;
    
    string pathName;

	int airplaneSpeed;

	ParseObject airplaneConflict = new ParseObject("AirplaneConflict");
	ParseObject borderConflict = new ParseObject("BorderConflict");

    void Awake() {
        //GetComponent<iTweenPath>().pathName = gameObject.name + "_path";
    }

    void Start()
    {
		airplaneSpeed = 120;

		userId = AppManager.Instance.userId;
		testType = AppManager.Instance.testType;
		
		spaceHasBeenPressedBorder=false;
		spaceHassBeenPressedAirplane = false;

        MoveOnPath();
    }

	void Update()
	{
		AirplaneConflict();
		BorderConflict();

		if(AppManager.Instance.testManager.appTime > 10)
		{
			airplaneSpeed = 5;
		}
	}

    void OnEnable()
    {
        AppManager.Instance.AssignRandomName();
        AssignName();

		instruct = gameObject.transform.Find("Instruct").gameObject;
    }

    void AssignName()
    {
        gameObject.transform.name = AppManager.Instance.randomName;
        targetNameLabel.text = "" + AppManager.Instance.randomName;

        AppManager.Instance.testManager.targets.Add(AppManager.Instance.randomName);

    }

    void MoveOnPath() {
        var hashTable = new Hashtable();
        var pathName = GetComponent<iTweenPath>().pathName;

        hashTable.Add("path", iTweenPath.GetPath(pathName));
        hashTable.Add("time", airplaneSpeed);
        hashTable.Add("easetype", iTween.EaseType.linear);
        hashTable.Add("moveToPath", false);
		hashTable.Add("oncomplete", "DestroyAirplane");
		hashTable.Add("oncompletetarget", this.gameObject);

        iTween.MoveTo(gameObject, hashTable);
    }

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Airplane"){
			collisionWithAirplane = true;
		}

		if (other.gameObject.tag == "Area2") {
			collisionWithBorder = true;
		} 
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Waypoint"){
			Destroy(this.gameObject);
			AppManager.Instance.testManager.targets.Remove(this.gameObject.name);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Airplane"){
			Debug.LogError("Collision Ended");
			AirplaneConflictFail();
			collisionWithAirplane = false;
			conflictTime = 0;
			spaceHassBeenPressedAirplane = false;
		}

		if (other.gameObject.tag == "Area2") {
			Debug.LogError("Airplane exits Area 2");
			BorderConflictFail();
			collisionWithBorder = false;
			conflictTime = 0;
			spaceHasBeenPressedBorder = false;
		}
	}
		
	public void DestroyAirplane()
	{
		AppManager.Instance.testManager.targets.Remove(this.gameObject.name);
		Destroy(this.gameObject);
	}

	public void AirplaneConflict()
	{
		if(collisionWithAirplane) {
  			StartCoroutine("AirplaneConflictTime");
			if (Input.GetKeyDown(KeyCode.Space) && !spaceHassBeenPressedAirplane){
				spaceHassBeenPressedAirplane = true;
				AirplaneConflictPass();
//				spaceHassBeenPressedAirplane = false;
			}

		}
	}

	public void BorderConflict()
	{
		if(collisionWithBorder) {
			StartCoroutine("BorderConflictTime");
			if (Input.GetKeyDown(KeyCode.LeftControl) && !spaceHasBeenPressedBorder){
				spaceHasBeenPressedBorder = true;
				BorderConflictPass();
//				spaceHasBeenPressedBorder = false;
			}
		}
	}
	
	void AirplaneConflictPass(){
		userId = AppManager.Instance.userId;

		taskStatus = true;
//		spaceHassBeenPressedAirplane = true;
		realConflictTime = conflictTime / 5f;
		Debug.LogError("Airplane Conflict=================== Space key was pressed after" + realConflictTime);
		
		airplaneConflict["user_id"] = userId;
		airplaneConflict["test_type"] = testType.ToString();
		airplaneConflict["task_type"] = "Airplane Conflict";
		airplaneConflict["task_status"] = true;
		airplaneConflict["time"] = realConflictTime;
		
		airplaneConflict.SaveAsync();
		spaceHassBeenPressedAirplane = false;
	}

	void BorderConflictPass(){
		userId = AppManager.Instance.userId;

		taskStatus = true;
//		spaceHasBeenPressedBorder = true;
		realConflictTime = conflictTime / 5f;
		Debug.LogError("Border Conflict===================== Return key was pressed after" + realConflictTime);
		
		borderConflict["user_id"] = userId;
		borderConflict["test_type"] = testType.ToString();
		borderConflict["task_type"] = "Border Conflict";
		borderConflict["task_status"] = true;
		borderConflict["time"] = realConflictTime;
		
		
		borderConflict.SaveAsync();
		spaceHasBeenPressedBorder = true;

	}
	
	void AirplaneConflictFail(){
		if(!spaceHassBeenPressedAirplane)
		{
			userId = AppManager.Instance.userId;

			airplaneConflict["user_id"] = userId;
			airplaneConflict["test_type"] = testType.ToString();
			airplaneConflict["task_type"] = "Airplane Conflict";
			airplaneConflict["task_status"] = false;
			airplaneConflict["time"] = realConflictTime;
			
			airplaneConflict.SaveAsync();
			
			Debug.LogError("Nothing sent to Parse from Airplane Conflict");
		}
	}

	void BorderConflictFail(){
		if(!spaceHasBeenPressedBorder)
		{
			userId = AppManager.Instance.userId;

			borderConflict["user_id"] = userId;
			borderConflict["test_type"] = testType.ToString();
			borderConflict["task_type"] = "Border Conflict";
			borderConflict["task_status"] = false;
			borderConflict["time"] = realConflictTime;
			
			borderConflict.SaveAsync();
			
			Debug.LogError("Nothing sent to Parse from Border Conflict ");
		}
	}
	
	IEnumerator AirplaneConflictTime()
	{
		yield return new WaitForSeconds(0.1f);
		conflictTime += 0.1f;
		//Debug.Log(appTime);
	}

	IEnumerator BorderConflictTime()
	{
		yield return new WaitForSeconds(0.1f);
		conflictTime += 0.1f;
		//Debug.Log(appTime);
	}

}
