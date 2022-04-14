using UnityEngine;
using System.Collections;

public class move_controll : MonoBehaviour
{
    Transform m_transform, m_camera;
    private CharacterController controller;
    public float MoveSpeed = 20.0f;
                                 
    void Start()
    {
        m_transform = this.transform;
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            transform.GetComponent<Animator>().SetBool("walk", true);
            if (Input.GetKey(KeyCode.W))
            {
           
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 180f, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 270f, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 90f, 0);
            }

            controller.Move(m_transform.forward * Time.deltaTime * MoveSpeed);
        }
        else
           
            transform.GetComponent<Animator>().SetBool("walk", false);
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
        }
        if (!controller.isGrounded)
        {
       
            controller.Move(new Vector3(0, -10f * Time.deltaTime, 0));
        }
    }
}