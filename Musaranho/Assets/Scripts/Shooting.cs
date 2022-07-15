using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;

    public Transform firePoint;
    float fireRate = 100f;
    public GameObject bulletPrefab;

    private Vector2 mousePos;

    public float bulletForce = 20f;
    private float nextTimeToFire = 0f;

    void Update()
    {
        Look();
        Debug.Log(fireRate);
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f/fireRate;
        }
    }

    void Look()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce((firePoint.right + new Vector3(0, Random.Range(-1f, 1f), 0)).normalized * bulletForce, ForceMode2D.Impulse);
    }
   
}