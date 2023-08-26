using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
	/// <summary>
	/// Phase 1 ketika bebek tidak muncul/masih jauh
	/// Phase 2 Ketika bebek sudah dekat dan akan kalah jika terkena lagi
	/// </summary>
	public enum DamagedPhase { Phase_1, Phase_2, GameOver }

	public DamagedPhase currentPhase;

	public float phaseReturnTime;

	private Transform hitObstacle;
	private float currentPhaseReturn;

	private void Start()
	{
		currentPhaseReturn = phaseReturnTime;
	}

	private void Update()
	{
		ReturnPhase();
	}
	private void ReturnPhase()
	{
		if (currentPhase == DamagedPhase.Phase_1 || currentPhase == DamagedPhase.GameOver) return;

		currentPhaseReturn -= Time.deltaTime;
		if (currentPhaseReturn <= 0.0f)
		{
			currentPhase--;

			currentPhaseReturn = phaseReturnTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("BoxEnviChecker"))
		{
			collision.GetComponentInParent<EnvironmentSeed>().SpawnEnvi();
		}

		if (hitObstacle == collision.transform) return;

		if (collision.tag.Equals("SoftObstacle"))
		{
			hitObstacle = collision.transform.parent;
			Debug.Log("Got Hit By Soft Obstacle : " + collision.name);

			CameraContainer.instanceCamera.ShakeCamera();
			DuckMovement.instance.DuckAppear();

			currentPhase++;
		}
		else if (collision.tag.Equals("HardObstacle"))
		{
			hitObstacle = collision.transform.parent;
			Debug.Log("Got Hit By Hard Obstacle : " + collision.name);

			currentPhase = DamagedPhase.GameOver;
		}

		CheckPhase();
	}

	private void CheckPhase()
	{
		if (currentPhase == DamagedPhase.GameOver)
		{
			Debug.Log("Game Over");
			GameManager.instance.GameOver();
		}
	}
}
