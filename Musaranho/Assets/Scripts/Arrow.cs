using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyLife>().takeDamage(damage);
        }
        if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
