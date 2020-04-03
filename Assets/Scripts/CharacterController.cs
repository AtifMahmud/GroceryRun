using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private Rigidbody rb;
    private Camera camera;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("@@Start");
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    void MoveRight()
    {
        this.transform.Translate(0.25f, 0, 0);
        camera.transform.Translate(0.25f, 0, 0);
        animator.SetFloat("Speed", 2.0f);
    }

    void Jump()
    {
        Debug.Log("@@ Jump");
        this.transform.Translate(0, 0.25f, 0);
    }
}
