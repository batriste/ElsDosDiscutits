using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public Vector3 towardsTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected void MoveTowards(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movementSpeed * Time.deltaTime);
       
        Quaternion towardsTargetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, towardsTargetRotation, rotationSpeed * Time.deltaTime);


        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
