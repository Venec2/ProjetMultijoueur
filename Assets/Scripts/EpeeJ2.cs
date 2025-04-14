using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class EpeeJ2 : MonoBehaviour
{

    [SerializeField]

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
        if(collision.GetComponent<Move>() != null)
        {
            collision.GetComponent<Animator>().SetTrigger("Mort");
        }
    }
}