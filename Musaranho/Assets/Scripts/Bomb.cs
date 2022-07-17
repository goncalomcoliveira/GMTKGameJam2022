using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public int range;
	public int damage;
	public float countdown = 2f;
	public float explodeCountdown = 0.35f;
	private AudioSystem s;
	public Animator anim;

	private bool play = false;

    private void Awake()
    {
		anim.SetBool("isExploding", false);
		s = GameObject.FindWithTag("AudioManager").GetComponent<AudioSystem>();
	}

    // Update is called once per frame
    void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			if (!play) {
				s.Play("croissant_boom");
				anim.SetBool("isExploding", true);
				play = true;
			}

			explodeCountdown -= Time.deltaTime;
			EnemyLife[] list = (EnemyLife[]) Resources.FindObjectsOfTypeAll(typeof(EnemyLife));
			

            foreach (EnemyLife go in list)
            {
				go.Explode(range, damage);
			}
			
			if (explodeCountdown <= 0f) {
				Destroy(gameObject);
				anim.SetBool("isExploding", false);
				play = false;
			}
		}
	}
}