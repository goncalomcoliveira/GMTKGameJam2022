using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
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

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        Debug.Log(target.name);
    }

    private void Update() {
        anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, sh.chaseRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, sh.attackRadius, whatIsPlayer);

         Debug.Log(isInChaseRange + " " + sh.chaseRadius + isInAttackRange + " " + sh.attackRadius);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (shouldRotate) {
            int dirx = (int) dir.x * 10;
            int diry = (int) dir.y * 10;
            anim.SetInteger("X", dirx);
            anim.SetInteger("Y", diry);
        }
    }

    private void FixedUpdate() {
        if (isInChaseRange && !isInAttackRange) {
            //Debug.Log("It's far");
            MoveCharacter(movement);
        }
        else if (isInAttackRange) {
            rb.velocity = Vector2.zero;
            //Debug.Log("It's shooting " + target.transform.position);
            sh.Shoot(dir);
        }
        //else Debug.Log("Nothing");
    }

    private void MoveCharacter(Vector2 dir) {
        rb.MovePosition((Vector2) transform.position + (dir * speed * Time.deltaTime));
    }
}
