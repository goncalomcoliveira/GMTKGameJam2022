using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Transform player;
    public float range;
    public int damage;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyLife>().takeDamage(damage);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(player.position.x-transform.position.x,2) + Mathf.Pow(player.position.y - transform.position.y, 2)) > range)
        {
            Destroy(gameObject);
        }
    }
}
