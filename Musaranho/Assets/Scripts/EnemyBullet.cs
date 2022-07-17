using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform player;
    public float range;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {   
            if (!coll.gameObject.GetComponent<health>().sr.enabled) {
                coll.gameObject.GetComponent<health>().TakeDamage(1);
                coll.gameObject.GetComponent<Shooting>().ChangeFace();
                coll.gameObject.GetComponent<health>().sr.enabled = true;
                coll.gameObject.GetComponent<health>().isInvincible = Time.time + coll.gameObject.GetComponent<health>().invincibilityTime;
            }
            Destroy(gameObject);
        }
    }
    public bool Bounce(float range)
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        if (Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2)) < range)
        {
            DestroyImmediate(gameObject, true);
            return true;
        }
        return false;
    }

    void Update()
    {   
        player = GameObject.FindWithTag("Player").transform;
        if (Time.time >= player.GetComponent<health>().isInvincible && player.GetComponent<health>().sr.enabled) player.GetComponent<health>().sr.enabled = false;
        
        if (Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2)) > range)
        {
            Destroy(gameObject);
        }
    }
}
