using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MovingController
{
    // Start is called before the first frame update


    public Transform objective;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Buscar el objective por tag
        objective = GameObject.FindGameObjectWithTag("Player").transform;
        //Falta Comprovacion de que exista       
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = objective.position;
        if(agent.velocity.magnitude> 0 )
        {
            anim.SetBool("Walk", true);
            
        }
        //Revisar distancias porque no en todos los entornos se representa igual
        if(Vector3.Distance(transform.position, agent.destination) < 1.5f)
        {
            Debug.Log(Vector3.Distance(transform.position, agent.destination) + (" Estoy cerca"));
            //Hariamos da�o y se activa la animacion de atacar
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        Debug.Log(hit.gameObject);
        Debug.Log(hit.gameObject.tag);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
