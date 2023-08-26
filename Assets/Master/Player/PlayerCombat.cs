using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	[Header("Attack Configuration")]
	[SerializeField] float rantingAttackDistance;
	[SerializeField] GameObject projectilePrefab;

	[SerializeField] float projectileSpeed;
	[SerializeField] float projectileDestroyedCooldown;

	[SerializeField] LayerMask destructableObstacleMask;

	private int currentAmmo = 5;

    public void RantingAttack()
	{
		Debug.DrawRay(transform.position, transform.up * rantingAttackDistance, Color.black, 10f);
		RaycastHit2D[] hitResult = Physics2D.RaycastAll(transform.position, transform.up, rantingAttackDistance, destructableObstacleMask);

		if (hitResult.Length > 0)
		{
			Destroy(hitResult[0].transform.parent.gameObject);
		}
	}

	public void KetapelAttack()
	{
		if (currentAmmo <= 0) return;

		GameObject projectileObj = Instantiate(projectilePrefab);
		projectileObj.transform.position = transform.position;

		KetapelProjectile projectileComponent = projectileObj.GetComponent<KetapelProjectile>();
		
		projectileComponent.SetForce(transform.up * projectileSpeed, projectileDestroyedCooldown);

		currentAmmo--;
	}
}
