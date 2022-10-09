using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletSpeed;

    public void Shoot()
    {
        float angle = Mathf.Atan2(transform.forward.y, transform.forward.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject auxGameObj = Instantiate(bullet, transform.position, bulletRotation);
        auxGameObj.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Force);
    }
}
