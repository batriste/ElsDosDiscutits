using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingController : MonoBehaviour
{
    
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;

    
    //Animacions
    public Animator anim;
    
    //Estados
    private enum State
    {
        Walking,
        Ragdoll
    }
    //Ragdoll

    private Rigidbody[] _ragdollRigidbodies;
    
    private void Awake()
    {
        //_ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        //DisableRagdoll();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
    public void onDeadHandler()//Se encargará de gestionar la muerte del enemigo.
    {
        //EnableRagdoll();
        Debug.Log("He muerto");
        //Esperaremos y eliminaremos al personaje
    }

}