using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {
            coll.gameObject.GetComponent<Shooting>().ChangeFace();
        }
        Destroy(gameObject);
    }
}
