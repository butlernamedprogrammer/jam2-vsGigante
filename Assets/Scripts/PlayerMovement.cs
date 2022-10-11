using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
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
    [SerializeField]
    PlayerShooter shootingObject;
    private Vector2 movementInput;
    private Rigidbody2D body;
    private SpriteRenderer spr;
    private bool wantsToJump;
    private bool wantsToShoot;
    private Vector2 lookingDir;
    private int currentHealth;
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        isAlive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (movementInput.x < 0)
        {
            lookingDir = Vector2.left;
        }
        else if (movementInput.x > 0)
        {
            lookingDir = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wantsToJump = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            wantsToShoot = true;
        }
        if (isAlive)
        CharFlip();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Move();
            Jump();
            Shoot();
        }
        
    }

    private void Move()
    {
        if (movementInput.x == 0)
        {
            //body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0, decelSpeed * Time.deltaTime), body.velocity.y);
            body.velocity = new Vector2(0, body.velocity.y);
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
    }
    private void Jump()
    {
        if (wantsToJump && grChecker.IsOnGround())
        {
            body.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            wantsToJump = false;
        }
    }

    private void CharFlip()
    {
        if (lookingDir.x < 0)
        {
            spr.flipX = false;
            if (shootingObject.transform.localPosition.x > 0)
            {
                shootingObject.transform.localPosition = new Vector2(shootingObject.transform.localPosition.x * -1, shootingObject.transform.localPosition.y);
            }
        }
        else
        {
            spr.flipX = true;
            if (shootingObject.transform.localPosition.x < 0)
            {
                shootingObject.transform.localPosition = new Vector2(shootingObject.transform.localPosition.x * -1, shootingObject.transform.localPosition.y);
            }
        }
    }

    private void Shoot()
    {
        if (wantsToShoot)
        {
            shootingObject.Shoot();
            wantsToShoot = false;
        }

    }

    public void GetHurt()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            isAlive = false;
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Boss"))
        {
            GetHurt();
        }
    }
}
