using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingEntity
{
    Vector3 targetPosition;
    

    float wanderRadius = 5f;
    void Start()
    {
        RecalculateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
            towardsTarget = targetPosition - transform.position;
            MoveTowards(towardsTarget.normalized);

            if (towardsTarget.magnitude < 0.25f)
                RecalculateTargetPosition();

            Debug.DrawLine(transform.position, targetPosition, Color.green);
    }
    void RecalculateTargetPosition()
    {
        targetPosition = transform.position + Random.insideUnitSphere * wanderRadius;
        targetPosition.y = 1f;
    }
    public void onDeadHandler()
    {
        Destroy(gameObject);
    }
}
