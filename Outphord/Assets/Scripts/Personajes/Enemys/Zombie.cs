using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    private enum ZombieState
    {
        Walking,
        Ragdoll
    }

    private Rigidbody[] _ragdollRigidbodies;
    private void Awake()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableRagdoll();
        }
    }

    private void DisableRagdoll()
    {
        foreach(var rigidbody in _ragdollRigidbodies)
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
}
