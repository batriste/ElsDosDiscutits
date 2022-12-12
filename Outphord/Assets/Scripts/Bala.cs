using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody element;
    public float Speed = 10;
    public float flyTime = 3f;
    public float damage = 2f;

   

    // Start is called before the first frame update
    void Start()
    {
        element = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("DamageTaken", damage);
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
