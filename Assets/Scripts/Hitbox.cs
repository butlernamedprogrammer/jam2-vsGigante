using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    string hurtTag;
    bool isHurt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.tag.Contains(hurtTag);
        isHurt = true;
    }

    public bool CheckHurt()
    {
        if (isHurt)
        {
            isHurt=false;
            return !isHurt;
        }
        else
        {
            return isHurt;
        }
    }
}
