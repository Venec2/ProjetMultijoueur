using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Epee : MonoBehaviour
{

    [SerializeField]
    int NumeroJoueur ;

    // EdgeCollider2D m_EdgeCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        // m_EdgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(NumeroJoueur == 1){
            if(collision.CompareTag("Joueur2")==true){
                collision.GetComponent<Animator>().SetTrigger("Mort");
                collision.GetComponent<Player>().vies-=1;
                if(collision.GetComponent<Player>().vies == 0){
                    //Joueur 1 wins
                }
            }
            
        }
        
        if(NumeroJoueur == 2){
            if(collision.CompareTag("Joueur1")==true){
                collision.GetComponent<Animator>().SetTrigger("Mort");
                collision.GetComponent<Player>().vies-=1;
                if(collision.GetComponent<Player>().vies == 0){
                    //Joueur 2 wins
                }
            }
        }
    }




}