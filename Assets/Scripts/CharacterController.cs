using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Camera camera;
    private Animator animator;
    private bool grounded = true;
    private AudioSource[] audios;
    private int score = 0;

    GameObject scoreText;

    // for debugging
    public float jumpForce;
    public float run;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("@@Start");
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        animator = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
        scoreText = GameObject.Find("ScoreNum");
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", 0.0f);
        animator.SetBool("Jump", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // MoveLeft ();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MoveRight()
    {
        this.transform.Translate(run, 0, 0);
        camera.transform.Translate(run, 0, 0);
        animator.SetFloat("Speed", 2.0f);
    }


    // Under Construction
    void MoveLeft()
    {
        gameObject.transform.transform.Rotate(0, 180, 0, Space.Self);
        this.transform.Translate(-run, 0, 0);
        camera.transform.Translate(-0.75f * run, 0, 0);
        animator.SetFloat("Speed", 2.0f);
    }

    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
            audios[0].Play();
            grounded = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            grounded = true;
            // Debug.Log("@@ Grounded");
        }

        if (collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            IncrementScore();
            audios[1].Play();           
        }
    }

    void IncrementScore()
    {
        score++;
        SetScore();
    }

    void SetScore()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }
}

