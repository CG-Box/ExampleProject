using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    public string visibleToInspector = "Bob The Bean";

    [SerializeField]private float moveSpeed = 5f;

    private float horizontal;

    private Vector2 moveDirection;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void FixedUpdate()
    {
        HadleMovement();
    }

    void HandleMovementInput()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = InputManager.GetInstance().GetMoveDirection();
    }

    void HadleMovement()
    {
        //rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
}
