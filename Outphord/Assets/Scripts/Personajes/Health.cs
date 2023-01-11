using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 5;
    public float currentHealth = 3;
    public UnityEvent onDamageTaken;
    public UnityEvent onDead;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void DamageTaken(float amount)
    {
        currentHealth -= amount;
        onDamageTaken.Invoke();
        if (currentHealth <= 0)
        {
            onDead.Invoke();

        }
    }
}