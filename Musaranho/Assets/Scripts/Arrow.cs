using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyLife>().takeDamage(damage);
        }
        if (coll.transform.tag == "Parede")
        {
            Destroy(gameObject);
        }
    }

}
