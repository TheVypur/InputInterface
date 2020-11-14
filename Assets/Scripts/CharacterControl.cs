using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float fMovespeed;
    public float fGravity = -40;
    public float fJumpSpeed = 20;

    private CharacterController m_Controller;
    private Vector3 v3MoveDirection;
    private Animator m_Anim;

    private InputInterface m_InputInterface;

    // Start is called before the first frame update
    void Start()
    {
        m_Controller = GetComponent<CharacterController>();
        m_Anim = GetComponentInChildren<Animator>();
        m_InputInterface = GetComponent<InputInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_InputInterface.GetKey(KeyCode.W))
        {
            v3MoveDirection += transform.forward * fMovespeed * Time.deltaTime;
        }

        if (m_InputInterface.GetKey(KeyCode.A))
        {
            v3MoveDirection += transform.right * fMovespeed * Time.deltaTime;
        }

        if (m_InputInterface.GetKey(KeyCode.S))
        {
            v3MoveDirection += transform.forward * -1 * fMovespeed * Time.deltaTime;
        }

        if (m_InputInterface.GetKey(KeyCode.D))
        {
            v3MoveDirection += transform.right * -1 * fMovespeed * Time.deltaTime;
        }

        if (m_InputInterface.GetKeyDown(KeyCode.Space))
        {
            if (m_Controller.isGrounded)
            {
                v3MoveDirection.y += fJumpSpeed;
            }
        }

        v3MoveDirection.y += fGravity * Time.deltaTime;

        if (m_Controller.isGrounded)
        {
            v3MoveDirection *= 0.9f;
        }

        m_Controller.Move(v3MoveDirection * Time.deltaTime);

        m_Anim.SetFloat("Forward", Vector3.Dot(v3MoveDirection, transform.forward));
        m_Anim.SetFloat("Right", Vector3.Dot(v3MoveDirection, transform.right));

    }
}
