using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    bool onGround;
    void Start()
    {
        onGround = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Level"))
        {
            onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains("Level"))
        {
            onGround = false;
        }
    }

    public bool IsOnGround()
    {
        return onGround;
    }
}
