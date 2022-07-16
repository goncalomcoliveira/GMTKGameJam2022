using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;
    public float effectDuration = 2f;

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.transform.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
