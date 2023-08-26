using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	#region Singletons
	public static LevelManager levelManagerInstance;
	#endregion

	public EnvironmentSpawn environmentSpawn;

	public void Awake()
	{
		levelManagerInstance = this;

		environmentSpawn = GetComponent<EnvironmentSpawn>();
	}
}
