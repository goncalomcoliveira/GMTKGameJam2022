using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.transform.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyLife>().takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
