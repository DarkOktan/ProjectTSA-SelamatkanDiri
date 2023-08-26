using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;

public class DuckMovement : MonoBehaviour
{
	#region Singletons
	public static DuckMovement instance;
	#endregion

	[SerializeField] Transform targetPlayer;

	[SerializeField] float e_stepTime = 10f;
	[SerializeField] float e_duckAppearTranstionTime = 2f;

	private void Awake()
	{
		instance = this;
	}

	private void FixedUpdate()
	{
		FollowCharacter();
	}

	private void FollowCharacter()
	{
		Vector3 targetPosition = targetPlayer.position;
		targetPosition.y = transform.position.y;
		transform.localPosition = Vector3.MoveTowards(transform.position, targetPosition, e_stepTime * Time.deltaTime);
	}

	public void DuckAppear()
	{
		DuckAppearTransition();
	}
	public void DuckAppearTransition()
	{
		transform.DOMoveY(0, 1).OnComplete(() => {
			transform.DOMoveY(-2.45f, 1).SetDelay(PlayerController.Instance.e_playerHit.phaseReturnTime);
		});
	}

	public void DuckAppearOnGameOver()
	{
		DOTween.Kill(transform);

		transform.DOMoveY(0.5f, 0.5f);
	}
}
