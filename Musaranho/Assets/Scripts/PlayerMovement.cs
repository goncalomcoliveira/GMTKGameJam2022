using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform sprite;
    public float moveSpeed = 7f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    public Transform rotatePoint;

    private Vector2 moveDirection;

    private Vector2 mousePos;

    void Update()
    {
        //Process Inputs
        ProcessInputs();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //Physics Calculations
        Move();
        Vector2 lookDir = mousePos - rb.position;
        float angle;
        if(gameObject.GetComponent<Shooting>().GetFace() == 6)
        {
            angle = Mathf.Atan2(-lookDir.y, -lookDir.x) * Mathf.Rad2Deg;
        }
        else angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rotatePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        int movX, movY;
        if (moveX >= 0)
            movX = Mathf.CeilToInt(moveX);
        else
            movX = Mathf.FloorToInt(moveX);

        if (moveY >= 0)
            movY = Mathf.CeilToInt(moveY);
        else
            movY = Mathf.FloorToInt(moveY);

        anim.SetInteger("X", movX);
        anim.SetInteger("Y", movY);

        if (moveX == 0 && moveY == 0) anim.SetBool("isRunning", false);
        else anim.SetBool("isRunning", true);

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
