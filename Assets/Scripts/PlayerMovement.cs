using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float fallingSpeedMod;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float decelSpeed;
    [SerializeField]
    GroundChecker grChecker;
    private Vector2 movementInput;
    private Rigidbody2D body;
    public bool eatingRange;
    public bool isEating;
    private bool wantsToJump;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();;
    }

    // Update is called once per frame
    private void Update()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wantsToJump = true;
        }
        Eat();

    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Eat()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            isEating = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && eatingRange)
        {
            isEating = true;
        }
    }

    private void Move()
    {
        if (movementInput.x == 0 && grChecker.IsOnGround())
        {
            body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0, decelSpeed * Time.deltaTime), body.velocity.y);
        }
        else
        {
            body.AddForce(movementInput * movementSpeed, ForceMode2D.Force);
            if (Mathf.Abs(body.velocity.x) > maxSpeed)
            {
                float movSign = body.velocity.x / Mathf.Abs(body.velocity.x);
                body.velocity = new Vector2(maxSpeed * movSign, body.velocity.y);
            }
        }
        if (!grChecker.IsOnGround() && body.velocity.y <= 0)
        {
            body.velocity=new Vector2(body.velocity.x,body.velocity.y - fallingSpeedMod);
        }
        else
        {
        }

    }
    private void Jump()
    {
        if (wantsToJump && grChecker.IsOnGround())
        {
            body.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            wantsToJump = false;
        }
    }
}
