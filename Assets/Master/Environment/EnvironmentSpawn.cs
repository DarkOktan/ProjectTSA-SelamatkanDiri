using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawn : MonoBehaviour
{
    public GameObject[] seedData;
	public Transform EnvironmentLevelParent;

    public void SpawnEnvi(Transform lastEnvi)
	{
		GameObject rand = seedData[Random.Range(0, seedData.Length)];

		GameObject createdObj = Instantiate(rand, EnvironmentLevelParent);
		createdObj.transform.position = lastEnvi.position;
	}
}
