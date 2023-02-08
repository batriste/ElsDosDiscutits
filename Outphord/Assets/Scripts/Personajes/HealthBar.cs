using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Health health;
    private void Start() 
    {
        health = GetComponentInParent<Health>();
    }
    public void UpdateHealth()
    {
       
        float x = health.currentHealth / health.maxHealth;
        transform.localScale = new Vector3(x, 1, 1);
    }
}
