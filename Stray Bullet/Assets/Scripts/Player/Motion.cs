using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    public float speed;
    public float sprintModifier;
    public float jumpForce;
    public Camera normalCam;
    public Transform groundDetector;
    public LayerMask ground;
    private Rigidbody rig;
    private float baseFOV;
    private float sprintFOVModifier = 1.25f;

    public void Start()
    {
        baseFOV = normalCam.fieldOfView;
        Camera.main.enabled = false;
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Ejes
        float t_hmove = Input.GetAxisRaw("Horizontal");
        float t_vmove = Input.GetAxisRaw("Vertical");

        //Controles
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKey(KeyCode.Space);

        //Estados
        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && t_vmove > 0;


        //Salto
        if (isJumping)
        {
            rig.AddForce(Vector3.up * jumpForce);
        }

        //Movimiento
        Vector3 t_direction = new Vector3(t_hmove, 0, t_vmove);
        t_direction.Normalize();

        float t_adjustedpeed = speed;
        if (isSprinting)
        {
            t_adjustedpeed *= sprintModifier;
        }

        Vector3 t_targetVelocity = transform.TransformDirection(t_direction * t_adjustedpeed * Time.deltaTime);
        t_targetVelocity.y = rig.velocity.y;
        rig.velocity = t_targetVelocity;

        //Campo de vista
        if (isSprinting)
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
        }
        else
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f); ;
        }

    }
}

