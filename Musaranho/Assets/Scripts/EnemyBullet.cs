using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {
            coll.gameObject.GetComponent<health>().TakeDamage(damage);
            coll.gameObject.GetComponent<Shooting>().ChangeFace();
        }
        Destroy(gameObject);
    }
}
