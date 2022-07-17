using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    Transform player;
    private AudioSystem s;

    private void Awake()
    {
        s = GameObject.FindWithTag("AudioManager").GetComponent<AudioSystem>();
    }

    void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Explode(int range, int damage) {
        player = GameObject.FindWithTag("Bomb").transform;
        if (Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2)) < range)
        {
            takeDamage(damage);
        }
    }

    public void takeDamage(int damage)
    {
        //s.Play("enemy_hit");
        life -= damage;
    }
}
