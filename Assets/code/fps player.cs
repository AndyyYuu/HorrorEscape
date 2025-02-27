using System;
using UnityEngine;

public class fpsplayer : MonoBehaviour

{
    int moveSpeed = 5;

    float lookSpeedX = 6;
    float lookSpeedY=3;
    Transform camTrans;
    float XRotation;
    float YRotation;
    Rigidbody rb;
    int jumpForce=8;
    public LayerMask groundLayer;
    float groundCheckDisk = .5f;
    public bool grounded = false;
    public Transform feetTrans;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camTrans = Camera.main.transform;
        Cursor.lockState=CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
    Vector3 moveDir = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxis("Horizontal");
    moveDir *= moveSpeed;
    moveDir.y = rb.linearVelocity.y; // 保持 y 轴速度
    rb.linearVelocity = moveDir; // 正确使用 Rigidbody 的 velocity
    grounded = Physics.CheckSphere(feetTrans.position, groundCheckDisk,groundLayer);
    
}
    // Update is called once per frame
    void Update()
    {
        
        YRotation += Input.GetAxis("Mouse X")*lookSpeedX;
        XRotation -= Input.GetAxis("Mouse Y")*lookSpeedY;
        XRotation = Mathf.Clamp(XRotation, -90, 90);
        camTrans.localEulerAngles = new Vector3(XRotation,0,0);
        transform.eulerAngles = new Vector3(0,YRotation,0);
    }
    
}
