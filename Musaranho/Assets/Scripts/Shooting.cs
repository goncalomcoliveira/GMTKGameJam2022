using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    public Transform firePoint;

    private Vector2 mousePos;
    private float nextTimeToFire = 0f;
    
    public float range;
    public float rangeRiffle;

    public float fireRate1;
    public float fireRate3;

    public GameObject bulletPrefab;
    public GameObject fireballPrefab;
    public GameObject arrowPrefab;
    public GameObject bombPrefab;
    public GameObject lazerPrefab;

    public float bulletForce = 20f;
    public float arrowForce;
    public float bombForce;
    public float fireballForce;
    public float RiffleForce;


    int face = 0;

    public void ChangeFace(int x)
    {
        face = x;
    }
    public int GetFace()
    {
        return face;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            face = Random.Range(1, 7);
            Debug.Log(face);
        }
        Look();
        if(face == 1)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                Shoot();
                nextTimeToFire = Time.time + 1f / fireRate1;
            }
        }
        else if (face == 3)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                Shoot();
                nextTimeToFire = Time.time + 1f / fireRate3;
            }
        }
        else if(face != 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Look()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    public void Shoot()
    {
        if(face == 1)
        {
            GameObject bullet = Instantiate(lazerPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-rangeRiffle, rangeRiffle), 0)).normalized * RiffleForce, ForceMode2D.Impulse);
        }
        else if (face == 3)
        {
            GameObject bullet = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * fireballForce, ForceMode2D.Impulse);
        }
        else if (face == 4)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * arrowForce, ForceMode2D.Impulse);
        }
        else if (face == 5)
        {
            GameObject bullet = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        }
        else if (face == 6)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-range, range), 0)).normalized * bulletForce, ForceMode2D.Impulse);
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-range, range), 0)).normalized * bulletForce, ForceMode2D.Impulse);
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-range, range), 0)).normalized * bulletForce, ForceMode2D.Impulse);
            GameObject bullet4 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
            rb4.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-range, range), 0)).normalized * bulletForce, ForceMode2D.Impulse);
            GameObject bullet5 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
            rb5.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-range, range), 0)).normalized * bulletForce, ForceMode2D.Impulse);
            GameObject bullet6 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb6 = bullet6.GetComponent<Rigidbody2D>();
            rb6.AddForce(-(firePoint.right + new Vector3(0, Random.Range(-range, range), 0)).normalized * bulletForce, ForceMode2D.Impulse);
        }
        else if(face != 2)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
   
}