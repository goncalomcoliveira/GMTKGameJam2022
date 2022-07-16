using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHatMovement : MonoBehaviour
{
    public float speed;
    public EnemyShooting sh;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private float nextTimeToFire = 0f;
    float fireRate = 1f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, sh.chaseRadius, whatIsPlayer);

        //anim.SetBool("isRunning", (isInChaseRange && !isInAttackRange));

        dir = target.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
    }

    private void FixedUpdate() {
        if (isInChaseRange && !isInAttackRange) MoveCharacter();
        else if (isInAttackRange && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            rb.velocity = Vector2.zero;
            sh.Shoot(dir);
        }
    }

    private void MoveCharacter() {
        /*if (shouldRotate) {
            anim.SetInteger("X", (int) Mathf.Round(movement.x));
            anim.SetInteger("Y", (int) Mathf.Round(movement.y));
        }*/
        float posx = (float) Random.Range(-sh.attackRadius,sh.attackRadius);
        int signal = Random.Range(0,2);
        if (signal == 0) signal = -1;
        float posy = (Mathf.Sqrt(Mathf.Pow(sh.attackRadius, 2) - Mathf.Pow(posx, 2)));

        Vector2 pos = new Vector2(posx + target.position.x, signal*posy + target.position.y);
        rb.MovePosition(pos);
    }
}
