using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSeed : MonoBehaviour
{
	public Transform spawnPosition;

	public void SpawnEnvi()
	{
		LevelManager.levelManagerInstance.environmentSpawn.SpawnEnvi(spawnPosition);
	}
}
