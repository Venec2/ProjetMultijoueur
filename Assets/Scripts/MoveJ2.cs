using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJ2 : MonoBehaviour
{
    [SerializeField]
    float m_speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position = transform.position + Vector3.left * m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position = transform.position + -Vector3.left * m_speed * Time.deltaTime;
        }

    }
}
