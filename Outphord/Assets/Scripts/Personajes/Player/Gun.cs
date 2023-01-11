using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootCooldown = 0.25f;
    float lastShotTime = 0;
    public void Shoot()
    {
        if (Time.time - lastShotTime > shootCooldown)
        {
            GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastShotTime = Time.time;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
