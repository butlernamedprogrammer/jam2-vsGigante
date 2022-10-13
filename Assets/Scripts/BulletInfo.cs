using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    Animator anim;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Boss") || collision.gameObject.tag.Contains("Wall") || collision.gameObject.tag.Contains("Player") || collision.gameObject.tag.Contains("Level"))
        {
            Destroy(body);
            anim?.Play("Explode");
        }
    }
    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
