using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

	public UISprite background;
	public UISprite area2;
	public UISprite divider;


	[Header("Waypoints")]
	public UISprite waypoint;
	public UILabel waypointLabel;
	public UISprite waypointContainer;
	public UISprite waypointEast;
	public UISprite waypointSouth;
	public UISprite waypointNorth;

	[Header("Airplanes")]
	public UISprite airplane;
	public UISprite airplaneLabel;
	public UISprite airplaneLabelContainer;

	[Header("Instructions")]
	public UISprite climbContainer;
	public UILabel climbLabel;
	public UISprite maintainContainer;
	public UILabel maintainLabel;
	public UISprite descendContainer;
	public UILabel descendLabel;
}
