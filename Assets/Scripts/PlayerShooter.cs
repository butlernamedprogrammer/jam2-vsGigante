using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletSpeed;
    public Vector2 bulletDir;

    public void Shoot()
    {
        Debug.Log("Pium");
        float angle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject auxGameObj = Instantiate(bullet, transform.position, bulletRotation);
        auxGameObj.GetComponent<Rigidbody2D>().AddForce(bulletDir * bulletSpeed, ForceMode2D.Force);
    }

    public void ChangeBulletDir(Vector2 newDir)
    {
        bulletDir = newDir;
    }
}
