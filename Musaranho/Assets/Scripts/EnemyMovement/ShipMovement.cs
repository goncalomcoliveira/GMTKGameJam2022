using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
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

    private bool isInChaseRange = false;
    private bool isInAttackRange = false;

    private float nextTimeToFire = 0f;
    public float fireRate = 1f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, sh.chaseRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, sh.attackRadius, whatIsPlayer);

        anim.SetBool("isRunning", (isInChaseRange && !isInAttackRange));

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
        if (shouldRotate) {
            anim.SetInteger("X", (int) Mathf.Round(movement.x));
            anim.SetInteger("Y", (int) Mathf.Round(movement.y));
        }
        rb.MovePosition((Vector2) transform.position + ((Vector2) movement * speed * Time.deltaTime));
    }

}
