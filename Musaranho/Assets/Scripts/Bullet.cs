using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float effectDuration = 2f;

    void OnCollisionEnter2D(Collision2D coll){
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectDuration);
        Destroy(gameObject); 
    }
}
