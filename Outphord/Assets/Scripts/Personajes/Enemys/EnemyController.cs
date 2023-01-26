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
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Buscar el objective por tag
        objective = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = objective.position;
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
