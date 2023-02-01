using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ControllerPlayer : MovingController
{
    //Movimiento Direccion Y Control
    public CharacterController player = null;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private Vector3 playerInput;
    private Vector3 movePlayer;

    //Referencia camera
    public Camera mainCamera = null;
    private Vector3 camForward;
    private Vector3 camRight;
    //Gravity
    public float gravetat = 9.8f;
    public float powerJump = 8f;
    public float fallVelocity = 0f;
    //Rampa
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;

    //Arma
    public Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        gun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Mouse 0 ");
            if (gun != null)
            {
                gun.Shoot();
            }
        }
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
        movePlayer = movePlayer * movementSpeed;

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
            anim.SetBool("Jump", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                fallVelocity = powerJump;
                anim.SetBool("Jump", true);
            }
        }
        else
        {
            fallVelocity -= gravetat * Time.deltaTime;
        }
        //Revisar y si eso mover tambien hacia la direccion que va el player
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
        if (hit.gameObject.tag == "Zombie")
        {
            //Un zombie nos esta golpeando
            //Nos restaria vida
        }
        
        hitNormal = hit.normal;
    }

}
