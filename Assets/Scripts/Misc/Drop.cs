using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    SpriteRenderer sr;

    public float dropSpeed;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public Projectile dropPrefab;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();


        if (dropSpeed <= 0)
        {
            dropSpeed = 7.0f;
        }

        if (!spawnPointLeft || !spawnPointRight || !dropPrefab)
        {
            Debug.Log("please set up default values on " + gameObject.name);
        }
    }
    public void Fire()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(dropPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.speed = -dropSpeed;            
        }

        else
        {
            Projectile curProjectile = Instantiate(dropPrefab, spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.speed = dropSpeed;
        }

    }
}
