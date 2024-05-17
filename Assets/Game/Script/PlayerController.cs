using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private FloatingJoystick joysticks;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        pickedBricks = new List<GameObject>();
        characterIndexColor = 1;
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        onStair = CheckOnBridge();
        if (onStair == false)
        {
            canMove = true;
        }
        SetAnim();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();

    }
    protected override void SetAnim()
    {
        if (rb.velocity == Vector3.zero)
        {
            SetAnim("Idle");

        }
        else if (rb.velocity.z != 0 || rb.velocity.x != 0)
        {
            SetAnim("Run");

        }
    }
    protected override void Moving()
    {
        base.Moving();

        if (canMove == true || joysticks.Vertical < 0)
        {
            rb.velocity = new Vector3(joysticks.Horizontal * speed, rb.velocity.y, joysticks.Vertical * speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        if ((joysticks.Vertical != 0 || joysticks.Horizontal != 0) && rb.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

    }


}
