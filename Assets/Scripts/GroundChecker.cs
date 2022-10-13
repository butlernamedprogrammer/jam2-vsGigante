using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public bool coyoteTimeEnabled;
    [SerializeField]
    public float coyoteThreshold;
    private float coyoteTimeLeft;
    public bool onGround;
    void Start()
    {
        onGround = false;
    }

    // Update is called once per frame
    private void Update()
    {
        coyoteTimeLeft -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Level"))
        {
            if(coyoteTimeEnabled)
            coyoteTimeLeft = coyoteThreshold;
            onGround = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Contains("Level"))
        {
            if(coyoteTimeEnabled)
            coyoteTimeLeft = coyoteThreshold;
            onGround = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }

    public bool IsOnGround()
    {
        return onGround;
    }
    public bool CanJump()
    {
        if (coyoteTimeLeft > 0)
        {
            coyoteTimeLeft = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
