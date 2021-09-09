using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node //This class is not inheritings anything: pure c# classes, can't add to game object
{
	public Vector2Int coordinates; //public is good for pure class as there is no functions
	public bool isSearchable;
	public bool isExplored;
	public bool isPath;
	public Node connectedTo;

	public Node(Vector2Int coordinates, bool isWalkable)
	{
		this.coordinates = coordinates;
		this.isSearchable = isWalkable;
	}



}
