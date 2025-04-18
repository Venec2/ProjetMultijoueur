using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using Unity.VisualScripting.InputSystem;
//using System.Numerics;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int vies = 3 ;
    [SerializeField]

    int NumeroJoueur ;

    [SerializeField]
    float m_jumpForce = 5.0f;
    [SerializeField]
    float m_speed = 5.0f;
    public bool grounded;
    Rigidbody2D m_rigidBody2D;

    Animator m_animator;

    UnityEngine.Vector2 debut;
    UnityEngine.Vector2 fin;
    //private float elapsedTime;
                


    void Start()
    {
        m_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
        debut.x = 7.5f;
        debut.y = 5.8f;
        fin.x = 10.5f;
        fin.y = 3f;
       

    }
 

    void Update()
    {

        //elapsedTime += Time.deltaTime;
        //float percentageComplete = elapsedTime / 0.2f;

        

        
        if(NumeroJoueur == 1){
            //Debug.Log(gameObject.transform.GetChild(0).gameObject.transform.localPosition);
            /// Jump
            if (Input.GetKeyDown("space") && grounded)
            {
                m_rigidBody2D.AddForce(UnityEngine.Vector3.up * m_jumpForce, ForceMode2D.Impulse);
            }
            // mAnimator.SetTrigger("TrJump");
            

            /// move
            if (Input.GetKey(KeyCode.A)){
                gameObject.transform.position = transform.position + UnityEngine.Vector3.left * m_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D)){
                gameObject.transform.position = transform.position + -UnityEngine.Vector3.left * m_speed * Time.deltaTime;
            }


            ///attaque
            if (Input.GetKeyDown(KeyCode.E)){
                m_animator.ResetTrigger("NotAttaque");
                m_animator.SetTrigger("Attaque");
                
                gameObject.transform.GetChild(0).gameObject.transform.localPosition = fin;
                gameObject.transform.GetChild(0).gameObject.transform.localRotation = Quaternion.Euler(0, 0, -40);
                
                
                Debug.Log("debut " + gameObject.transform.GetChild(0).gameObject.transform.localPosition);
                
            }else if(Input.GetKeyUp(KeyCode.E)){
                m_animator.ResetTrigger("Attaque");
                m_animator.SetTrigger("NotAttaque");

                StartCoroutine(DelayAction(0.25f));
                
                Debug.Log("fin " + gameObject.transform.GetChild(0).gameObject.transform.localPosition);
            }


        }else if(NumeroJoueur == 2){
            /// Jump
            if (Input.GetKeyDown(KeyCode.RightControl) && grounded){
            m_rigidBody2D.AddForce(UnityEngine.Vector3.up * m_jumpForce, ForceMode2D.Impulse);
            // mAnimator.SetTrigger("TrJump");
            }

            /// move
            if (Input.GetKey(KeyCode.LeftArrow)){
                gameObject.transform.position = transform.position + UnityEngine.Vector3.left * m_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow)){
              gameObject.transform.position = transform.position + -UnityEngine.Vector3.left * m_speed * Time.deltaTime;
            }

            ///attaque
            if (Input.GetKeyDown(KeyCode.RightShift)){
                m_animator.ResetTrigger("NotAttaque");
                m_animator.SetTrigger("Attaque");

                gameObject.transform.GetChild(0).gameObject.transform.localPosition = fin;
                gameObject.transform.GetChild(0).gameObject.transform.localRotation = Quaternion.Euler(0, 0, -40);


            }else if(Input.GetKeyUp(KeyCode.RightShift)){
                m_animator.ResetTrigger("Attaque");
                m_animator.SetTrigger("NotAttaque");

                StartCoroutine(DelayAction(0.25f));
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


    IEnumerator DelayAction(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.transform.GetChild(0).gameObject.transform.localPosition = debut;
        gameObject.transform.GetChild(0).gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        
    }
    


}
