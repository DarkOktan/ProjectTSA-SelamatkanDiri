using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MilkShake;

using DG.Tweening;

public class CameraContainer : MonoBehaviour
{
	#region Singletons
	public static CameraContainer instanceCamera;
	#endregion

	[SerializeField] ShakePreset myShakerPreset;
	private Shaker myShaker;

	private Camera cam;

	private void Awake()
	{
		instanceCamera = this;

		cam = GetComponentInChildren<Camera>();
		myShaker = GetComponentInChildren<Shaker>();
	}

	public void ShakeCamera()
	{
		myShaker.Shake(myShakerPreset);
	}

	public void FOVTransition(float To, float From, float duration)
	{
		Debug.Log("FOV Transition");

		Sequence seq = DOTween.Sequence();
		seq.Append(cam.DOOrthoSize(To, duration).From(From));
	}
}
