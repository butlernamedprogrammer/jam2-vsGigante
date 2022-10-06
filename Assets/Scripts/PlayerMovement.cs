using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    float movementSpeed;
    Rigidbody2D body;
    bool eatingRange;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Eat()
    {
        if (Input.GetKeyDown(KeyCode.Space) && eatingRange)
        {

        }
    }

    private void Move()
    {
        body.AddForce(movementInput * movementSpeed, ForceMode2D.Force);
    }
}
