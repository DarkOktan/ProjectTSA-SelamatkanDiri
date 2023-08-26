using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Singletons
	public static PlayerController Instance;
	#endregion

	[SerializeField]
	public Animator e_playerAnimator;

	[HideInInspector] public PlayerHit e_playerHit;


	private void Awake()
	{
		Instance = this;

		e_playerHit = GetComponent<PlayerHit>();
	}
}
