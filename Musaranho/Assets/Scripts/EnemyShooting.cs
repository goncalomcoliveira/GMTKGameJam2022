using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackRadius;
    public float chaseRadius;

    public float bulletForce = 20f;

    public void Shoot(Vector3 shotPosition){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPosition * bulletForce, ForceMode2D.Impulse);
    }
}
