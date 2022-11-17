using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    [Header("移动参数")]
    //定义player的移动速度
    public float moveSpeed = 5;
    [Header("跳跃参数")]
    //定义player的跳跃速度
    public float jumpSpeed = 4;
    public float angleSpeed = 40f;
    
    private CharacterController _controller;
    
    // input
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    
    // gravity
    public float gravity = 9.8f;
    private Vector3 velocity;
    
    // check ground
    public Transform groundCheck;
    public float checkRadius = 0.15f;
    public LayerMask groundLayer;
    
    // player status
    public bool isOnground;
    public bool isJump;

    public AudioSource audioSource;
    public PlayerAnimator playerAnimation;
    public Vector3 angle;

    private float _targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        angle = transform.eulerAngles;
    }
    
    // Update is called once per frame
    void Update()
    {
        isOnground = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if (isOnground && velocity.y < 0)
        {
            velocity.y = -1;
            isJump = false;
        }
        
        // move
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 inputDirection = new Vector3(horizontalMove, 0.0f, verticalMove).normalized;
        //dir = transform.forward * verticalMove + transform.right * horizontalMove;
        //dir = transform.forward * verticalMove;
        //angle.y += horizontalMove;
        //transform.rotation = quaternion.Euler(angle);
        
        
        //cc.Move(dir * Time.deltaTime);
        float _rotationVelocity = 0;
        if (inputDirection == Vector3.zero)
        {
            playerAnimation.PlayIdle();
        }
        else
        {
            playerAnimation.PlayWalk();

            _targetRotation = Mathf.Atan2(horizontalMove, verticalMove) * Mathf.Rad2Deg + camera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                angleSpeed);

            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            
            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            _controller.Move(targetDirection.normalized * (moveSpeed * Time.deltaTime) +
                             new Vector3(0.0f, _rotationVelocity, 0.0f) * Time.deltaTime);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnground)
        {
            velocity.y = jumpSpeed;
            isJump = true;
            playerAnimation.PlayJump();
        }
        velocity.y -= gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void OnStepsEvent()
    {
        audioSource.Play();
    }
}
