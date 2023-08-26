using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetapelProjectile : MonoBehaviour
{
    private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void SetForce(Vector2 force, float destroyTime = Mathf.Infinity)
	{
		rb.AddForce(force);
		Destroy(gameObject, destroyTime);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
