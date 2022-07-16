using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public int range;
	public int damage;
	public float countdown = 2f;

	// Update is called once per frame
	void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			FindObjectOfType<EnemyLife>().Explode(range,damage);
			Destroy(gameObject);
		}
	}
}