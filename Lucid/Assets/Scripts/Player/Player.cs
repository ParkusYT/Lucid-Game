using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private AudioSource walkingAudio;

    Vector3 velocity;

    bool onGround;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(onGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.W))
        {
            walkingAudio.Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            walkingAudio.Stop();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
