using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class EnemyController : MovingController
{
    // Start is called before the first frame update


    public Transform objective;
    /// <summary>
    /// Sera el daño que hara el zombie si es un zombie normal haria 1/4 de la vida del player y 1/2 si es un jefe
    /// </summary>
    public float damage;
    NavMeshAgent agent;
    private float distance;
    public bool attack;
    private float time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Buscar el objective por tag
        objective = GameObject.FindGameObjectWithTag("Player").transform;
        //Falta Comprovacion de que exista
        distance = Vector3.Distance(transform.position, agent.destination);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = objective.position;
        distance = Vector3.Distance(transform.position, agent.destination);
        if (agent.velocity.magnitude> 0f )
        {
            anim.SetBool("Walk", true);
            if (distance < 1.5f)
            {
                
                attack = true;
                //Hariamos daño y se activa la animacion de atacar

                if (distance < 0.8f && attack == true)
                {

                    StartCoroutine(waitForDamage(time));

                }
            }
            else
            {
                attack = false;
            }
        }
        
        anim.SetBool("Attack", attack);
        //Revisar distancias porque no en todos los entornos se representa igual
        
    }
    private IEnumerator waitForDamage(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        if (distance < 0.8f && attack == true)
        {
            objective.SendMessage("DamageTaken", damage);
            
            
        }
        attack = false;
    }
}
