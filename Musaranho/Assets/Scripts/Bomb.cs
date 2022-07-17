using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public int range;
	public int damage;
	public float countdown = 2f;
	private AudioSystem s;

    private void Awake()
    {
		s = GameObject.FindWithTag("AudioManager").GetComponent<AudioSystem>();
	}

    // Update is called once per frame
    void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			EnemyLife[] list = (EnemyLife[]) Resources.FindObjectsOfTypeAll(typeof(EnemyLife));

            foreach (EnemyLife go in list)
            {
				s.Play("croissant_boom");
				go.Explode(range, damage);
			}
			
			Destroy(gameObject);
		}
	}
}