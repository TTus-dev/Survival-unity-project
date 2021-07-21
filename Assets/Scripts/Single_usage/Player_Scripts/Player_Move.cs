using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float player_speed;

    public LayerMask ground;
    public Transform groundDetector;

    public float jump_height = 3;
    public float gravity = -9.81f;

    private Rigidbody rig;
    private CharacterController ccontrol;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ccontrol = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool ground_under = Physics.CheckSphere(groundDetector.position, 0.5f, ground);

        if (ground_under) {
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        if (Input.GetButton("Jump") && ground_under)
        {
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        ccontrol.Move(move * player_speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        ccontrol.Move(velocity * Time.deltaTime);
    }
}
