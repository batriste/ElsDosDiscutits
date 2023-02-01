using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 5;
    
    public float currentHealth = 3;
    public float actualHealth;
    public bool CanDamaged = true;
    public float TimeToDamage = 5f;
    public UnityEvent onDamageTaken;
    public UnityEvent onDead;
    // Start is called before the first frame update
    
    
    public void DamageTaken(float amount)
    {
        actualHealth = currentHealth;
        //En el caso de ser un zombie la variable CanDamaged no se usa para nada
        if(this.gameObject.tag == "Player")
        {
            if(CanDamaged)
            {
                DamageTakenPlayer(amount);
            }
            CanDamaged = false;
        }
        else
        {
            DamageTakenPlayer(amount);
        }
        
        
        if (this.gameObject.tag == "Player" && CanDamaged!)
        {
            StartCoroutine(waitForDamage(TimeToDamage));
        }
        onDamageTaken.Invoke();
        
    }

    private void DamageTakenPlayer(float amount)
    {

        if (amount >= currentHealth)
        {
            currentHealth -= currentHealth;
            if (currentHealth < 0f)
            {
                onDead.Invoke();
                currentHealth = 0f;
            }
        }
        else
        {
            currentHealth -= amount;
        }
        
        
    }

    private IEnumerator waitForDamage(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        CanDamaged = true;
    }
}