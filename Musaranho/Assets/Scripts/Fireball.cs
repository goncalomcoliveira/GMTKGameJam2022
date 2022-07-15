using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Transform player;
    public float range;
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(player.position.x-this.transform.position.x,2) + Mathf.Pow(player.position.y - this.transform.position.y, 2)) > range)
        {
            Destroy(gameObject);
        }
    }
}
