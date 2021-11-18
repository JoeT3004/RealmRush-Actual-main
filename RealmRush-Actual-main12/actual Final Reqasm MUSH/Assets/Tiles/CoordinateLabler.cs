using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //This is an premade intergrated asset which will be used in order to add text to the objects

[ExecuteAlways] //This file will always execute even when the game is not being played
[RequireComponent(typeof(TextMeshPro))] //takes text mesh pro which allows me to format text in an easy way
public class CoordinateLabler : MonoBehaviour //Declaring class for the coordinate labler
{
//A serilized field is used to so I can edit values inside the engine without changing
	[SerializeField] Color defaultColor = Color.white;//Varaible for colour of text
	[SerializeField] Color blockedColor = Color.gray;//Variable for colour of text when is placed is true

    TextMeshPro label;
	Vector2Int coordinates = new Vector2Int();
	Waypoint waypoint;

	private void Awake()
	{
		label = GetComponent<TextMeshPro>();
		label.enabled = false;
		waypoint = GetComponentInParent<Waypoint>();
		DisplayCoordinates();
	}

	// Update is called once per frame
	void Update()
    {
		if (!Application.isPlaying)
		{
			DisplayCoordinates();
			UpdateObjectName();
			label.enabled = true; //so the coordinates work in edit mode
		}

		SetLabeColour(); //debugging tool
		TurnOnAndOffLables(); //debugging tool
    }

	void TurnOnAndOffLables()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			label.enabled = !label.IsActive(); //!label.IsActive  is the same as = false
		}
	}

	void SetLabeColour()
	{
		if (waypoint.IsPlaceable == true)
		{
			label.color = defaultColor;
		}
		else
		{
			label.color = blockedColor;
		}
	}

	void DisplayCoordinates()
	{
		coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10); // /10 could also = Unity.EditiorSnapSettings.move.x
		coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 10);
		label.text = coordinates.x + "," + coordinates.y;
	}

	void UpdateObjectName()
	{
		transform.parent.name = coordinates.ToString();
	}
}
