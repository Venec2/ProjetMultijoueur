using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestionCamera : MonoBehaviour
{
    [SerializeField]
    Transform m_perso1;
    [SerializeField]
    Transform m_perso2;
    [SerializeField]
    Camera cam;
    float posCameraX;
    float posCameraY;
    float size;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    posCameraX = (m_perso1.position.x + m_perso2.position.x)/2;
    posCameraY = (m_perso1.position.y + m_perso2.position.y)/2;
    gameObject.transform.position = new Vector3(posCameraX, posCameraY, gameObject.transform.position.z);

    size = (Math.Abs(m_perso1.position.x - m_perso2.position.x)/5)+2;

    cam.orthographicSize = size;


    //Debug.Log(m_perso1.position.x - m_perso2.position.x);
    
    }
}
