using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Boss") || collision.gameObject.tag.Contains("Default") || collision.gameObject.tag.Contains("Player") || collision.gameObject.tag.Contains("Level"))
        {
            Destroy(this.gameObject);
        }
    }
}
