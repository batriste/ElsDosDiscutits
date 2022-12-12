using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingEntity
{
    public GameObject bulletPrefab;
    public float shootCooldown = 0.25f;
    float lastShotTime = 0;
    Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredDirection = Vector3.zero;
        
        if (Input.GetKey(KeyCode.A))
            desiredDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            desiredDirection += Vector3.right;
        if (Input.GetKey(KeyCode.W))
            desiredDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            desiredDirection += Vector3.back;

        if (desiredDirection != Vector3.zero)
            MoveTowards(desiredDirection.normalized);
        if (Input.GetKey(KeyCode.Space))
        {
            if (gun != null)
            gun.Shoot();
        }
    }
    void Shot()
    {
        if (Time.time - lastShotTime > shootCooldown)
        {
            GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastShotTime = Time.time;

        }
    }
}
