using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Parameters")]
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
    float invincibilityTimer;
    [Header("Helpers")]
    [SerializeField]
    GroundChecker grChecker;
    [SerializeField]
    PlayerShooter shootingObject;
    [SerializeField]
    AudioSFX sfx;
    private Vector2 movementInput;
    private Rigidbody2D body;
    private SpriteRenderer spr;
    private Animator anim;
    private bool wantsToJump;
    private bool wantsToShoot;
    private Vector2 lookingDir;
    private int currentHealth;
    private bool isAlive;
    private float nextTimeVincible;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        isAlive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (movementInput.x < 0)
        {
            lookingDir = Vector2.left;
        }
        else if (movementInput.x > 0)
        {
            lookingDir = Vector2.right;
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
            //Shoot();
        }
        ToAnimator();
    }

    public void Move()
    {
        Vector2 auxBulletDir = Vector2.zero;
        if (movementInput.x == 0)
        {
            body.velocity = new Vector2(0, body.velocity.y);
            auxBulletDir.x = lookingDir.x;
            anim.SetFloat("BulletDirX", lookingDir.x);
        }
        else
        {
            Vector2 auxInput = new Vector2(movementInput.x, 0f);
            body.AddForce(auxInput * movementSpeed, ForceMode2D.Force);
            if (Mathf.Abs(body.velocity.x) > maxSpeed)
            {
                float movSign = body.velocity.x / Mathf.Abs(body.velocity.x);
                body.velocity = new Vector2(maxSpeed * movSign, body.velocity.y);
            }
            if (movementInput.y <= 0.5f)
            {
                auxBulletDir.y = 0f;
            }
            else
            {
                auxBulletDir.y = 0.5f;
            }
            auxBulletDir.x = auxInput.x;
            anim.SetFloat("BulletDirX", auxBulletDir.x);
            anim.SetFloat("BulletDirY", auxBulletDir.y);
            shootingObject.ChangeBulletDir(auxBulletDir);
        }
        anim.SetFloat("BulletDirY", auxBulletDir.y);
        shootingObject.ChangeBulletDir(auxBulletDir);
    }
    private void Jump()
    {
        if (wantsToJump && grChecker.CanJump())
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
                if (shootingObject.transform.localScale.x > 0)
                {
                    shootingObject.transform.localScale = new Vector2(shootingObject.transform.localScale.x * -1f, shootingObject.transform.localPosition.y);
                }
            }
        }
        else
        {
            spr.flipX = true;
            if (shootingObject.transform.localPosition.x < 0)
            {
                shootingObject.transform.localPosition = new Vector2(shootingObject.transform.localPosition.x * -1, shootingObject.transform.localPosition.y);
                if (shootingObject.transform.localScale.x < 0)
                {
                    shootingObject.transform.localScale = new Vector2(shootingObject.transform.localScale.x * -1f, shootingObject.transform.localPosition.y);
                }
            }
        }
    }

    public void Shoot()
    {
        shootingObject.Shoot();

    }

    public void GetMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void GetJumpInput(InputAction.CallbackContext context)
    {
        wantsToJump = context.ReadValueAsButton();
    }
    public void GetShootInput(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            anim.Play("shootIntro");
        }

    }

    public void GetHurt()
    {
        currentHealth -= 1;
        nextTimeVincible = Time.unscaledTime + invincibilityTimer;


        if (currentHealth <= 0)
        {
            isAlive = false;
            nextTimeVincible = Time.unscaledDeltaTime + 9999f;
            anim.Play("Death");
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
            if (Time.unscaledTime > nextTimeVincible)
                GetHurt();
        }
    }

    private void ToAnimator()
    {
        anim.SetFloat("VelocityX", Mathf.Abs(body.velocity.x));
        anim.SetFloat("VelocityY", body.velocity.y);
        anim.SetBool("OnGround", grChecker.CanJump());
    }

    public void PlayAudio()
    {
        sfx.PlayCurrentClipOneShot();
    }
}
