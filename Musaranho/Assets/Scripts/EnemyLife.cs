using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Explode(int range, int damage)
    {
        if (Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2)) < range)
        {
            life -= damage;
        }
    }

    public void takeDamage(int damage)
    {
        life -= damage;
    }
}
