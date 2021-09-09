using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField] Node node;
	[SeralizedField] Test test;

	private void Start()
	{
		Debug.Log(node.coordinates);
		Debug.Log(node.isSearchable);
	}


}
