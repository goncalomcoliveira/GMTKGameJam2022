using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHatMovement : MonoBehaviour
{
    public float speed;
    public EnemyShooting sh;
    public float waitingAttack = 1f;
    public float waitingMove = 1f;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;

    private Transform target;
    private Vector3 targetPosition;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private float nextTimeToAttack = 0f;
    private float nextTimeToMove = 0f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        nextTimeToMove = Time.time + waitingMove;
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, sh.chaseRadius, whatIsPlayer);

        isInAttackRange = Physics2D.OverlapCircle(transform.position, sh.attackRadius, whatIsPlayer);
        if(isInAttackRange && Time.time >= nextTimeToAttack) {
            dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            sh.Shoot(dir);
            nextTimeToAttack = Time.time + waitingAttack; 
        }

        if (!isInChaseRange || Time.time < nextTimeToMove) return;

        //anim.SetBool("isRunning", (isInChaseRange && !isInAttackRange));

        rb.MovePosition(target.position);

        nextTimeToAttack = Time.time + waitingAttack;
        nextTimeToMove = Time.time + waitingMove;

    }
}
