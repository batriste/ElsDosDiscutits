using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    /***
     * Steps
     * 1Values
     *  
     * ***/
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private Vector3 playerInput;

    public CharacterController player = null;
    private Vector3 movePlayer;

    public float gravetat = 9.8f;
    public float powerJump = 8f;
    public float fallVelocity = 0f;

    public Camera mainCamera = null;
    private Vector3 camForward;
    private Vector3 camRight;

    public float PlayerSpeed = 0f;

    //Var test
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;
    
    //Animacions
    private Animator anim;

    public float x, y;
     // Start is called before the first frame update
        void Start()
    {

        anim = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        
        

        Move();

        
    }
    void FixedUpdate()
    {
        
        
    }
    
    
    //Cameras
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    void Move()
    {
        camDirection();
        
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        anim.SetFloat("X", playerInput.x);
        anim.SetFloat("Y", playerInput.z);

        //Limitaria la velocidad
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        //Leer pdf 1.2
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * PlayerSpeed;
        
        player.transform.LookAt(player.transform.position + movePlayer);
        Gravity();
        player.Move(movePlayer * Time.deltaTime);

    }
    //Gravedad
    private void Gravity()
    {

        if (player.isGrounded)
        {
            fallVelocity = -gravetat * Time.deltaTime;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                fallVelocity = powerJump;
            }
        }
        else
        {
            fallVelocity -= gravetat * Time.deltaTime;
        }

        movePlayer.y = fallVelocity;
        //Rampas
        SlideDown();
    }
    //Rampas
    public bool isOnSlope()
    {


        return Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;
    }
    
    public void SlideDown()
    {
        if (isOnSlope())
        {
            movePlayer.x += ((1f - hitNormal.y) * hitNormal.x) * slideVelocity;
            movePlayer.z += ((1f - hitNormal.y) * hitNormal.z) * slideVelocity;

            movePlayer.y += slopeForceDown;

        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
