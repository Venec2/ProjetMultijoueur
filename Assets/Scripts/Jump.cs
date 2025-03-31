using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Jump : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField]
    float m_jumpForce = 5.0f;
    public bool grounded;

    Rigidbody2D m_rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        /// mAnimator = GetComponent<Animator>();

        // Collider2D coucou = this.gameObject.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && grounded)
        {
            m_rigidBody2D.AddForce(Vector3.up * m_jumpForce, ForceMode2D.Impulse);
            /// mAnimator.SetTrigger("TrJump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}