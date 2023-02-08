using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Bala : MonoBehaviour
{
    private Rigidbody element;
    public float Speed = 10f;
    public float flyTime = 3f;
    public float damage = 2f;


    private void Awake()
    {
        element = GetComponent<Rigidbody>();
        element.AddForce(transform.forward * Speed, ForceMode.VelocityChange);
        Invoke("DestroyBullet", flyTime);
    }
        // Start is called before the first frame update
        void Start()
    {
        //element = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        //Revisar pero funciona
        Debug.Log(other.gameObject.tag + " Estoy en el trigger");
        if (other.CompareTag("Zombie"))
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
