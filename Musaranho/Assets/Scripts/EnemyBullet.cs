using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {
            coll.gameObject.GetComponent<health>().TakeDamage(1);
            coll.gameObject.GetComponent<Shooting>().ChangeFace();
        }
        Destroy(gameObject);
    }
    public bool Bounce(float range)
    {
        Transform player = GameObject.FindWithTag("EnemyBullet").transform;
        if (Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2)) < range)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
