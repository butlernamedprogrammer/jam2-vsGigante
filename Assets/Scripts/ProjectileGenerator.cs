using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class ProjectileGenerator : MonoBehaviour
{
    public enum ProjectileType { BulletLike, PhysicsLike }
    public enum SpawningPoint { FromGameObject, FromCircunference };
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    GameObject bulletSpawner;
    [SerializeField]
    GameObject[] spawningGameobject;
    [SerializeField]
    int currentProjectile;
    [SerializeField]
    float circleRadius;
    [SerializeField, InspectorName("Projectile Type")]
    ProjectileType currentType;
    [SerializeField, InspectorName("Spawn Position")]
    SpawningPoint spawnPoint;
    [SerializeField]
    GameObject player;

    private ProjectileType pt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        float gravityScale;
        Vector3 auxPos = Vector3.zero;
        switch (currentType)
        {
            case ProjectileType.BulletLike:
                gravityScale = 0;
                break;
            case ProjectileType.PhysicsLike:
                gravityScale = 1;
                break;
        }
        switch (spawnPoint)
        {
            case SpawningPoint.FromGameObject:
                auxPos = bulletSpawner.transform.position;
                break;
            case SpawningPoint.FromCircunference:
                auxPos = GetRandomPos();
                break;
        }
        Vector3 bulletDir = (player.transform.position + Vector3.up * 0.25f - auxPos).normalized;
        float angle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject auxGameObj = Instantiate(spawningGameobject[currentProjectile], auxPos, bulletRotation);
        auxGameObj.GetComponent<Rigidbody2D>().AddForce((player.transform.position - auxPos) * bulletSpeed, ForceMode2D.Force);

    }

    public Vector2 GetRandomPos()
    {
        return Random.insideUnitCircle.normalized * circleRadius;
    }

    public void ChangeProjectile(int index)
    {
        currentProjectile = index;
    }

    public void ChangeBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }

}
