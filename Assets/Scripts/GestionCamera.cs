using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCamera : MonoBehaviour
{
    [SerializeField]
    Transform m_perso1;
    [SerializeField]
    Transform m_perso2;
    float posCameraX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    posCameraX = (m_perso1.position.x + m_perso2.position.x)/2;
    gameObject.transform.position = new Vector3(posCameraX, gameObject.transform.position.y, gameObject.transform.position.z);
    
    }
}
