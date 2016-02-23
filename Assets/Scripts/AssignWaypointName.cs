using UnityEngine;
using System.Collections;

public class AssignWaypointName : MonoBehaviour {

    public UILabel waypointNameLabel;

    void OnEnable()
    {
		AppManager.Instance.AssignWaypointName();

		gameObject.transform.name = AppManager.Instance.randomWaypointName;
		waypointNameLabel.text= "" + AppManager.Instance.randomWaypointName;

		AppManager.Instance.testManager.waypoints.Add(AppManager.Instance.randomWaypointName);
    }
}
