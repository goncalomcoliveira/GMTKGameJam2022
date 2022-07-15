using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform sprite;
    public float moveSpeed = 7f;

    public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Update()
    {
        //Process Inputs
        ProcessInputs();
    }

    void FixedUpdate()
    {
        //Physics Calculations
        Move();
    }

    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX < 0)
            sprite.localScale = new Vector3(-1f, 1f, 1f);
        else if (moveX > 0)
            sprite.localScale = new Vector3(1f, 1f, 1f);

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
