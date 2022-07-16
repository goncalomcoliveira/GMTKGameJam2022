using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    int x;
    int y;

    private PlayerFace pf;

    void Start() {
        pf = gameObject.GetComponent<PlayerFace>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Player")
        {
            x = coll.gameObject.GetComponent<Shooting>().GetFace();
            y = Random.Range(1, 7);
            if (x == y)
            {
                if (y == 6)
                {
                    y = 5;
                }
                else
                {
                    y++;
                }
            }
            coll.gameObject.GetComponent<Shooting>().ChangeFace(y);
            pf.Set(1);
            Debug.Log(y);
        }
        Destroy(gameObject);
    }
}
