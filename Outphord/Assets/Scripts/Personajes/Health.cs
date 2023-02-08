using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    
    public float currentHealth;
    public float actualHealth;
    public bool CanDamaged = true;
    public float TimeToDamage = 5f;
    public UnityEvent onDamageTaken;
    public UnityEvent onDead;
    // Start is called before the first frame update
    void Start()
    {
        if(maxHealth < 5f)
        {
            maxHealth = 5f;
            
        }
        currentHealth = maxHealth;
    }


    public void DamageTaken(float amount)
    {
        actualHealth = currentHealth;
        //En el caso de ser un zombie la variable CanDamaged no se usa para nada
        if(this.gameObject.tag == "Player")
        {
            if(CanDamaged)
            {
                CanDamaged = false;
                StartCoroutine(waitForDamage(TimeToDamage));
                DamageTakenPlayer(amount);
            }
            
        }
        else
        {
            Debug.Log("Soy un zombie y estoy muriendo " + actualHealth);
            DamageTakenPlayer(amount);
        }
        // Asi actualizaremos la vida aun sin recibir daño
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