using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField]

    int NumeroJoueur ;

    [SerializeField]
    float m_jumpForce = 5.0f;
    [SerializeField]
    float m_speed = 5.0f;
    public bool grounded;
    Rigidbody2D m_rigidBody2D;

    Animator m_animator;


    void Start()
    {
        m_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
    }
 

    void Update()
    {

        
        if(NumeroJoueur == 1){
            /// Jump
            if (Input.GetKeyDown("space") && grounded)
            {
                m_rigidBody2D.AddForce(Vector3.up * m_jumpForce, ForceMode2D.Impulse);
            }
            // mAnimator.SetTrigger("TrJump");
            

            /// move
            if (Input.GetKey(KeyCode.A)){
                gameObject.transform.position = transform.position + Vector3.left * m_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D)){
                gameObject.transform.position = transform.position + -Vector3.left * m_speed * Time.deltaTime;
            }


            ///attaque
            if (Input.GetKey(KeyCode.E)){
                m_animator.SetTrigger("Attaque");
            }


        }else if(NumeroJoueur == 2){
            /// Jump
            if (Input.GetKeyDown(KeyCode.RightControl) && grounded){
            m_rigidBody2D.AddForce(Vector3.up * m_jumpForce, ForceMode2D.Impulse);
            // mAnimator.SetTrigger("TrJump");
            }

            /// move
            if (Input.GetKey(KeyCode.LeftArrow)){
                gameObject.transform.position = transform.position + Vector3.left * m_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow)){
              gameObject.transform.position = transform.position + -Vector3.left * m_speed * Time.deltaTime;
            }

            ///attaque
            if (Input.GetKey(KeyCode.RightShift)){
                m_animator.SetTrigger("Attaque");
            }
        }

        if(m_animator.GetCurrentAnimatorStateInfo(0).IsName("Death")){
                Destroy (gameObject.transform.GetChild(0).gameObject);
                Destroy (gameObject);
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


    /*IEnumerator SelfDestruct(GameObject joueuratuer, int NumeroJoueur)
    {
        if(NumeroJoueur==1){
            Destroy(Epee)
        }
        yield return new WaitForSeconds(1f);
        Destroy(joueuratuer);
    }
    */


}
